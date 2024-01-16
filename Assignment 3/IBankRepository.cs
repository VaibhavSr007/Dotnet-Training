namespace bank{

    
    public interface IBankRepository{
        void NewAccount(SBaccount acc);
        List<SBaccount> GetAllAccounts();
        SBaccount GetAccountDetails(int accno);
        void DepositAmount(int accno, float amt);
        void WithdrawAmount(int accno, float amt);
        List<SBTransaction> GetTransactions(int accno);
    }
}