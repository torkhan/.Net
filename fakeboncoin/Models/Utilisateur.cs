﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeboncoin.Models
{
    public class Utilisateur
    {
        private int id;

        private string email;

        private string motPasse;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string MotPasse { get => motPasse; set => motPasse = value; }
    }
}
