using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermProject
{
    class Manager : Employee
    {
        private string department;
        private string region;

        // 
        public Manager(string fn, string ln, string id, string dep, string reg) : base(fn, ln, id, empType.Production)
        {
            department = dep;
            region = reg;
        }
        public string getDepartment()
        {
            return department;
        }
        public void setDepartment(string dep)
        {
            department = dep;
        }
        public string getRegion()
        {
            return region;
        }
        public void setRegion(string re)
        {
            region = re;
        }
    }
}