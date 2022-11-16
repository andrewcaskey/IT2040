using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

struct Sale
{
    public int invoice_num;
    public int stock_code;
    public string description;
    public int quantity;
    public DateTime date;
    public float unit_price;
    public int customer_id;
    public string country;

    public Sale(int invoice_num, int stock_code, string description, int quantity, DateTime date, float unit_price, int customer_id, string country)
    {
        this.invoice_num = invoice_num;
        this.stock_code = stock_code;
        this.description = description;
        this.quantity = quantity;
        this.date = date;
        this.unit_price = unit_price;
        this.customer_id = customer_id;
        this.country = country;
    }

    public float amount()
    {
        return (unit_price * quantity);
    }
}

class SalesDataAnalyzer
{
    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: SalesDataAnalyzer <sales_data_file_path> <report_file_path>");
            return;
        }

        ArrayList sales = new ArrayList();

        // Store the path of the files in your system 
        string dataFile = args[0];
        string reportFile = args[1];

        // To read a text file line by line 
        if (File.Exists(dataFile))
        {
            // Store each line in array of strings 
            string[] lines = File.ReadAllLines(dataFile);

            int num = 0;
            foreach (string line in lines)
            {
                if (num != 0)
                {
                    try
                    {
                        string[] values = line.Split(",");

                        if (values.Length < 8)
                        {
                            Console.WriteLine("Row {0} contains {1} values. It should contain 8.", num, values.Length);
                            continue;
                        }

                        // Parsing data
                        int invoice_num = int.Parse(values[0]);
                        int stock_code = int.Parse(values[1]);
                        string description = values[2];
                        int quantity = int.Parse(values[3]);
                        // Parsing the invoice date 
                        string[] d = values[4].Split("/");
                        int year = int.Parse(d[0]);
                        int month = int.Parse(d[1]);
                        int day = int.Parse(d[2]);
                        DateTime date = new DateTime(year, month, day);
                        // Parsing rest of  the data
                        float unit_price = float.Parse(values[5]);
                        int customer_id = int.Parse(values[6]);
                        string country = values[7];
                        // Adding the new sale to list
                        sales.Add(new Sale(invoice_num, stock_code, description, quantity, date, unit_price, customer_id, country));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                num += 1;
            }
        }


        // Writing the Report 
        try
        {
            string line01 = "List of Items Sold to Customers in Australia:-";
            string line02 = "Number of Individual Sales = ";
            string line03 = "Total Sales for invoice number 536365 = ";
            string line04 = "List of Total Sales by Country:-";
            string line05 = "Customer ID that spent the most money = ";
            string line06 = "Total sales to customer 15311 = ";
            string line07 = "Number of the “HAND WARMER UNION JACK” sales = ";
            string line08 = "Value of the “HAND WARMER UNION JACK” sales = ";
            string line09 = "Product with the highest UnitPrice = ";
            string line10 = "Total Sales = ";
            string line11 = "Invoice Number that had the highest sales = ";
            string line12 = "Product sold the most units = ";

            ArrayList myList = new ArrayList();
            ArrayList contList = new ArrayList();
            ArrayList custList = new ArrayList();

            int num = 1;
            int count1 = 0, count2 = 0;
            float amt1 = 0, amt2 = 0;
            string prod1 = "", prod2 = "";
            float max_price = 0;
            float total = 0;
            int max_sale = 0;
            int inv = 0;
            foreach (Sale sale in sales)
            {
                if (sale.country.ToLower() == "australia")
                {
                    line01 += "\n" + num + "." + " Stock Code: " + sale.stock_code + " Descrption: " + sale.description;
                    num += 1;
                }

                myList.Add(sale.invoice_num);

                if (sale.invoice_num == 536365)
                    count1 += 1;

                contList.Add(sale.country);

                custList.Add(sale.customer_id);

                if (sale.customer_id == 15311)
                    amt1 += sale.amount();

                if (sale.description == "\"HAND WARMER UNION JACK\"")
                {
                    count2 += sale.quantity;
                    amt2 += sale.amount();
                }

                if (sale.unit_price > max_price)
                {
                    max_price = sale.unit_price;
                    prod1 = sale.description;
                }

                total += sale.amount();

                if (sale.quantity > max_sale)
                {
                    max_sale = sale.quantity;
                    inv = sale.invoice_num;
                    prod2 = sale.description;
                }
            }

            var distinctSales = myList.Cast<int>().Distinct();
            line02 += distinctSales.ToArray().Length;

            line03 += count1;

            var distinctCount = contList.Cast<string>().Distinct();

            num = 1;
            foreach (string c in distinctCount)
            {
                float amt = 0;
                foreach (Sale sale in sales)
                {
                    if (sale.country == c)
                        amt += sale.amount();
                }

                line04 += "\n" + num + ". Name: " + c + "; Total Sales = " + amt;

                num += 1;
            }

            var distinctCust = custList.Cast<int>().Distinct();

            float max = 0;
            int cust = 0;
            foreach (int c in distinctCust)
            {
                float amt = 0;
                foreach (Sale sale in sales)
                {
                    if (sale.customer_id == c)
                        amt += sale.amount();
                }

                if (amt > max)
                {
                    max = amt;
                    cust = c;
                }
            }

            line05 += cust;

            line06 += amt1;

            line07 += count2;

            line08 += amt2;

            line09 += prod1;

            line10 += total;

            line11 += inv;

            line12 += prod2;

            string[] lines = {line01,line02,line03,line04,line05,line06,
                                     line07,line08,line09,line10,line11,line12};

            File.WriteAllLines(reportFile, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

