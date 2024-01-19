using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetPlanning
{
    public abstract class Expense  // abstract class
    {
        public abstract void homeLoan(); // get home loan info
        public abstract void rentProperty();  // to get monthly rental amount
        public abstract void leftOver();  // calculates available monthly money after deductions
        public abstract void display();  // display available monthly money after deductions
    }
}
