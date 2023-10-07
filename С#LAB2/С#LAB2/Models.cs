using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Student
{
    //оголошую поля і властивсті
    public int StudentCode { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
    public List<Rating> Ratings { get; set; }

    // конструктор для  об'єкта студента
    public Student(int studentCode, DateTime dateOfBirth, string lastName, string group)
    {
        StudentCode = studentCode;
        DateOfBirth = dateOfBirth;
        LastName = lastName;
        Group = group;
        Ratings = new List<Rating>();
    }
    // додавання рейтингу до списку Ratings студента
    internal void AddRating(string subject, int module1Score, int module2Score)
    {
        Ratings.Add(new Rating(StudentCode, subject, module1Score, module2Score));
    }
    // представлення рейтингу студента за предмет
    public class Rating
    {
        public int StudentCode { get; set; }
        public string Subject { get; set; }
        public int Module1Score { get; set; }
        public int Module2Score { get; set; }

        //  для створення об'єкта рейтингу
        public Rating(int studentCode, string subject, int module1Score, int module2Score)
        {
            StudentCode = studentCode;
            Subject = subject;
            Module1Score = module1Score;
            Module2Score = module2Score;
        }

    }
}



