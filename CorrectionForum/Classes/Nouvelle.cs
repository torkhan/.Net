using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionForum.Classes
{
    public class Nouvelle
    {
        int id;
        string sujet;
        string description;

        public string Sujet { get => sujet; set => sujet = value; }
        public string Description { get => description; set => description = value; }
        public int Id { get => id; set => id = value; }

        public Nouvelle(string sujet, string description)
        {
            Sujet = sujet;
            Description = description;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Sujet : {Sujet}, Description : {Description}";
        }
    }
}
