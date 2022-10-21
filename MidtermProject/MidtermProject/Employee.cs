// Employee.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employees
{
    public partial class Employee
    {
        protected string empName;
        protected int empID;
        protected float curPay;
        protected int empAge;
        protected string empSSN;
        protected static string companyName;
        protected BenefitPackage empBenefits = new BenefitPackage();

        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }

            public double ComputePayDeduction()
            {
                return 120.5;
            }
        }

        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }

        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }

        public void GiveBonus(float amount)
        {
            curPay += amount;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", empName);
            Console.WriteLine("ID: {0}", empID);
            Console.WriteLine("Age: {0}", empAge);
            Console.WriteLine("SSN: {0}", empSSN);
            Console.WriteLine("Pay: {0}", curPay);
        }

        static void Main(string[] args)
        {
            Employee.BenefitPackage.BenefitPackageLevel myBenefitLevel =
                    Employee.BenefitPackage.BenefitPackageLevel.Platinum;
            Manager Voldemort = new Manager("Voldemort", 65, 87, 160000, "234-24-9873", 100);
            double cost = Voldemort.GetBenefitCost();
            Console.ReadLine();
        }
    }
}

