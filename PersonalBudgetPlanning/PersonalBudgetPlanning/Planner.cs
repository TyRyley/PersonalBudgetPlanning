using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalBudgetPlanning 
{
    public class Planner : Expense  // Expense typed to use abstract class (Expense)
    {
        // class attributes
        private double income;  // user's monthly income
        private double tax;  // user's monthly estimated tax deduction

        private double[] ex;  // array of expenses

        private double monthlyLoanRepay = 0;
        private double rentalAmt = 0;

        private double totalEx = 0;  // total amount of expenses
        private double leftover = 0;  // income minus expenses

        public Planner(double income, double tax, double[] ex)  // constructor
        {
            this.income = income;
            this.tax = tax;
            this.ex = ex;
        }


        public override void leftOver()  // calculates available monthly money after deductions
        {
            for (int i = 0; i < ex.Length; i++)
            {
                this.totalEx = this.totalEx + ex[i];
            }
            this.totalEx = this.totalEx + this.tax;
        }

        public override void display()  // display available monthly money after deductions
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n======================================================================================");
            Console.WriteLine("\t\tREPORT");
            Console.WriteLine("======================================================================================");
            Console.WriteLine("\nIncome: \t\t" + "R" + this.income);
            Console.WriteLine("Total expenses: \t" + "R" + this.totalEx);
            Console.WriteLine("\n--------------------------------------------------------------------------------------");

            this.leftover = this.income - this.totalEx - this.monthlyLoanRepay - this.rentalAmt;


            Console.WriteLine("You have R" + this.leftover + " after deductions have been made.");
            Console.WriteLine("======================================================================================");
            Console.WriteLine("\t\tRECOMMENDATIONS");
            Console.WriteLine("======================================================================================");
            if (this.leftover > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Considering your income minus your expenses, your budget is enough for you.");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Considering your income minus your expenses, your expenses overwhelm your income");
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine("======================================================================================");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nThank you for using the Personal Budget Planning App!");
            Console.WriteLine("* * * END OF PROGRAM * * *");

            Console.WriteLine("\nClosing program . . . ");

            // loop for countdown
            for (int i = 3; i > 0; i--)     // decrementing for loop
            {
                Console.Write(i + "\t");    // type Write only to make it verticle output

                // pause
                Thread.Sleep(1000);        // max 5000 miliseconds   // using System.Threading is the import

            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nGOODBYE!");
        }

        public override void homeLoan()  // get home loan info
        {
            //variables
            string input = "";
            double price = 0;
            double deposit = 0;
            double interestRate = 0;
            int noOfMonthsRepay = 0;



            Console.WriteLine("\nEnter the following values for a home loan: ");
            Console.Write("Purchase price of the property > R");
            input = Console.ReadLine();
            validDoubleHomeLoan(input);
            price = Convert.ToDouble(input);  // stores total price of home loan

            Console.Write("Total deposit > R");
            input = Console.ReadLine();
            validDoubleHomeLoan(input);
            deposit = Convert.ToDouble(input);  // stores deposit

            Console.Write("Interest rate (percentage) > ");
            input = Console.ReadLine();
            validDoubleHomeLoan(input);
            interestRate = Convert.ToDouble(input);  // stores interest rate

            Console.Write("Number of months to repay (between 240 and 360) > ");
            input = Console.ReadLine();
            validIntHomeLoanRange(input);
            noOfMonthsRepay = Convert.ToInt32(input);  // stores number of months to repay loan

            // monthly home loan repayment calculation

            /* Formula for monthly home loan repayment:
             * monthlyLoanRepayment = ( price * interestRate * ( 1 + interestRate ) raised to the exponent noOfMonthsRepay ) divided by ( 1 + interestRate ) raised to the exponent noOfMonthsRepay - 1
             */

            //calc
            price = price - deposit;  // to get total price of loan after deposit is paid
            interestRate = interestRate / 100;  // converts user's answer to a valid value for interest (percentage)

            double monthlyLoanRepayment = 0;  // variable to store monthly home loan repayment

            //calculation
            monthlyLoanRepayment = price * interestRate / 12 * Math.Pow(1 + interestRate / 12, noOfMonthsRepay) / Math.Pow(1 + interestRate / 12, noOfMonthsRepay) - 1;

            Console.WriteLine("Monthly loan repayment: R" + monthlyLoanRepayment);

            if (monthlyLoanRepayment > (1 / 3 * this.income))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ALERT: the approval of the home loan is unlikely because it costs more than a third of your monthly income.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            this.monthlyLoanRepay = monthlyLoanRepayment;  // stores monthly loan replayment

        }

        public void validDoubleHomeLoan(string input)  // checks if value entered by user is a double
        {
            double aDouble = 0.00;

            if (!double.TryParse(input, out aDouble))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid value entered, please enter a number for these values only, e.g. 300,50");
                Console.ForegroundColor = ConsoleColor.Yellow;
                homeLoan();
            }
        }

        public void validIntHomeLoanRange(string input)  // checks if value entered by user is a valid
        {
            int anInt = 0;

            if (!int.TryParse(input, out anInt))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to enter a number of months.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                homeLoan();
            }
            if (anInt < 240 || anInt > 360)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You need to enter a number of months between 240 and 360.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                homeLoan();
            }
        }

        public override void rentProperty()  // to get monthly rental amount
        {
            string input = "";
            this.rentalAmt = 0;

            Console.Write("\nEnter monthly rental amount > R");
            input = Console.ReadLine();
            validDoubleRentProp(input);
            this.rentalAmt = Convert.ToDouble(input);  // stores rental amount
        }

        public void validDoubleRentProp(string input)  // checks if value entered by user is a double
        {
            double aDouble = 0.00;

            if (!double.TryParse(input, out aDouble))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid value entered, please enter a number for these values only, e.g. 300,50");
                Console.ForegroundColor = ConsoleColor.Yellow;
                rentProperty();
            }
        }

    }
}
