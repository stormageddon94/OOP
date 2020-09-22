using Chainblock.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private double amount;

        public Transaction(int id, TransactionStatus transactionStatus, string from, string to, double amount)
        {
            this.Id = id;

            this.Status = transactionStatus;
            this.From = from;

            this.To = to;
            this.Amount = amount;
        }
        public int Id 
        {
            get => this.id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID cannot be negative.");
                }
                if (value == 0)
                {
                    throw new ArgumentException("ID cannot be zero.");
                }

                this.id = value;
            }
        }
        public TransactionStatus Status { get; set; }
        public string From 
        {
            get => this.from;
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException("Sender cannot be null or empty.");
                }

                this.from = value;
            }
        }
        public string To
        {
            get => this.to;
            set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException("Receiver cannot be null or empty.");
                }

                this.to = value;
            }
        }
        public double Amount 
        {
            get => this.amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount cannot be less than zero.");
                }

                if (value == 0)
                {
                    throw new ArgumentException("Amount cannot be zero.");
                }

                this.amount = value;
            } 
        }
    }
}
