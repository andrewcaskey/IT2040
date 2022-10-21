using System;

namespace MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee person1 = new Employee("Truman", "Tiger", "12345", empType.Sales);
            Salesperson salesPerson1 = new Salesperson("Mickey", "Mouse", "23456", "Sporting Goods", 7500);
            Manager manager1 = new Manager("Elmer", "Fudd", "56789", "Electronics", "Midwest");

            Console.WriteLine("\n-------Employee 1-------------");
            person1.getEmployeeInfo();

            Console.WriteLine("\n-------Sales Person 1-------------");
            salesPerson1.getEmployeeInfo();
            Console.WriteLine($"Sales Level: {salesPerson1.GetSalesLevel()} | Sales: {salesPerson1.getSales()}");
            salesPerson1.updateSales((int)5250.70f);
            Console.WriteLine($"Updated Sales Level: {salesPerson1.GetSalesLevel()} | Updated Sales: {salesPerson1.getSales()}");

            Console.WriteLine("\n-------Manager 1-------------");
            manager1.getEmployeeInfo();
            Console.WriteLine($"Dept: {manager1.getDepartment()} | Region: {manager1.getRegion()}");
            manager1.setFirstName("Wiley");
            manager1.setLastName("Coyote");
            manager1.setRegion("Southeast");
            manager1.setDepartment("Automotive");
            Console.WriteLine($"\nNew Name: {manager1.getFirstName()} {manager1.getlastName()}");
            Console.WriteLine($"New Dept: {manager1.getDepartment()} | New Region: {manager1.getRegion()}");
        }
    }

}