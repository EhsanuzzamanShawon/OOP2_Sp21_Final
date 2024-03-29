﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Account
    {
        public string AccName { get; set; }
        public string AccId { get; set; }
        public double Balance { get; set; }
        public int TotalNumberofTransaction { get; set; }

        private Transaction[] listofTransaction;

        public Account()
        {
            Console.WriteLine(" Account is Default");
        }
        public Account(string accName, string accId, double balance)
        {
            AccName = accName;
            AccId = accId;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("Deposit Successfully Done.");
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {

                Balance -= amount;
                Console.WriteLine("Withdraw Successfully Done.");
            }
            else
            {
                Console.WriteLine("Insufficient Balance.");
            }
        }

        public void Transfer(Account acc, double amount)
        {
            if (amount <= Balance)
            {

                Balance -= amount;
                acc.Balance += amount;
                Console.WriteLine("Balance transfered Successfully.");
            }
            else
            {
                Console.WriteLine("Transfer cannot be done.Insufficient Balance.");
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            listofTransaction[TotalNumberofTransaction++] = transaction;
        }
        public void ShowAllTransactions()
        {
            for (int i = 0; i < (TotalNumberofTransaction + 1); i++)
            {
                listofTransaction[i].showInfo();
            }
        }

        virtual public void showInfo()
        {
            Console.WriteLine("Acc Name: " + AccName);
            Console.WriteLine("Acc No: " + AccId);
            Console.WriteLine("Balance: " + Balance);
        }
    }
}
