using System; // fixed using clause by placing using to precede all other elements in namespace
using System.Collections.Generic; // placed a missing semicolon
using System.Threading;

namespace ProblematicProblem // compiler couldn't resolve ProblematicProblem because it was missing the namespace
{
    public class Problem // corrected syntax that placed method name where public should be and placed name after class
    {
        public static Random Rng = new Random(); // fixed field by assigning the correct keywords and a value, and refactored a new name syntax
        public static bool cont = true; // added correct keywords, and refactored a new name 

        public static List<string> _activities = new List<string>() // changed list from private to public
        { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" }; // placed missing semicolon
        
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: "); // placed missing semicolon
            var userResponse = Console.ReadLine().ToLower(); // replaced bool cont with variable to check user response
            while (userResponse == "yes" && userResponse == "no")
            {
                Console.WriteLine("Invalid response. Please type yes or no");
                userResponse = Console.ReadLine().ToLower();
            }
            if (userResponse == "no")
            {
                Console.WriteLine("GoodBye");
                return;
            }
            
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            while (!int.TryParse(Console.ReadLine(), out userAge)) // added .Parse method to fix unit conversion error and operator error in line 74
            {
                Console.Write("Invalid response. Please enter valid age.");
            }
            
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");

            userResponse = Console.ReadLine().ToLower();

            while (userResponse != "sure" && userResponse != "no thanks")
            {
                Console.WriteLine("Invalid response, please type sure/no thanks.");
            }
            
            if (userResponse == "sure")
            {
                foreach (string activity in _activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250); 
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userResponse = Console.ReadLine().ToLower(); // type and declaration error on line 51

                while (userResponse != "yes" && userResponse != "no")
                {
                    Console.WriteLine("Invalid response, please write yes/no.");
                    userResponse = Console.ReadLine().ToLower();
                }
                
                Console.WriteLine();
                while (userResponse == "yes")
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    _activities.Add(userAddition);
                foreach (string activity in  _activities) // added missing in 
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.WriteLine("Would you like to add more? yes/no: ");
                userResponse = Console.ReadLine().ToLower();

                while (userResponse != "yes" && userResponse != "no")
                {
                    Console.WriteLine("Invalid response, please write yes/no.");
                    userResponse = Console.ReadLine().ToLower();
                }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine(); // missing semicolon
                Console.Write("Choosing your random activity");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(". ");
                Thread.Sleep(500);
            }

            Console.WriteLine();
            int randomNumber = Rng.Next(_activities.Count); // fixed conflicting declaration in line 79
            string randomActivity = _activities[randomNumber]; // deleted redeclaration error on line 80
            if (userAge < 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                Console.WriteLine("Pick something else!");
                _activities.Remove(randomActivity);
                randomNumber = Rng.Next(_activities.Count);
                randomActivity = _activities[randomNumber];
            };


            Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
            Console.WriteLine(); // added missing period
            userResponse = Console.ReadLine().ToLower(); // type and declaration error on line 51

            while (userResponse != "keep" && userResponse != "redo")
            {
                Console.WriteLine("Invalid response, please write Keep/Redo.");
                userResponse = Console.ReadLine().ToLower();
            }

            if (userResponse == "keep")
            {
                cont = false;
            }
            
            }
        }
    }
}// deleted extra curly brace