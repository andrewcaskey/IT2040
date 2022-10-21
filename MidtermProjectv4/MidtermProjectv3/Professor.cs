using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermProject
{
    class Professor : Person
    {
        private string department;
        private string researchArea;

        public Professor(string fn, string ln, string id, string dep, string res) : base(fn, ln, id, Category.staff)
        {
            department = dep;
            researchArea = res;
        }
        public string getDepartment()
        {
            return department;
        }
        public void setDepartment(string dep)
        {
            department = dep;
        }
        public string getResearchArea()
        {
            return researchArea;
        }
        public void setResearchArea(string res)
        {
            researchArea = res;
        }
    }
}