using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace my5Labka.models
{
    internal class UniversityDb : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Asus\OneDrive\Робочий стіл\C#\my5Labka\my5Labka\SA2ANDRUSYK.mdf"";Integrated Security=True;Connect Timeout=30");
        }
    }
}
