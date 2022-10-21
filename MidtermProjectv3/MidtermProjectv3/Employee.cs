using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermProject
{
    public enum empType { Sales, Manager, Production };
    class Employee
    {
        private string firstName;
        private string lastName;
        private string id;
        private empType type;



        // constructor that accepts firstName, lastName, id, and empType to initialize a new instance of an Employee and sets its properties.
        public Employee(string fn, string ln, string i, empType ty)
        {
            firstName = fn;
            lastName = ln;
            id = i;
            type = ty;
        }

        // public method (function) that prints information about the person
        public void getEmployeeInfo()
        {
            string str;
            str = "Name: " + firstName + " " + lastName + "\nID: " + id + "; Type: " + type.ToString();
            Console.WriteLine(str);
        }

        // methods for getting and setting firstname, lastname, type, ID
        public string getFirstName()
        {
            return firstName;
        }
        public string getlastName()
        {
            return lastName;
        }
        public empType getType()
        {
            return type;
        }
        public string getID()
        {
            return id;
        }

        public void setFirstName(string fn)
        {
            firstName = fn;
        }
        public void setLastName(string ln)
        {
            lastName = ln;
        }

    }
}