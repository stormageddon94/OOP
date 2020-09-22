using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator() => this.transactions.GetEnumerator();

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
