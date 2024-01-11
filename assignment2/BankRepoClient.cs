namespace assignment2{

    class BankRepoClient{

        public static void Main(){
            Console.WriteLine("Please refer the below options:");
            Console.WriteLine("To Add New Account: Press 1");
            Console.WriteLine("To Deposit Ammount: Press 2");
            Console.WriteLine("To Withdraw Ammount: Press 3");
            Console.WriteLine("To get Your Account Details: Press 4");
            Console.WriteLine("To get All Accounts Details: Press 5");
            Console.WriteLine("To get All Your Transaction Details: Press 6");
            Console.WriteLine("To Exit: Press 7");

            int value = Convert.ToInt32(Console.ReadLine());
            
            IBankRepository cust = new BankRepository();

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

            // for manual examples
            
            cust.NewAccount(new SBaccount(1, "vai", "Up, India", 100000)); //1
            cust.DepositAmount(1,100000);  // 2
            cust.WithdrawAmount(1,50000);  // 3
            SBaccount Acc = cust.GetAccountDetails(1); // 4
            Console.WriteLine(Acc.AcountNumber + " " + Acc.CustomerName + " " + Acc.CuurentBalance + " " + Acc.CustomerAddress);

            cust.NewAccount(new SBaccount(2, "raj", "Mp, India", 1000));
            cust.NewAccount(new SBaccount(3, "sai", "Ap, India", 50000));

            List<SBaccount> AllAcnts = cust.GetAllAccounts(); // 5
            foreach(SBaccount i in AllAcnts){
                Console.WriteLine(i.AcountNumber + " " + i.CustomerName + " " + i.CuurentBalance + " " + i.CustomerAddress);
            }

            List<SBTransaction> AllTrans = cust.GetTransactions(1);
            foreach(SBTransaction i in AllTrans){
                Console.WriteLine(i.TransactionId + " " + i.TransactionDate + " " + i.TransactionType + " " + i.Ammount + " " + i.AcountNumber);
            }
            

        }
    }
}