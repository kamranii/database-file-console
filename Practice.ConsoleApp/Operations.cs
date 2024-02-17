using System;
using System.IO;

namespace Practice.ConsoleApp
{
    public class Operations
    {
        //Method to create a student
        public Student CreateStudent()
        {
            //Welcome
            Console.WriteLine("Welcome! This is a student registration form:");

            //Initialize the "Student"
            Student student = new Student();
            //Ask for the info
            Console.WriteLine("What is your name?: ");
            student.Name = Console.ReadLine();
            Console.WriteLine("What is your surname?: ");
            student.Surname = Console.ReadLine();
            Console.WriteLine("Enter your date of birth (MM-dd-YYYY)");
            student.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            //Generate its ID
            student.ID = Guid.NewGuid();
            return student;
        }
        //Method to create a file corresponding to the student in database
        public void CreateStudentInDatabase(string databasePath, Student student)
        {
            //Define a path for the file
            var file = Path.Combine(databasePath, student.ID + ".odt");
            //Check if a file with filename of the provided Student ID already exist
            if(File.Exists(file))
            {
                //Print out the error message
                Console.WriteLine("This student has already been created. Please, try another!");
            }
            else
            {
                //Create a content to write to the file
                var fileContent = $"Name: {student.Name}\n" +
                    $"Surname: {student.Surname}\n" +
                    $"BirthDate: {student.DateOfBirth.ToString("MM-dd-yyyy")}";
                //Copy content to the file
                File.WriteAllText(file, fileContent);
                Console.WriteLine("Student successfully added to the database");
            }
        }
        //Getting each student's data and saving to an array of Students
        public Student[] GetStudents(string databasePath)
        {
            //Save the "database" directory as a variable
            DirectoryInfo directory = new DirectoryInfo(databasePath);
            //An array of files to store all of the files in the "directory"
            FileInfo[] files = directory.GetFiles();
            //Initialize a "Student" type array to return
            Student[] students = new Student[files.Length - 1];
            //An index variable to track each added student
            int arrayIndex = 0;
            foreach(var file in files)
            {
                //Check if the current file has a proper extension
                if(file.Extension == ".odt")
                {
                    //Store all lines of the current file
                    var fileLines = File.ReadAllLines(file.FullName);
                    //Initialize a new student
                    Student student = new Student();
                    //Get each line, split it and trim whitespaces
                    student.Name = fileLines[0].Split(':')[1].Trim();
                    student.Surname = fileLines[1].Split(':')[1].Trim();
                    student.DateOfBirth = Convert.ToDateTime(fileLines[2].Split(':')[1].Trim());
                    //Add the student to the array
                    students[arrayIndex] = student;
                    //Update the index
                    arrayIndex++;
                    if (arrayIndex == files.Length)
                        break;
                }
                else
                {
                    //Print out the error message
                    Console.WriteLine("Incorrect file extension");
                }
            }
            return students;
        }
        //Printing out the results
        public void PrintResults(Student[] students)
        {
            Console.WriteLine("All students' info is being printed now: ");
            foreach(Student student in students)
            {
                PrintStudent(student);
            }
        }
        //Printing each student's info
        public void PrintStudent(Student student)
        {
            Console.WriteLine($"{nameof(student.Name)}: {student.Name}");
            Console.WriteLine($"{nameof(student.Surname)}: {student.Surname}");
            Console.WriteLine($"{nameof(student.DateOfBirth)}: {student.DateOfBirth}");
        }
    }
}

