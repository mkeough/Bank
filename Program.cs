using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Bank
{
  class Program
  {

    static void Main(string[] args)
    {

      var transactions = new AccountManagement();
      transactions.LoadAccounts();
      transactions.SaveAccounts();



      // var reader = new StreamReader("transactions.csv");
      // var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      // transactions = csvReader.GetRecords<Account>().ToList();
      var isRunning = true;
      while (isRunning)
      {
        foreach (var a in transactions.Accounts)
        {
          Console.WriteLine($"{a.AccountType} has a balance of {a.AccountBalance}");
        }

        Console.WriteLine("Welcome to The Bank");
        Console.WriteLine("");
        Console.WriteLine("How may we help you?");
        Console.WriteLine("");
        Console.WriteLine("Please choose from one of the following");
        Console.WriteLine("");
        Console.WriteLine("Make a (Deposit)");
        Console.WriteLine("");
        Console.WriteLine("Make a (Withdraw)");
        Console.WriteLine("");
        Console.WriteLine("(Transfer) money between account");
        Console.WriteLine("");
        Console.WriteLine("(View) balances");
        Console.WriteLine("");
        Console.WriteLine("(Quit)");
        var input = Console.ReadLine().ToLower();

        if (input == "deposit")
        {
          Console.WriteLine("Which account would you like to deposit into (checking) or (savings)?");
          var accountType = Console.ReadLine().ToLower();
          Console.WriteLine("How much would you like to deposit");
          var amount = double.Parse(Console.ReadLine());
          transactions.DepositMoney(accountType, amount);
          Console.WriteLine("Thank you for your Business");
        }
        else if (input == "withdraw")
        {
          Console.WriteLine("Which account would you like to make a withdraw from (checking) or (saving)");
          var accountType = Console.ReadLine().ToLower();
          Console.WriteLine("How much would you like to withdraw");
          var amount = double.Parse(Console.ReadLine());
          transactions.WithdrawMoney(accountType, amount);


        }

        else if (input == "transfer")
        {
          Console.WriteLine("where would you like to transfer the money from (checking) or (savings)");
          var accountTypeA = Console.ReadLine().ToLower();
          Console.WriteLine("How much money would you like to transfer");
          var amount = double.Parse(Console.ReadLine());
          Console.WriteLine("Where would you like to tranfer money to (checking) or (savings)");
          var accountTypeB = Console.ReadLine().ToLower();
          transactions.TransferMoney(accountTypeA, accountTypeB, amount);


        }
        else if (input == "view")
        {
          foreach (var a in transactions.Accounts)
          {
            Console.WriteLine($"{a.AccountType} has a balance of {a.AccountBalance}");
          }
        }

        else if (input == "quit")
        {
          isRunning = false;
        }

      }










    }
  }
}
