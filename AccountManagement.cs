using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace Bank
{
  public class AccountManagement
  {

    public List<Account> Accounts { get; set; } = new List<Account>();

    public void SaveAccounts()
    {
      using (var writer = new StreamWriter("Accounts.csv"))
      using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
      {
        csvWriter.WriteRecords(Accounts);
        writer.Flush();
      }
    }

    public void LoadAccounts()
    {
      using (var reader = new StreamReader("Accounts.csv"))
      using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
      {
        Accounts = csvReader.GetRecords<Account>().ToList();
      }


    }


    public void DepositMoney(string accountType, double amount)
    {
      Accounts.Find(account => account.AccountType == accountType).AccountBalance += amount;
      SaveAccounts();
    }

    public void WithdrawMoney(string accountType, double amount)
    {
      Accounts.Find(account => account.AccountType == accountType).AccountBalance -= amount;
      SaveAccounts();
    }

    public void TransferMoney(string accountTypeA, string accountTypeB, double amount)
    {
      Accounts.Find(account => account.AccountType == accountTypeA).AccountBalance -= amount;
      Accounts.Find(account => account.AccountType == accountTypeB).AccountBalance += amount;
      SaveAccounts();
    }


  }


}
