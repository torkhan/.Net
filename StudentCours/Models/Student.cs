using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCours.Models
{
    public class Student
    {
        private int id;
        private string firstName;
        private string lastName;

        public List<StudentCours> Courses { get; set; }
        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }

        public override string ToString()
        {
            return LastName + " "+ FirstName;
        }
    }
}
