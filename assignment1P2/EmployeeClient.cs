namespace assignment1P1{

    class EmployeeClient{

        public static void Main(){

            IEmployee p = new Permanent();

            p.AcceptDetails();
            p.DisplayDetails();
            p.GetDetails();
            p.CalculateSalary();
            p.ShowDetails();


            IEmployee t = new Trainee();

            t.AcceptDetails();
            t.DisplayDetails();
            t.GetDetails();
            t.CalculateSalary();
            t.ShowDetails();
        }
    }
}