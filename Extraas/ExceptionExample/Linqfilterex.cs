namespace exceptionex{

    class Linqfilterex{

        public static void Main(){

            // int []a = {1,2,3,4,5,6,7,8,9,10};

            // Console.WriteLine("All Numbers");
            // foreach(int i in a){
            //     Console.WriteLine(i);
            // }

            // // this is the SQL way of quering the data in c#
            // var evnum = (from i in a
            //              where i%2==0
            //              select i).ToList(); // .to list ca be done to be more specific
            
            // Console.WriteLine("Even Numbers Display Got by Query Syntax Method");
            // foreach(var i in evnum){
            //     Console.WriteLine(i);
            // }

            // // this is the method based way of querying the data in c# (Involves Lambda expressions)
            // var evnnum = a.Where(x=> x%2==0).Select(x=>x).ToList(); // .to list ca be done to be more specific
            // Console.WriteLine("Even Numbers Display Got by Method Syntax Method");
            // foreach(var i in evnnum){
            //     Console.WriteLine(i);
            // }



            // another example of above.
            List<string> cities = new List<string>();
            cities.Add("Calcuta");
            cities.Add("Chennai");
            cities.Add("Mumbai");
            cities.Add("Lucknow");
            cities.Add("Calicut");
            

            Console.WriteLine("All Cities");
            foreach(string s in cities){
                Console.WriteLine(s);
            }

            var citywithc = (from city in cities
                            where city.StartsWith('C')
                            select city);

            Console.WriteLine("Cities with c from query syntax");
            foreach(string s in citywithc){
                Console.WriteLine(s);
            }

            var CityWithc = cities.Where(x=> x.StartsWith('C')).Select(x=>x);

            Console.WriteLine("Cities with c from Method syntax");
            foreach(string s in CityWithc){
                Console.WriteLine(s);
            }



            // we use single or default when we expect single entity output from query (other part in collections.cs on Friday)
            var CityCalicut = cities.Where(x=> x == "Calicut").Select(x=>x).SingleOrDefault();
            var cityMumbai = (from i in cities where i == "Mumbai" select i).SingleOrDefault();
            Console.WriteLine("Cities named Calicut");
            Console.WriteLine(CityCalicut);

            Console.WriteLine("Cities named Mumbai");
            Console.WriteLine(cityMumbai);

        }
    }
}