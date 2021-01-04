using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCours.Models
{
    public class Cours
    {
        private int id;
        private string title;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }

        public List<StudentCours> Students { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
