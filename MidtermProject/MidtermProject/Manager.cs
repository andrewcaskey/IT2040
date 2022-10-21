
// Manager.cs

namespace Employees
{
    internal class Manager : Employee
    {
        private int numberOfOptions;

        public Manager() { }

        public Manager(string fullName, int age, int empID,
            float curPay, string ssn, int numbOfOpts)
            : base(fullName, age, empID, curPay, ssn)
        {
            numberOfOptions = numbOfOpts;
        }

        public int StockOptions
        {
            get { return numberOfOptions; }
            set { numberOfOptions = value; }
        }
    }
}