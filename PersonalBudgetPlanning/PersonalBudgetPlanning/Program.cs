//Student no: ST10084621
//Name: Tyreece Pillay
//Group: BCAD year 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalBudgetPlanning
{
    internal class Program
    {
        static void Main(string[] args)
        {

            welcomeMsg(); // welcome message method

            userInput();  // user navigates through program

            Console.ReadLine();  // keeps console open
        }

        public static void welcomeMsg()  // house keeping
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Loading . . . ");

            // loop for countdown
            for (int i = 3; i > 0; i--)     // decrementing for loop
            {
                Console.Write(i + "\t");    // type Write only to make it verticle output

                // pause
                Thread.Sleep(1000);        // max 5000 miliseconds   // using System.Threading is the import

            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n \t Welcome to the Personal Budget Planning App! "
                + "\n ==========================================================");

            // pause
            Thread.Sleep(1000);
        }

        public static void userInput()  // gets user's monthly income, tax deduction and expenses
        {
            // variables
            string input = "";  // store user's input

            double income = 0;
            double tax = 0;
            double groceriesCost = 0;
            double waterAndElec = 0;
            double travelCost = 0;
            double phoneCost = 0;
            double otherCost = 0;

            //get user's monthly income and estimated monthly tax deduction
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nHelp us understand your budget by entering the following values: ");
            Thread.Sleep(1000);
            Console.Write("Enter your gross monthly income > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);  
            income = Convert.ToDouble(input); // stores user's monthly income

            Console.Write("Enter your estimated monthly tax deduction > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);
            tax = Convert.ToDouble(input);  // stores user's estimated monthly tax deduction

            // get user's expenses
            Console.WriteLine("\nEnter your monthly expenditures in each of the following categories: ");
            Thread.Sleep(1000);
            Console.Write("Groceries > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);
            groceriesCost = Convert.ToDouble(input);  // stores user's grocery cost

            Console.Write("Water and Electricity > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);
            waterAndElec = Convert.ToDouble(input); // stores user's water and elec cost

            Console.Write("Travel costs (including petrol) > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);
            travelCost = Convert.ToDouble(input);  // stores user's travel cost

            Console.Write("Cellphone and telephone > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);
            phoneCost = Convert.ToDouble(input);  // stores user's phone cost

            Console.Write("Other expenses > R");
            input = Console.ReadLine();
            validDoubleUserInput(input);
            otherCost = Convert.ToDouble(input);  // stores user's other costs

            double[] ex = {groceriesCost,waterAndElec,travelCost,phoneCost,otherCost};  // store expenses in array

            Planner p = new Planner(income, tax, ex);  // create object of child class

            // user accomodation
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n* * * Accomodation * * * ");

            Console.WriteLine("Please select one of the following options for accomodation: (type the number only) ");
            Thread.Sleep(1000);
            Console.WriteLine("1 - Rent a property \n2 - Purchase a property");
            Console.Write("Select option number > ");
            input = Console.ReadLine();
            validChoice(input);
            int ans = 0;
            ans = Convert.ToInt32(input);  // stores user's choice

            switch (ans)
            {
                case 1: p.rentProperty(); break;  // calls method to get monthly rental amount
                case 2: p.homeLoan(); break;  // calls method to get home loan info
            }
            

            p.leftOver();  // calls method to calculate available monthly money after deductions
            p.display();  // calls method to display available monthly money after deductions
        }

        public static void validDoubleUserInput(string input)  // checks if value entered by user is a double
        {
            double aDouble = 0.00;

            if (!double.TryParse(input, out aDouble))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid value entered, please enter a number for these values only, e.g. 300,50");
                Console.ForegroundColor = ConsoleColor.Green;
                userInput();        
            }
        }

        public static void validChoice(string input)  // checks if value entered by user is valid
        {
            int anInt = 0;
            if (!int.TryParse(input, out anInt))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to enter a number.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput();
            }
            if (anInt < 1 || anInt > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter an option either 1 or 2.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                userInput();
            }
        }

    }
}
