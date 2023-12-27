using my5Labka.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace my5Labka.models
{
    public class StudentsRepository : IRepository<Student>
    {
        private UniversityDb context;

        public StudentsRepository()
        {
            this.context = new UniversityDb();
            this.context.Database.EnsureCreated(); // Забезпечує створення бази даних (якщо не існує)
        }

        public IQueryable<Student> GetAll()
        {
            return this.context.Students.AsQueryable();
        }


    }
}