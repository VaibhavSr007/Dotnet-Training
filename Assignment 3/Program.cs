// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System.Data.Common;
using bank.Models; 
namespace bank{


    public class Program{

        private static Ace52024Context db = new Ace52024Context();
        public static void Main(){
            Console.WriteLine("");

            IBankRepository cust = new BankRepository();

            Console.WriteLine("Please refer the below options:");
            Console.WriteLine("To Add New Account: Press 1");
            Console.WriteLine("To Deposit Ammount: Press 2");
            Console.WriteLine("To Withdraw Ammount: Press 3");
            Console.WriteLine("To get Your Account Details: Press 4");
            Console.WriteLine("To get All Accounts Details: Press 5");
            Console.WriteLine("To get All Your Transaction Details: Press 6");
            Console.WriteLine("To Exit: Press 7");
            
            int value = Convert.ToInt32(Console.ReadLine());


            if(value == 1){
                Console.WriteLine("Enter new account number: ");
                int accno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter account Holders name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter account Holders Address: ");
                string address = Console.ReadLine();
                Console.WriteLine("Enter the Initial Ammount in Account: ");
                int ammnt =  Convert.ToInt32(Console.ReadLine());

                cust.NewAccount(new SBaccount(accno, name, address, ammnt));
            }
            else if(value == 2){
                Console.WriteLine("Enter your account number: ");
                int accno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Account to be Deposited: ");
                int ammnt =  Convert.ToInt32(Console.ReadLine());
                cust.DepositAmount(accno, ammnt);
            }
            else if(value == 3){
                Console.WriteLine("Enter your account number: ");
                int accno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Account to be Withdrawn: ");
                int ammnt =  Convert.ToInt32(Console.ReadLine());
                cust.WithdrawAmount(accno, ammnt);
            }
            else if(value == 4){
                Console.WriteLine("Enter your account number: ");
                int accno = Convert.ToInt32(Console.ReadLine());

                SBaccount AccEx = cust.GetAccountDetails(accno);
                Console.WriteLine(AccEx.AcountNumber + " " + AccEx.CustomerName + " " + AccEx.CuurentBalance + " " + AccEx.CustomerAddress);
            }
            else if(value == 5){
                List<SBaccount> AllAccnts = cust.GetAllAccounts();

                foreach(SBaccount i in AllAccnts){
                    Console.WriteLine(i.AcountNumber + " " + i.CustomerName + " " + i.CuurentBalance + " " + i.CustomerAddress);
                }
            }
            else if(value == 6){
                Console.WriteLine("Enter your account number: ");
                int accno = Convert.ToInt32(Console.ReadLine());

                List<SBTransaction> AllTransactions = cust.GetTransactions(accno);
                foreach(SBTransaction i in AllTransactions){
                    Console.WriteLine(i.TransactionId + " " + i.TransactionDate + " " + i.TransactionType + " " + i.Ammount + " " + i.AcountNumber);
                }
            }
            else if(value == 7){
                return ;
            }
            else{
                return ;
            }



            // ********* MANUAL FUNCTIONALITIES FOR TESTING ************

            // New Account Add 
            // SBaccount sb = new SBaccount(4,"Sai", "AP, India", 3500000);
            // cust.NewAccount(sb);

            // Get specific account detail
            // SBaccount item = cust.GetAccountDetails(1);
            // Console.WriteLine(item.CustomerName + " " + item.AcountNumber + " " + item.CustomerAddress + " " + item.CuurentBalance);   
            
            // Get all Account Details
            // List<SBaccount> sbl = cust.GetAllAccounts();
            // foreach(var item in sbl){
            //     Console.WriteLine(item.CustomerName + " " + item.AcountNumber + " " + item.CustomerAddress + " " + item.CuurentBalance);
            // }

            // Deposit
            // cust.DepositAmount(1,50000);

            // Withdraw
            // cust.WithdrawAmount(1,25000);

            // All transactions
            // List<SBTransaction> sbt = cust.GetTransactions(1);
            // foreach(var i in sbt){
            //     Console.WriteLine(i.TransactionType + " " + i.TransactionId + " " + i.Ammount + " " + i.TransactionDate + " " + i.AcountNumber);
            // }
            
            // Display();
        }
    }
}
