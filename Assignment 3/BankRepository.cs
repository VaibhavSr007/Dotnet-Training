
using System.Data.Common;
using bank.Models;

namespace bank
{
    class AccountNotFoundException : ApplicationException{
        public AccountNotFoundException(string x):base(x){}
    }

    class LowAmtToWithdrawException : ApplicationException{
        public LowAmtToWithdrawException(string x):base(x){}
    }
    class BankRepository : IBankRepository
    {
        private static Ace52024Context db = new Ace52024Context();
        public void NewAccount(SBaccount acc)
        {
            SbAccountv sb = new SbAccountv();
            sb.AccountNumber = acc.AcountNumber;
            sb.CustomerName = acc.CustomerName;
            sb.CustomerAddress = acc.CustomerAddress;
            sb.CurrentBalance = acc.CuurentBalance;

            db.Add(sb);
            db.SaveChanges();
            
        }

        public SBaccount GetAccountDetails(int accno)
        {
            SBaccount sb = new SBaccount();
            var item = db.SbAccountvs.Where(x=>x.AccountNumber == accno).Select(x=>x).SingleOrDefault();
            if(item != null){
                sb.AcountNumber = item.AccountNumber;
                sb.CustomerName = item.CustomerName;
                sb.CustomerAddress = item.CustomerAddress;
                sb.CuurentBalance = (float)item.CurrentBalance;
                return sb;
            }
            else{
                throw new AccountNotFoundException("No Account found against the entered Account Number");
            }
        }
        
        public List<SBaccount> GetAllAccounts()
        {   
            List<SBaccount> sbl = new List<SBaccount>();

            foreach(var i in db.SbAccountvs){
                SBaccount sb = new SBaccount();
                sb.AcountNumber = i.AccountNumber;
                sb.CustomerName=i.CustomerName;
                sb.CustomerAddress=i.CustomerAddress;
                sb.CuurentBalance = (float)i.CurrentBalance;
                sbl.Add(sb);
            }

            return sbl;
        }

        public void DepositAmount(int accno, float amt)
        {
            var item = db.SbAccountvs.Where(x=>x.AccountNumber == accno).Select(x=>x).SingleOrDefault();
            item.CurrentBalance += amt;
            db.SaveChanges();

            SbTransactionv curTransaction = new SbTransactionv();

            DateTime timestamp = DateTime.Now;
            curTransaction.TransactionId = Convert.ToInt32($"{timestamp:MMddHHmmss}");
            curTransaction.TransactionDate = DateOnly.FromDateTime(DateTime.Now);
            curTransaction.AccountNumber = accno;
            curTransaction.Ammount = amt;
            curTransaction.TransactionType = "Deposit";

            db.Add(curTransaction);
            db.SaveChanges();

        }

        public void WithdrawAmount(int accno, float amt)
        {
            var item = db.SbAccountvs.Where(x=>x.AccountNumber == accno).Select(x=>x).SingleOrDefault();

            if(amt > item.CurrentBalance){
                throw new LowAmtToWithdrawException("Balance of Your account is lower than Requesed Ammount");
            }
            else{
                item.CurrentBalance -= amt;
                db.SaveChanges();

                SbTransactionv curTransaction = new SbTransactionv();

                DateTime timestamp = DateTime.Now;
                curTransaction.TransactionId = Convert.ToInt32($"{timestamp:MMddHHmmss}");
                curTransaction.TransactionDate = DateOnly.FromDateTime(DateTime.Now);
                curTransaction.AccountNumber = accno;
                curTransaction.Ammount = amt;
                curTransaction.TransactionType = "Withdraw";

                db.Add(curTransaction);
                db.SaveChanges();
            }
        }

        public List<SBTransaction> GetTransactions(int accno)
        {
            
            var sbl = db.SbTransactionvs.Where(x=>x.AccountNumber == accno).Select(x=>x).ToList();
            List<SBTransaction> l = new List<SBTransaction>();
            foreach(var i in sbl){
                SBTransaction st = new SBTransaction();

                st.AcountNumber = accno;
                st.TransactionId = i.TransactionId;
                st.Ammount= (float)i.Ammount;
                st.TransactionType = i.TransactionType;
                st.TransactionDate = (DateOnly)i.TransactionDate;

                l.Add(st);
            }

            return l;
        }
    }

}