using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

struct StudentDetails
{  // store student details
    public string first_name;   
    public string last_name;    
    public int hours;   
    public string major;
    public float[] marks;
};

class StudentScoreReport
{
    // generate student report

    public double average_Marks(float[] marks)
    {
        // calculate average of marks
        double sum = 0;
        for (int i = 0; i < marks.Length; i++)
        { 
            sum += marks[i];    
        }
        return sum / marks.Length;
    }
    public string studentClass(int credits)
    {
        // calculate student class

        if (credits < 30)
        {   
            return "Freshman";  
        }
        else if (credits < 60)
        { 
            return "Sophomore";
        }
        else if (credits < 90)
        { 
            return "Junior";
        }
        else
        {  
            return "Senior";   
        }
    }

    public void generateReport(StudentDetails[] student)
    {
        // method to generate student report to a file

        string fileName = "scoresLog.txt";
        int number_Students = student.Length;
        double avg_Score = 0;
        double maxavg_Score = 0;
        double minavg_Score = 100;
        for (int i = 0; i < student.Length; i++)
        {
            // loop to calculate average score

            avg_Score += average_Marks(student[i].marks);
            if (average_Marks(student[i].marks) > maxavg_Score)
            {     
                maxavg_Score = average_Marks(student[i].marks);
            }
            if (average_Marks(student[i].marks) < minavg_Score)
            {
                minavg_Score = average_Marks(student[i].marks);   
            }
        }

        // calulcate the average of the scores and find the min and max
        avg_Score /= student.Length; 
        avg_Score = Math.Round(avg_Score, 2);  
        maxavg_Score = Math.Round(maxavg_Score, 2);   
        minavg_Score = Math.Round(minavg_Score, 2);


        // display summary of students scores 
        string title = "Student Summary";
        title += "\n-----------------------\n";
        string report = "Number of students: " + number_Students + "\nAverage Grade: " + avg_Score + "%\nMaximum Grade: " + maxavg_Score + "%\nMinimum Grade: " + minavg_Score + "%"; // student report
        System.IO.File.WriteAllText(fileName, title + report); 

        Console.WriteLine("Report generated successfully");

    }

    public string getFileInput()
    {

        Console.Write("Enter Your Name: ");
        string user_name = Console.ReadLine();

        Console.Write("Enter file name: ");
        string fileName = Console.ReadLine();

        // check if file name consists .csv if not add

        if (!fileName.Contains(".csv"))
        {
            fileName += ".csv";
        }
        return fileName;
    }


    public void printReport(StudentDetails[] students)
    {
        // print student report to console
        Console.WriteLine("\n*************************Student Report**************************\n"); // print header to console
        for (int i = 0; i < students.Length; i++)
        {
            // loop to print student details
            Console.WriteLine(students[i].first_name + " " + students[i].last_name + ": " + studentClass(students[i].hours) + "(" + students[i].major + ")");  // print student details to console
            Console.WriteLine("Average Score: " + Math.Round(average_Marks(students[i].marks), 2) + "%");
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        // main
        StudentScoreReport report = new StudentScoreReport(); 

        string fileName = report.getFileInput();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        // create array of students
        StudentDetails[] students = new StudentDetails[lines.Length];
        // loop through each line
        for (int i = 0; i < lines.Length; i++)
        {
            
            string[] line = lines[i].Split(',');
            StudentDetails student = new StudentDetails();
            student.first_name = line[0];
            student.last_name = line[1];
            student.hours = int.Parse(line[2]);
            student.major = line[3];

            // create array of marks
            student.marks = new float[line.Length - 4];
            // loop through each mark
            for (int j = 4; j < line.Length; j++)
            {
                // assign mark to array
                student.marks[j - 4] = float.Parse(line[j]);
            }
            // assign student object to array
            students[i] = student;
        }
        // print report
        report.printReport(students);
        // generate report
        report.generateReport(students);
    }
}

