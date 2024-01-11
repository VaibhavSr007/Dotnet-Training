
namespace assignment2
{
    

    class BankRepository : IBankRepository
    {
        Dictionary<int,SBaccount> saveAcc = new Dictionary<int, SBaccount>();
        Dictionary<int ,List<SBTransaction>> saveTra = new Dictionary<int, List<SBTransaction>>();
        List<SBaccount> AllAccnts = new List<SBaccount>();

        public void NewAccount(SBaccount acc)
        {
            saveAcc.Add(acc.AcountNumber, acc);
            AllAccnts.Add(acc);

            SBTransaction curTransaction = new SBTransaction();

            curTransaction.TransactionId = 1;
            curTransaction.TransactionDate = DateTime.Now;
            curTransaction.AcountNumber = acc.AcountNumber;
            curTransaction.Ammount = saveAcc[acc.AcountNumber].CuurentBalance;
            curTransaction.TransactionType = "New Account";

            // saveTra[acc.AcountNumber] = {curTransaction};
            saveTra[acc.AcountNumber] = [curTransaction];
            
        }

        public SBaccount GetAccountDetails(int accno)
        {
            if(saveAcc.ContainsKey(accno)){
                return saveAcc[accno];
            }
            else{
                throw new NotImplementedException();
            }
        }

        public List<SBaccount> GetAllAccounts()
        {
            return AllAccnts;
        }

        public void DepositAmount(int accno, float amt)
        {
            saveAcc[accno].CuurentBalance += amt;

            SBTransaction curTransaction = new SBTransaction();

            curTransaction.TransactionId = saveTra[accno].Count + 1;
            curTransaction.TransactionDate = DateTime.Now;
            curTransaction.AcountNumber = accno;
            curTransaction.Ammount = amt;
            curTransaction.TransactionType = "Deposit";

            saveTra[accno].Add(curTransaction);
        }

        public void WithdrawAmount(int accno, float amt)
        {
            saveAcc[accno].CuurentBalance -= amt;

            SBTransaction curTransaction = new SBTransaction();

            curTransaction.TransactionId = saveTra[accno].Count + 1;
            curTransaction.TransactionDate = DateTime.Now;
            curTransaction.AcountNumber = accno;
            curTransaction.Ammount = amt;
            curTransaction.TransactionType = "Withdraw";

            saveTra[accno].Add(curTransaction);
        }



        public List<SBTransaction> GetTransactions(int accno)
        {
            return saveTra[accno];
        }

    }
}