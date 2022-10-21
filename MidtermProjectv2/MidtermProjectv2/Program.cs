//Create instances of Employee, SalesPerson, and Manager
using System;
using Employees;

Employee employee1 = new Employee("Truman", "Tiger", "12345", EmployeeType.Sales);


Console.WriteLine("\n-------Employee 1-------------");
employee1.getEmployeeInfo();
