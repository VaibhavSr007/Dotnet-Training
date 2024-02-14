namespace exceptionex{

    class AgeNotValidException : ApplicationException{

        public AgeNotValidException(string Message):base(Message){} // this helps us to override the error message of base class and define our own error in the derived class (like we have done in Voting Class)
    }

    class AgeLessThanZeroException : ApplicationException{

        public AgeLessThanZeroException(string Message):base(Message){} // this helps us to override the error message of base class and define our own error in the derived class (like we have done in Voting Class)
    }

    class Voting{
        
        int Age{get; set;}

        public void AgeCheck(int age){
            if(age >= 0 && age < 18){
                throw new AbandonedMutexException("Sorry you are not Eligible to Vote!!");
            }
            if(age >= 18 ){
                Console.WriteLine("You are eligible to Vote");
            }
            else{
                throw new AgeLessThanZeroException("Sorry, You entered age less than 0!!");
            }
        }

    }

    class VotingClient{

        public static void main(){

            try{
                int age;
                Voting v = new Voting();
                Console.WriteLine("Enter your age to Vote");
                age = Convert.ToInt32(Console.ReadLine());
                // int.TryParse(Console.ReadLine(), out age);
                v.AgeCheck(age);
            }
            catch (AgeNotValidException e){
                Console.WriteLine(e.Message);
            }
            finally{
                Console.WriteLine("Thanks for visiting");
            }
        }
    }
}