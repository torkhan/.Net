﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fake_Boncoin.Models
{
    public class DataContext : DbContext
    {
        private static DataContext _instance = null;
        public DbSet<Annonce> Annonces { get; set; }

        private DataContext()
        {

        }
        public static DataContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataContext();
                return _instance;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\coursM2i;Integrated Security=True");
        }
    }
}
