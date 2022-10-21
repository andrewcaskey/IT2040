using System;

namespace MidtermProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee person1 = new Employee("Truman", "Tiger", "12345", Category.student);
            Student student1 = new Student("Mickey", "Mouse", "23456", "Information Technology", 87);
            Professor prof1 = new Professor("Elmer", "Fudd", "56789", "Computer Science", "NLP");

            Console.WriteLine("\n-------Person 1-------------");
            person1.getPersonInfo();

            Console.WriteLine("\n-------Student 1-------------");
            student1.getPersonInfo();
            Console.WriteLine($"Class: {student1.getStudentClass()} | Credit Hours: {student1.getCreditHours()}");
            student1.updateCreditHours(15);
            Console.WriteLine($"Updated Class: {student1.getStudentClass()} | Updated Credit Hours: {student1.getCreditHours()}");

            Console.WriteLine("\n-------Professor 1-------------");
            prof1.getPersonInfo();
            Console.WriteLine($"Dept: {prof1.getDepartment()} | Research Area: {prof1.getResearchArea()}");
            prof1.setFirstName("Wiley");
            prof1.setLastName("Coyote");
            prof1.setResearchArea("Autonomous Systems");
            prof1.setDepartment("Information Technology");
            Console.WriteLine($"\nNew Name: {prof1.getFirstName()} {prof1.getlastName()}");
            Console.WriteLine($"New Dept: {prof1.getDepartment()} | New Research Area: {prof1.getResearchArea()}");
        }
    }

}
