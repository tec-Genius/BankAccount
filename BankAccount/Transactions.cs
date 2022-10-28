using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Transactions
    {
        static string accName;
        static int accNumber;
        static double accBalance;
        private static int accountsSize = 20;
        static TheAccount[] accounts = new TheAccount[accountsSize];
        public static void CreateAccount()
        {
            string x;
            int available = 0;
            do
            {


                Console.WriteLine("Enter account name:");
                accName = Console.ReadLine();
                Console.WriteLine("Enter account number:");
                accNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter account  balance:");
                accBalance = double.Parse(Console.ReadLine());

                accounts[available] = new TheAccount(accName, accNumber, accBalance);
                Console.WriteLine("{0} Created Successifully: \n Account Name:{0}\n Account Number:{2} \n Account Balance:{1:N2}", accounts[available].AccountName, accounts[available].AccountBalance, accounts[available].AccountNumber);
                available=available+1;
                Console.WriteLine("Do you want to create another account?(y / n)");
                x = Console.ReadLine();
            } while ((x == "y") || (x == "Y"));


        }
        
       
        private static void WithdrawFunds(int selectedAccount)
        {
            double amounts;
            Console.WriteLine("Withdraw ACCOUNT NAME:{0:5}\n Balance:{1:N2}", accounts[selectedAccount].AccountName, accounts[selectedAccount].AccountBalance);
            Console.WriteLine("Enter amount to withdraw");
            amounts = double.Parse(Console.ReadLine());
            accounts[selectedAccount].WithdrawFunds(amounts);
            Console.WriteLine("Amount withdrawn:{0:N2}", amounts);
            Console.WriteLine("Balance:{0:N2}", accounts[selectedAccount].AccountBalance);
            Console.WriteLine("THANK YOU FOR USING THIS ATM");
        }
       
        private static void DoTransferFunds(int selectedAccount)
        {
            double transferAmount;
            int selectedTargetAccount;
        Console.WriteLine("Please select an account to transfer funds to:");
        for (int acc = 0; acc < TheAccount.numberOfAccounts; acc++)
        {
            Console.WriteLine("{0}.{1}", acc + 1, accounts[acc].AccountName);
        }
       selectedTargetAccount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount to transfer:");
            transferAmount= double.Parse(Console.ReadLine());
            selectedTargetAccount = selectedTargetAccount - 1; ;
            if (accounts[selectedAccount].AccountName == accounts[selectedTargetAccount].AccountName)
            {
                Console.WriteLine("You cant transfer  funds to the same account, please select a different account");
                DoTransferFunds(selectedAccount);
            }
            else
            {
                accounts[selectedAccount].TransferFunds(accounts[selectedTargetAccount], transferAmount);
                Console.WriteLine("\nTransaction succeded...\n");
                Console.WriteLine("{0:5} Account Balance after transfer:{1:N2}", accounts[selectedAccount].AccountName, accounts[selectedAccount].AccountBalance);
                Console.WriteLine("{0:5}Account Balance after credited:{1:N2}", accounts[selectedTargetAccount].AccountName, accounts[selectedTargetAccount].AccountBalance);
            }
            }
        private static void DoDepostFunds(int selectedAccount)
        {
            double depositAmount;
            Console.WriteLine("Account name:{0},Balance:{1}", accounts[selectedAccount].AccountName,accounts[selectedAccount].AccountBalance);
            Console.WriteLine("Enter amount to deposit");
            depositAmount = double.Parse(Console.ReadLine());
            accounts[selectedAccount].DepostFunds(depositAmount);
            Console.WriteLine("Transaction succeded");
            Console.WriteLine("Balance after transaction:{0:N2}",accounts[selectedAccount].AccountBalance);
        }
        private static void CheckBalance(int selectedAccount)
        {
            Console.WriteLine("Account Name:{0}", accounts[selectedAccount].AccountName);
            Console.WriteLine("Account Balance:{0:N2}", accounts[selectedAccount].AccountBalance);

        }
        private static void DoTransaction(int selectedAccount, int selectedTransaction)
        {
            switch(selectedTransaction)
            {
                case 2:
                WithdrawFunds(selectedAccount);
                break;
                case 3:
                DoTransferFunds(selectedAccount);
                break;
                case 4:
                DoDepostFunds(selectedAccount);
                break;
                case 5:
                CheckBalance(selectedAccount);
                break;
                default:
                Console.WriteLine("Please select option from the menu");
                break;
        }
        }
        public static string getTag(int tag)
        {
            string tagName;
            if (tag == 2)
                tagName = "withdraw funds";
            else if (tag == 3)
                tagName = "transfer funds";
            else if (tag == 4)
                tagName = "deposit funds";
            else
                tagName = "check balance";
            return tagName;
        }
        public static void DisplayAccounts(int transactionOption)
        {
            int selectedAccount;
            string transactionName = getTag(transactionOption);
           
            if (accounts[0] == null)
            {
                Console.WriteLine("No account created yet, please create an account first");
            }
            else
            {
                Console.WriteLine("Please select an account to {0} ", transactionName);
                for (int acc = 0; acc < TheAccount.numberOfAccounts; acc++)
                {
                    Console.WriteLine("{0}.{1}", acc + 1, accounts[acc].AccountName);
                }
                selectedAccount = int.Parse(Console.ReadLine());
                selectedAccount = selectedAccount - 1;
                DoTransaction(selectedAccount, transactionOption);
       
            }
        }
        
       public  static void DisplayMenu()
        {
            int option;
            Console.WriteLine("******************************************");
            Console.WriteLine("Press 1. To create an account");
            Console.WriteLine("Press 2. To withdraw funds");
            Console.WriteLine("Press 3. To transfer funds");
            Console.WriteLine("Press 4. To Deposit funds");
            Console.WriteLine("Press 5. check balance");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    CreateAccount();
                    DisplayMenu();
                    break;
                case 2:
                    DisplayAccounts(2);//withdraw funds
                    DisplayMenu();
                    break;
                case 3:
                   DisplayAccounts(3);//transfer funds
                    DisplayMenu();
                    break;
                case 4:
                   DisplayAccounts(4);//deposit funds
                    DisplayMenu();
                    break;
                case 5:
                    DisplayAccounts(5);//check balance
                    DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Please select an option from the menu");
                    DisplayMenu();
                    break;
            }
            Console.ReadKey();

        }
      

    }
}
