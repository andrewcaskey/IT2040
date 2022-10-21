using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermProject
{
    public enum StudentClass { freshman, sophomore, junior, senior }
    class Student : Person
    {
        private string major;
        private int crediHours;

        public Student(string fn, string ln, string id, string mj, int hr) : base(fn, ln, id, Category.student)
        {
            major = mj;
            crediHours = hr;
        }

        public void updateCreditHours(int hours)
        {
            crediHours += hours;
        }

        public StudentClass getStudentClass()
        {
            if (crediHours <= 29)
                return StudentClass.freshman;
            else if (crediHours >= 30 && crediHours <= 59)
                return StudentClass.sophomore;
            else if (crediHours >= 60 && crediHours <= 89)
                return StudentClass.junior;
            return StudentClass.senior;
        }

        internal object getCreditHours()
        {
            return crediHours;
        }
    }
}

