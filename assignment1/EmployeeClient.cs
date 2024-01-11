namespace assignment1{

    class EmployeeClient{

        public static void Main(){

            // for a Permenant Employee
            Permenant p = new Permenant();

            p.AcceptDetails(); // displays common info of employee
            p.DisplayDetails(); // from base class methods
            p.GetDetails(); // accepts details of permenant employees 
            p.CalculateSalary(); // from derived class methods
            p.ShowDetails();


            // for a Trainee Employee
            Trainee t = new Trainee();

            t.AcceptDetails(); // displays common info of trainee
            t.DisplayDetails(); // from base class methods
            t.GetTraineeDetails(); // accepts details of trainee employees 
            t.CalculateSalary(); // from derived class methods
            t.ShowTraineeDetails();
        }

    }
}