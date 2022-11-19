using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

struct Sale
{
    public int invoice_num;
    public string branch;
    public string city;
    public string customer_type;
    public string gender;
    public string product_line;
    public float unit_price;
    public int quantity;
    public DateTime date;
    public string payment;
    public float rating;

    public Sale(int invoice_num, string branch, string city, string customer_type, string gender, string product_line, float unit_price, int quantity, DateTime date, string payment, float rating)
    {
        this.invoice_num = invoice_num;
        this.branch = branch;
        this.city = city;
        this.customer_type = customer_type;
        this.gender = gender;
        this.product_line = product_line;
        this.unit_price = unit_price;
        this.quantity = quantity;
        this.date = date;
        this.payment = payment;
        this.rating = rating;
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
                            Console.WriteLine("Row {0} contains {1} values. It should contain 10.", num, values.Length);
                            continue;
                        }

                        // Parsing data
                        int invoice_num = int.Parse(values[0]);
                        string branch = values[1];
                        string city = values[2];
                        string customer_type = values[3];
                        string gender = values[4];
                        string product_line = values[5];
                        float unit_price = float.Parse(values[6]);
                        int quantity = int.Parse(values[7]);
                        // Parsing the invoice date 
                        string[] d = values[8].Split("/");
                        int year = int.Parse(d[0]);
                        int month = int.Parse(d[1]);
                        int day = int.Parse(d[2]);
                        DateTime date = new DateTime(year, month, day);
                        // Parsing rest of  the data
                        string payment = values[9];
                        float rating = float.Parse(values[10]);
                        // Adding the new sale to list
                        sales.Add(new Sale(invoice_num, branch, city, customer_type, gender, product_line, unit_price, quantity, date, payment, rating));
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
            string line01 = "Total Sales";
            string line02 = "Show the unique product lines in the data set";
            string line03 = "Calculate the total sales for each product line. Sales total will be the sum of (Quantity * UnitPrice) for all products sold in the product line. List the product line and total sales.";
            string line04 = "Calculate the total Sales per city? List the city name and total sales.";
            string line05 = "Which product line(s) have the sale with the highest unit price? List the product line and the price.\n";
            string line06 = "Calculate the total sales per month in the data set. List the city month and total sales";
            string line07 = "Calculate the total sales per payment type. List the payment type and total sales.\n";
            string line08 = "Calculate the number of sales transactions per member type. List the member type and number of transactions.\n";
            string line09 = "Calculate the average rating per product line. List the product line and the average rating.\n ";
            string line10 = "Calculate the total number of transactions per payment type. List the payment type and number of transactions.\n";
            string line11 = "Calculate the total quantity of products sold per city. List the city and number of products sold.\n ";
            string line12 = "Using a 5% sales tax, Calculate the tax for each sales transaction in each product line. List the invoice number, total sales for the transaction, and the tax amount for the transaction, ordered by the product line.\n";

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


            line01 += total;

            var unique_Sales = myList.Cast<int>().Distinct();
            line02 += unique_Sales.ToArray().Length;

            line03 += count1;

            var distinctCount = contList.Cast<string>().Distinct();

            num += 1;
        
            var unique_Cust = custList.Cast<int>().Distinct();

            float max = 0;
            int cust = 0;
            foreach (int c in unique_Cust)
            {
                float amt = 0;
                foreach (Sale sale in sales)
                {
                    if (sale.rating == c)
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

