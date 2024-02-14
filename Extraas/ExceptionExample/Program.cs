
using System.Transactions;

namespace exceptionex{

    class Program{

        public static void main(){

            int a, b, res = 0;

            try{

                Console.WriteLine("Enter two integers :");
                a = Convert.ToInt32(Console.ReadLine());
                b = Convert.ToInt32(Console.ReadLine());
                res = a/b;
            }
            catch(DivideByZeroException){
                Console.WriteLine("Second Integer must be non zero");
            }
            catch(FormatException){
                Console.WriteLine("Both must be integers and not null");
            }
            catch(Exception e){
                Console.WriteLine("Error is: " + e.Message);
            }
            finally{
                Console.WriteLine("Result is: " + res);
            }
        }
    }
}
