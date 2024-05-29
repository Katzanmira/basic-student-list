using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _66840_Mehmet_Said_Unlu_T9
{
    public class Student
    {
        private string name;
        private string lastName;
        private string studentID;
        private string studentClass;

        public static Dictionary<string, List<Student>> StudentsDictionary = new Dictionary<string, List<Student>>();

        public Student(string name, string lastName, string studentID, string studentClass)
        {
            this.name = name;
            this.lastName = lastName;
            this.studentID = studentID;
            this.studentClass = studentClass;
        }

        public string Name
        {
            get { return name; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public string StudentID
        {
            get { return studentID; }
        }

        public string StudentClass
        {
            get { return studentClass; }
        }

        public override string ToString()
        {
            return $"{name} {lastName}";
        }

        public static void AddStudent(Student student)
        {
            if (!StudentsDictionary.ContainsKey(student.StudentClass))
            {
                StudentsDictionary[student.StudentClass] = new List<Student>();
            }
            StudentsDictionary[student.StudentClass].Add(student);
        }

        public static void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var classEntry in StudentsDictionary)
                {
                    writer.WriteLine($"Class: {classEntry.Key}");

                    foreach (var student in classEntry.Value)
                    {
                        writer.WriteLine($"Name: {student.Name}");
                        writer.WriteLine($"LastName: {student.LastName}");
                        writer.WriteLine($"StudentID: {student.StudentID}");
                        writer.WriteLine();
                    }
                }
            }
        }

        public static void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
            else
            {
                StudentsDictionary.Clear();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string currentClass = "";
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Class: "))
                        {
                            currentClass = line.Substring(7);
                            StudentsDictionary[currentClass] = new List<Student>();
                        }
                        else if (line.StartsWith("Name: "))
                        {
                            string name = line.Substring(6);
                            string lastName = reader.ReadLine().Substring(10);
                            string studentID = reader.ReadLine().Substring(11);
                            reader.ReadLine();
                            StudentsDictionary[currentClass].Add(new Student(name, lastName, studentID, currentClass));
                        }
                    }
                }
            }
        }
    }
}
