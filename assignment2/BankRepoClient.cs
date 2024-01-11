namespace assignment2{

    class BankRepoClient{

        public static void Main(){

            IBankRepository cust = new BankRepository();

            cust.NewAccount(new SBaccount(1, "vai", "UP, India", 100000)); //1
            cust.DepositAmount(1, 100000);  // 2
            cust.WithdrawAmount(1,50000);   // 3
            SBaccount AccEx = cust.GetAccountDetails(1);     // 4
            Console.WriteLine(AccEx.AcountNumber + " " + AccEx.CustomerName + " " + AccEx.CuurentBalance + " " + AccEx.CustomerAddress);

            cust.NewAccount(new SBaccount(2, "raj", "Mp, India", 1000));
            cust.NewAccount(new SBaccount(3, "sai", "Ap, India", 50000));
            
            List<SBaccount> AllAccnts = cust.GetAllAccounts();  // 5
            foreach(SBaccount i in AllAccnts){
                Console.WriteLine(i.AcountNumber + " " + i.CustomerName + " " + i.CuurentBalance + " " + i.CustomerAddress);
            }

            List<SBTransaction> AllTransactions = cust.GetTransactions(1);  // 6
            foreach(SBTransaction i in AllTransactions){
                Console.WriteLine(i.TransactionId + " " + i.TransactionDate + " " + i.TransactionType + " " + i.Ammount + " " + i.AcountNumber);
            }


        }
    }
}