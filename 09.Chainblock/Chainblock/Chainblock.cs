﻿using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly List<ITransaction> transactions;
        private readonly HashSet<int> ids;
        private readonly Dictionary<int, ITransaction> transactionsById;
        private readonly SortedDictionary<double, List<ITransaction>> transactionsSortedByAmount;
        private readonly Dictionary<TransactionStatus, List<ITransaction>> transactionsOrderedByTransactionStatus;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
            this.ids = new HashSet<int>();
            this.transactionsById = new Dictionary<int, ITransaction>();
            this.transactionsSortedByAmount = new SortedDictionary<double, List<ITransaction>>(
                Comparer<double>.Create((first, second) => second.CompareTo(first)));
            this.transactionsOrderedByTransactionStatus = new Dictionary<TransactionStatus, List<ITransaction>>();
        }

        public int Count => this.ids.Count;

        public void Add(ITransaction tx)
        {
            this.transactions.Add(tx);
            this.ids.Add(tx.Id);

            this.transactionsById[tx.Id] = tx;

            if (!this.transactionsSortedByAmount.ContainsKey(tx.Amount))
            {
                this.transactionsSortedByAmount[tx.Amount] = new List<ITransaction>();
            }
            this.transactionsSortedByAmount[tx.Amount].Add(tx);

            if (!this.transactionsOrderedByTransactionStatus.ContainsKey(tx.Status))
            {
                this.transactionsOrderedByTransactionStatus[tx.Status] = new List<ITransaction>();
            }
            this.transactionsOrderedByTransactionStatus[tx.Status].Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID cannot be negative or zero.");
            }
            if (!this.transactionsById.ContainsKey(id))
            {
                throw new ArgumentException("Transaction doesn't exist.");
            }

            this.transactions.Find(tr => tr.Id == id).Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentException("Transaction cannot be null.");
            }

            return this.ids.Contains(tx.Id);
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID cannot be zero or less than zero.");
            }

            return this.ids.Contains(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            var result = new List<ITransaction>();
            foreach (var (amount, transactions) in this.transactionsSortedByAmount)
            {
                if (lo <= amount && amount <= hi)
                {
                    result.AddRange(transactions);
                }
                if (amount < lo)
                {
                    break;
                }
            }

            return result;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var result = this.transactions.OrderByDescending(x => x.Amount).ThenBy(x => x.Id);
            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactionsOrderedByTransactionStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("No transactions with this status are found.");
            }

            var receivers = this.transactionsOrderedByTransactionStatus[status].OrderBy(y => y.Amount).Select(x => x.To).ToList();
            return receivers;

        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            if (!this.transactionsOrderedByTransactionStatus.ContainsKey(status))
            {
                throw new InvalidOperationException("No transactions with this status are found.");
            }

            var senders = this.transactionsOrderedByTransactionStatus[status].OrderBy(y => y.Amount).Select(x => x.From).ToList();
            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!ids.Contains(id))
            {
                throw new InvalidOperationException("ID doesn't exist.");
            }

            return this.transactionsById[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var result = this.transactions.Where(x => x.To == receiver && x.Amount > lo && x.Amount < hi);

            if (!result.Any())
            {
                throw new InvalidOperationException("No transactions are found.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            if (string.IsNullOrEmpty(receiver))
            {
                throw new InvalidOperationException("Receiver cannot be null or empty.");
            }
            var transactionByReceiver = this.transactions.Where(x => x.To == receiver);
            if (!transactionByReceiver.Any())
            {
                throw new InvalidOperationException("Receiver not found.");
            }
            var result = transactionByReceiver.OrderByDescending(x => x.Amount).ThenBy(y => y.Id).ToList();
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactionBySender = this.transactions.Where(x => x.From == sender).OrderByDescending(y => y.Amount).ToList();
            var result = transactionBySender.Where(x => x.Amount >= amount);
            if (!result.Any())
            {
                throw new InvalidOperationException("No transactions are found.");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            if (string.IsNullOrEmpty(sender))
            {
                throw new InvalidOperationException("Sender cannot be null or empty.");
            }
            var result = this.transactions.Where(x => x.From == sender).OrderByDescending(y => y.Amount).ToList();
            if (!result.Any())
            {
                throw new InvalidOperationException("Sender not found.");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var result = this.transactions.Where(x => x.Status == status).ToList();
            if (!result.Any())
            {
                throw new InvalidOperationException("No transaction with this status are found.");
            }
            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var result = this.transactions.Where(ts => ts.Status == status && ts.Amount <= amount).OrderByDescending(x => x.Amount).ToList();
            return result;
        }

        public IEnumerator<ITransaction> GetEnumerator() => this.transactions.GetEnumerator();

        public void RemoveTransactionById(int id)
        {
            if (!this.ids.Contains(id))
            {
                throw new InvalidOperationException("ID doesn't exist.");
            }

            var transaction = this.transactions.Where(x => x.Id == id).ToList();
            this.transactions.Remove(transaction[0]);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
