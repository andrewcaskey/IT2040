using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermProject
{
    public enum Category { student, faculty, staff };
    class Employee
    {
        private string firstName;
        private string lastName;
        private string id;
        private Category category;

        public Employee(string fn, string ln, string i, Category cat)
        {
            firstName = fn;
            lastName = ln;
            id = i;
            category = cat;
        }
        public void getPersonInfo()
        {
            string str;
            str = "Name: " + firstName + " " + lastName + "\nID: " + id + "; Type: " + category.ToString();
            Console.WriteLine(str);
        }
        public string getFirstName()
        {
            return firstName;
        }
        public string getlastName()
        {
            return lastName;
        }
        public Category getCategory()
        {
            return category;
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