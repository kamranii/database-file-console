using System;
using System.Collections.Generic;
using System.IO;


namespace Practice.ConsoleApp
{
    class Program
    {
        const string myDatabasePath = "/Users/kamranimranli/desktop/mydatabase";
        static void Main(string[] args)
        {
            #region Database
            ////Initalize ths operations class
            //Operations operation = new Operations();
            ////Ask the user for choice
            //Console.WriteLine("Which operation would you like to make: ");
            //Console.WriteLine("1. Create a new student");
            //Console.WriteLine("2. Get all of the students from the database");
            //Console.Write("Your choice: ");
            //byte choice = byte.Parse(Console.ReadLine());
            //switch(choice)
            //{
            //    case 1:
            //        //Create a new student
            //        Student student = operation.CreateStudent();
            //        //Add the student to the database
            //        operation.CreateStudentInDatabase(myDatabasePath, student);
            //        break;
            //    case 2:
            //        //Retrieve all students and print
            //        operation.PrintResults(operation.GetStudents(myDatabasePath));
            //        break;
            //    default:
            //        Console.WriteLine("Incorrect choice!!!");
            //        break;
            //}
            //return;
            #endregion
            #region FilePractice
            const string path = "/Users/kamranimranli/desktop/testfolder/";
            DirectoryInfo root = new DirectoryInfo(path);
            FileInfo[] files = root.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            foreach(FileInfo file in files)
            {
                Console.WriteLine($"{file.FullName}");
            }
            #endregion
        }
    }
}
 
