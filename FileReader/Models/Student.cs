using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader.Models
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string phone;
        private int age;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public int Age { get => age; set => age = value; }

        public static List<Student> GetStudentsFromFile(string fileName)
        {
            List<Student> list = new List<Student>();
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                string ligne = reader.ReadLine();
                while(ligne != null)
                {
                    ligne = reader.ReadLine();
                    if(ligne != null)
                    {
                        string[] content = ligne.Split(';');

                        Student s = new Student()
                        {
                            FirstName = content[0],
                            LastName = content[1],
                            Phone = content[2],
                            Age = Convert.ToInt32(content[3])
                        };
                        list.Add(s);
                    }                
                }
                reader.Close();
            }
            return list;
        }

        public static void SaveStudents(string fileName, List<Student> students)
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine("firstName;lastName;phone;age");
            foreach(Student s in students)
            {
                writer.WriteLine($"{s.FirstName};{s.LastName};{s.Phone};{s.Age}");
            }
            writer.Close();
        }
    }
}
