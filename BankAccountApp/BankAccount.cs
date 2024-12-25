using System;

namespace BankAccountApp
{
    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public double Balance { get; private set; }

        public BankAccount(string accountNumber, double balance = 0)
        {
            if (balance < 0) throw new ArgumentException("Initial balance cannot be negative.");
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Deposit amount must be greater than zero.");
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0) throw new ArgumentException("Withdrawal amount must be greater than zero.");
            if (amount > Balance) throw new InvalidOperationException("Insufficient funds.");
            Balance -= amount;
        }

        public double GetBalance()
        {
            return Balance;
        }
    }
}
