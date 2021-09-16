using System;
using System.Collections.Generic;
using System.Text;

namespace Erbaver_Bank
{
	public class Bank
	{
		private List<Customer> _customers;
		private const decimal _minBalance = 2000;
		private const decimal _maxBalance = 1000000;

		public Bank()
		{
			_customers = new(5);
		}

		public string CreateNewAccount(string accountName, decimal amount)
		{
			if (_customers.Count == 5)
			{
				throw new IndexOutOfRangeException("Sorry! We are not accepting new customers at this time");
			}

			ValidateAccountBalance(amount);

			var customer = new Customer()
			{
				AccountNumber = GenerateAccountNumber(),
				AccountBalance = amount,
				AccountName = accountName,
			};

			_customers.Add(customer);
			return customer.AccountNumber;
		}

		public void Deposit(string accountNumber, decimal amount)
		{
			if (amount < 0)
			{
				throw new Exception("Invalid Amount");
			}

			var customer = FindCustomer(accountNumber);
			var newAccountBalance = customer.AccountBalance + amount;
			ValidateAccountBalance(newAccountBalance);

			customer.AccountBalance = newAccountBalance;
		}

		public void WithDraw(string accountNumber, decimal amount)
		{
			if (amount < 0)
			{
				throw new Exception("Invalid Amount");
			}

			var customer = FindCustomer(accountNumber);
			var newAccountBalance = customer.AccountBalance - amount;
			ValidateAccountBalance(newAccountBalance);

			customer.AccountBalance = newAccountBalance;
		}

		public decimal CheckBalance(string accountNumber)
		{
			var customer = FindCustomer(accountNumber);
			return customer.AccountBalance;
		}

		public Customer SeeAccountDetails(string accountName, string accountNumber)
		{
			var customer = FindCustomer(accountNumber);
			if (customer.AccountName != accountName)
			{
				throw new Exception("You are not allowed to view this account details");
			}
			return customer;
		}

		public void DeleteAccount(string accountName, string accountNumber)
		{
			var customer = FindCustomer(accountNumber);
			if (customer.AccountName != accountName)
			{
				throw new Exception("You are not allowed to view this account details");
			}
			_customers.Remove(customer);
		}

		private static void ValidateAccountBalance(decimal amount)
		{
			if (amount < _minBalance || amount > _maxBalance)
			{
				throw new Exception($"Account Balance cannot be less than {_minBalance} and more than {_maxBalance}");
			}
		}

		private static string GenerateAccountNumber()
		{
			int accountNumLength = 10;
			Random random = new Random();
			var accountNumber = new StringBuilder(accountNumLength);
			for (int i = 0; i < accountNumLength; i++)
			{
				accountNumber.Append(random.Next(10));
			}

			return accountNumber.ToString();
		}

		private Customer FindCustomer(string accountNumber)
		{
			var customer = _customers.Find(c => c.AccountNumber == accountNumber);
			if (customer != null)
			{
				return customer;
			}

			throw new Exception("No customer with this account number");
		}
	}
}