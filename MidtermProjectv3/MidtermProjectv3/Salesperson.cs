﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MidtermProject
{
    public enum StudentClass { bronze, silver, gold, diamond, platinum }
    class Salesperson : Employee
    {
        private string department;
        private int sales;
        private string firstName;
        private string lastName;
        private string id;
        private empType type;

        public Salesperson(string fn, string ln, string id, string dp, int hr) : base(fn, ln, id, empType.Sales)
        {
            department = dp;
            sales = hr;

        }

        public void updateSales(int profits)
        {
            sales += profits;
        }

        public StudentClass GetSalesLevel()
        {
            if (sales < 10000)
                return StudentClass.bronze;
            else if (sales > 10000 && sales < 19999.99)
                return StudentClass.silver;
            else if (sales > 19999.99 && sales < 29999.99)
                return StudentClass.gold;
            else if (sales > 29999.99 && sales < 39999.99)
                return StudentClass.diamond;
            return StudentClass.platinum;
        }

        internal object getSales()
        {
            return sales;
        }
    }
}

