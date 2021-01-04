using AnnuaireMVVMEntityFrameWork.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnnuaireMVVMEntityFrameWork
{
    class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(LocalDb)\coursM2i;Initial Catalog=entity;Integrated Security=True");
        }
    }
}
