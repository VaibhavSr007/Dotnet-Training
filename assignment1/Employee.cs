namespace assignment1{

    class Employee{

        public int Empid{get; set;}
        public string? Empname{get; set;}
        public float Salary{get; set;}
        public DateTime DOJ{get; set;}

        public void AcceptDetails(){
            Console.WriteLine("Enter the Employee ID: ");
            Empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name: ");
            Empname = Console.ReadLine();
            Console.WriteLine("Enter the Employee Base Salary: ");
            Salary = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Date of Joining: ");
            DOJ = Convert.ToDateTime(Console.ReadLine());
        }

        public void DisplayDetails(){
            Console.WriteLine($"Employee ID: {Empid}");
            Console.WriteLine($"Employee Name: {Empname}");
            Console.WriteLine($"Employee Base Salary: {Salary}");
            Console.WriteLine($"Employee DOJ: {DOJ}");
            Console.WriteLine();
        }

        public virtual void CalculateSalary(){
            Console.WriteLine("Base Salary of employee (NOT GROSS SALARY) is :" + Salary);
        }

    }

    class Permenant:Employee{

        public float Basicpay{get; set;}
        public float Hra{get; set;}
        public float Da{get; set;}
        public float Pf{get; set;}

        public void GetDetails(){
            Console.WriteLine("Enter the Employee Basic Pay: ");
            Basicpay = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee HRA: ");
            Hra = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee DA: ");
            Da = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Employee PF: ");
            Pf = float.Parse(Console.ReadLine());
        }

        public override void CalculateSalary(){
            Salary = Basicpay + Hra + Da - Pf;
        }

        public void ShowDetails(){
            Console.WriteLine($"Employee Basic Pay: {Basicpay}");
            Console.WriteLine($"Employee HRA: {Hra}");
            Console.WriteLine($"Employee DA: {Da}");
            Console.WriteLine($"Employee PF: {Pf}");
            Console.WriteLine($"Employee Gross Salary is: {Salary}");
            Console.WriteLine();
        }

    }

    class Trainee:Employee{

        public string? ProjectName{get; set;}
        public float Bonus{get; set;}

        public void GetTraineeDetails(){
            Console.WriteLine("Enter the Trainee's Project Name: ");
            ProjectName = Console.ReadLine();
        }

        public override void CalculateSalary(){

            if(String.Equals(ProjectName,"Banking")){
                Bonus = (float)(Salary*0.05);
                Salary = Salary + Bonus;
            }
            else if(String.Equals(ProjectName,"Insurance")){
                Bonus = (float)(Salary*0.1);
                Salary = Salary + Bonus;
            }
            else{
                Bonus = 0;
            }

        }

        public void ShowTraineeDetails(){
            Console.WriteLine("Trainee's Bonus: " + Bonus);
            Console.WriteLine("Trainee's Project Name: " + ProjectName);
            Console.WriteLine($"Trainee's Gross Salary is: {Salary}");
            Console.WriteLine();
        }
    }
}