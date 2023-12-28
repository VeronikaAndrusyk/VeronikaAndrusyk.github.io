using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;



namespace labka9.models
{
    internal class AppDbcontext : DbContext
    {
        public AppDbcontext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Asus\OneDrive\Робочий стіл\C#\my5Labka\my5Labka\SA2ANDRUSYK.mdf"";Integrated Security=True;Connect Timeout=30");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Table");

        }



    }
}
