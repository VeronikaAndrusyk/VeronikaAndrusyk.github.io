using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using Lab9.Models;
using Lab9.Controllers;

namespace Lab9.Models
{
    public class StudentRepository : IRepository<Student>
    {
        protected AppDbContext _dbcontext;
        public StudentRepository(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<Student> Create(Student value)
        {
            var student = await _dbcontext.AddAsync(value);
            await _dbcontext.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbcontext.Students.ToListAsync();
        }
        public async Task<Student> GetById(int id)
        {
            var student = await _dbcontext.Students.FindAsync(id);
            return student;
        }
        public async Task<Student> Delete(int id)
        {
            var student = await _dbcontext.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            _dbcontext.Students.Remove(student);
            await _dbcontext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> Update(int id, Student value)
        {
            var student = await _dbcontext.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
           
            student.LastName = value.LastName;
            student.BirthYear = value.BirthYear;
            student.Group = value.Group;
            student.Faculty = value.Faculty;
            student.AverageGrade = value.AverageGrade;
            student.Workplace = value.Workplace;
            student.City = value.City;

            _dbcontext.Students.Entry(student).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return student;
        }



    }
}