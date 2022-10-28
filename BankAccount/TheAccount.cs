using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class TheAccount
    {
        public int accountNumber;
        private double accountBalance;
        private string accountName;
        public static int numberOfAccounts=0;
        public TheAccount() //default constructor
        {
         accountNumber = 0000;
         accountBalance = 0.00;
         accountName = "Unknown";
         numberOfAccounts=numberOfAccounts+1;
          
        }
        public TheAccount(string accountName ,int accountNumber, double accountBalance)// parameterized constructor
        {
            this.accountNumber = accountNumber;
            this.accountBalance = accountBalance;
            this.accountName = accountName;
            numberOfAccounts = numberOfAccounts + 1;

        }
        public int  AccountNumber{
            get { return this.accountNumber; }
            set{this.accountNumber=value;}
             }
        public double AccountBalance
        {
            get { return this.accountBalance; }
            set { this.AccountBalance= value; }
        }
        public string AccountName
        {
            get { return this.accountName; }
            set { this.accountName= value; }
        }
        public void DepostFunds(double Amount)
        {
            this.accountBalance = accountBalance + Amount;
        }
        public void WithdrawFunds(double Amount)
        {
            if (Amount > accountBalance) // making sure withdraw is not more than balance
            {
                Console.WriteLine("Withdraw transaction failed...");
                Console.WriteLine("Amount greater than balance");
               
            }
            else
            {
                Console.WriteLine("Withdraw transactionsucceeded..");
                this.accountBalance = accountBalance - Amount;
            }
    }
        public void TransferFunds(TheAccount anotherAccount, double amount)
        {
            this.WithdrawFunds(amount);
            anotherAccount.DepostFunds(amount);
        }
        public void DisplayAccount()
        {
            Console.WriteLine("Account Name: {0}", accountName);
            Console.WriteLine("Account Number: {0}", accountNumber);
            Console.WriteLine("Account Balance: MWK{0:N2}", accountBalance);
           

        }
        static int getNumberOfAccounts()
        {
            return numberOfAccounts;
            }
    }
}
