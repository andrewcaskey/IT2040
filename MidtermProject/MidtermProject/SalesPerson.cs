
// SalesPerson.cs

namespace Employees
{
    class SalesPerson : Employee
    {
        private int numberOfSales;

        public SalesPerson() { }

        public SalesPerson(string fullName, int age, int empID,
            float curPay, string ssn, int numOfSales)
            : base(fullName, age, empID, curPay, ssn)
        {
            numberOfSales = numOfSales;
        }

        public int SalesNumber
        {
            get { return numberOfSales; }
            set { numberOfSales = value; }
        }
    }
}