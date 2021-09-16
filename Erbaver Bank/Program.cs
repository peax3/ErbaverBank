using System;

namespace Erbaver_Bank
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("WELCOME TO ERBAVER BANK");
			Console.WriteLine("Commands: c (Create Account), v (view Account Details), w (withdraw), d (deposit), b (Balance), x (delete Account)");

			do
			{
				Console.Write("> ");
				var input = Console.ReadLine();

				switch (input)
				{
					case "c":
						Commands.CreateAccount();
						break;

					case "v":
						Commands.ViewAccountDetails();
						break;

					case "d":
						Commands.Deposit();
						break;

					case "w":
						Commands.Withdraw();
						break;

					case "b":
						Commands.CheckBalance();
						break;

					case "x":
						Commands.DeleteAccount();
						break;

					default:
						Console.WriteLine("Unknown Command.");
						break;
				}
			} while (true);
		}
	}

	public static class Commands
	{
		private static Bank ErbaverBank = new Bank();

		public static void CreateAccount()
		{
			Console.Write("Enter Account Name: ");
			var accountName = Console.ReadLine();
			Console.Write("Enter Amount to deposit: ");
			var amount = Decimal.Parse(Console.ReadLine());
			try
			{
				var accountNumber = ErbaverBank.CreateNewAccount(accountName, amount);
				Console.WriteLine("Account Creation Successful....");
				Console.WriteLine($"Your account number is {accountNumber}");
				Console.WriteLine("---------------............--------------...................---------------");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void Deposit()
		{
			Console.Write("Enter Account Number: ");
			var accountNumber = Console.ReadLine();
			Console.Write("Enter Amount to deposit: ");
			var amount = Decimal.Parse(Console.ReadLine());
			try
			{
				ErbaverBank.Deposit(accountNumber, amount);
				Console.WriteLine("Deposit Successful");
				Console.WriteLine("---------------............--------------...................---------------");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void Withdraw()
		{
			Console.Write("Enter Account Number: ");
			var accountNumber = Console.ReadLine();
			Console.Write("Enter Amount to withdraw: ");
			var amount = Decimal.Parse(Console.ReadLine());
			try
			{
				ErbaverBank.WithDraw(accountNumber, amount);
				Console.WriteLine("Withdrawal Successful");
				Console.WriteLine("---------------............--------------...................---------------");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void CheckBalance()
		{
			Console.Write("Enter Account Number: ");
			var accountNumber = Console.ReadLine();
			try
			{
				var balance = ErbaverBank.CheckBalance(accountNumber);
				Console.WriteLine($"Your Account Balance: {balance}");
				Console.WriteLine("---------------............--------------...................---------------");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void DeleteAccount()
		{
			Console.Write("Enter Account Name: ");
			var accountName = Console.ReadLine();
			Console.Write("Enter Account Number: ");
			var accountNumber = Console.ReadLine();
			try
			{
				Console.WriteLine("Are you sure you want to delete your account (Enter y (Yes) and n (No)): ");
				var input = Console.ReadLine();
				if (input == "y")
				{
					ErbaverBank.DeleteAccount(accountName, accountNumber);
					Console.WriteLine("Your Account has been deleted.");
					Console.WriteLine("---------------............--------------...................---------------");
				}

				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public static void ViewAccountDetails()
		{
			Console.Write("Enter Account Name: ");
			var accountName = Console.ReadLine();
			Console.Write("Enter Account Number: ");
			var accountNumber = Console.ReadLine();
			try
			{
				var customer = ErbaverBank.SeeAccountDetails(accountName, accountNumber);

				Console.WriteLine($"Your Account Details: Account Name: {customer.AccountName}");
				Console.WriteLine($"                     Account Number: {customer.AccountNumber}");
				Console.WriteLine($"                     Account Number: {customer.AccountBalance}");
				Console.WriteLine("---------------............--------------...................---------------");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}