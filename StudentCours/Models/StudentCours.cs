using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudentCours.Models
{
    public class StudentCours
    {
        private int id;

        private int studentId;

        private int coursId;

        public Student Student { get; set; }
        public Cours Cours { get; set; }
        public int Id { get => id; set => id = value; }
        
        [ForeignKey("Student")]
        public int StudentId { get => studentId; set => studentId = value; }
        
        [ForeignKey("Cours")]
        public int CoursId { get => coursId; set => coursId = value; }
    }
}
