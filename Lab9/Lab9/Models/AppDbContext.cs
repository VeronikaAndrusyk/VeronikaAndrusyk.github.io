using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.SqlServer;
using Lab9.Models;

namespace Lab9.Models
{
    public class AppDbContext : DbContext
    {
        protected string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Asus\OneDrive\Робочий стіл\C#\my5Labka\my5Labka\SA2ANDRUSYK.mdf"";Integrated Security=True;Connect Timeout=30";
        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}