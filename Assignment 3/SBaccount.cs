namespace bank{

    public class SBaccount{
        public int AcountNumber{get;set;}
        public string? CustomerName{get;set;}
        public string? CustomerAddress{get;set;}
        public float CuurentBalance{get;set;}

        public SBaccount(){}

        public SBaccount(int accNo, string cusName, string custAdd, float curBal){
            AcountNumber = accNo;
            CustomerName = cusName;
            CustomerAddress = custAdd;
            CuurentBalance = curBal;
        }

    }

    public class SBTransaction{
        public int TransactionId{get;set;}
        public DateOnly TransactionDate{get; set;}
        public int AcountNumber{get;set;}
        public float Ammount{get; set;}
        public string? TransactionType{get; set;}

    }
}