using Microsoft.EntityFrameworkCore;
using StudentCours.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCours
{
    public class DataDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Cours> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDb)\coursM2i;Initial Catalog=entity;Integrated Security=True");
        }
    }
}
