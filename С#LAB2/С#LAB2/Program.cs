using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student(1, new DateTime(2000, 1, 1), "Smith", "Group A"),
            new Student(2, new DateTime(2001, 2, 2), "Johnson", "Group B"),
            new Student(3, new DateTime(1999, 3, 3), "Williams", "Group A"),
            new Student(4, new DateTime(2002, 4, 4), "Brown", "Group B"),
            new Student(5, new DateTime(1998, 5, 5), "Jones", "Group A"),
            new Student(6, new DateTime(2003, 6, 6), "Davis", "Group B"),
            new Student(7, new DateTime(1997, 7, 7), "Miller", "Group A"),
            new Student(8, new DateTime(2004, 8, 8), "Wilson", "Group B"),
            new Student(9, new DateTime(1996, 9, 9), "Moore", "Group A"),
            new Student(10, new DateTime(2005, 10, 10), "Taylor", "Group B"),
            new Student(11, new DateTime(1995, 11, 11), "Anderson", "Group A"),
            new Student(12, new DateTime(2006, 12, 12), "Thomas", "Group B"),
            new Student(13, new DateTime(1994, 1, 13), "Jackson", "Group A"),
            new Student(14, new DateTime(2007, 2, 14), "White", "Group B"),
            new Student(15, new DateTime(1993, 3, 15), "Harris", "Group A"),
            new Student(16, new DateTime(2008, 4, 16), "Martin", "Group B"),
            new Student(17, new DateTime(1992, 5, 17), "Thompson", "Group A"),
            new Student(18, new DateTime(2009, 6, 18), "Garcia", "Group B"),
            new Student(19, new DateTime(1991, 7, 19), "Martinez", "Group A"),
            new Student(20, new DateTime(2010, 8, 20), "Robinson", "Group B")

        };

        //  рейтинг для студентів
        students[0].Ratings.Add(new Student.Rating(students[0].StudentCode, "Вища математика", 4, 3));
        students[0].Ratings.Add(new Student.Rating(students[0].StudentCode, "Дискретка",      5, 3));
        students[0].Ratings.Add(new Student.Rating(students[0].StudentCode, "Прогрмування",    2, 3));

        students[1].Ratings.Add(new Student.Rating(students[1].StudentCode, "Вища математика", 2, 5));
        students[1].Ratings.Add(new Student.Rating(students[1].StudentCode, "Дискретка",       3, 5));
        students[1].Ratings.Add(new Student.Rating(students[1].StudentCode, "Прогрмування", 2, 5));

        students[2].Ratings.Add(new Student.Rating(students[2].StudentCode, "Вища математика", 3, 3));
        students[2].Ratings.Add(new Student.Rating(students[2].StudentCode, "Дискретка",       1, 3));
        students[2].Ratings.Add(new Student.Rating(students[2].StudentCode, "Прогрмування", 3, 3));

        students[3].Ratings.Add(new Student.Rating(students[3].StudentCode, "Вища математика", 2, 5));
        students[3].Ratings.Add(new Student.Rating(students[3].StudentCode, "Дискретка",       2, 5));
        students[3].Ratings.Add(new Student.Rating(students[3].StudentCode, "Прогрмування", 2, 5));

        students[4].Ratings.Add(new Student.Rating(students[4].StudentCode, "Вища математика", 4, 3));
        students[4].Ratings.Add(new Student.Rating(students[4].StudentCode, "Дискретка",       4, 3));
        students[4].Ratings.Add(new Student.Rating(students[4].StudentCode, "Прогрмування", 4, 3));

        students[5].Ratings.Add(new Student.Rating(students[5].StudentCode, "Вища математика", 2, 5));
        students[5].Ratings.Add(new Student.Rating(students[5].StudentCode, "Дискретка",       2, 5));
        students[5].Ratings.Add(new Student.Rating(students[5].StudentCode, "Прогрмування", 2, 5));

        students[6].Ratings.Add(new Student.Rating(students[6].StudentCode, "Вища математика", 5, 3));
        students[6].Ratings.Add(new Student.Rating(students[6].StudentCode, "Дискретка",       5, 3));
        students[6].Ratings.Add(new Student.Rating(students[6].StudentCode, "Прогрмування", 5, 3));

        students[7].Ratings.Add(new Student.Rating(students[7].StudentCode, "Вища математика", 2, 5));
        students[7].Ratings.Add(new Student.Rating(students[7].StudentCode, "Дискретка",       2, 5));
        students[7].Ratings.Add(new Student.Rating(students[7].StudentCode, "Прогрмування", 2, 5));

        students[8].Ratings.Add(new Student.Rating(students[8].StudentCode, "Вища математика", 4, 3));
        students[8].Ratings.Add(new Student.Rating(students[8].StudentCode, "Дискретка",       4, 3));
        students[8].Ratings.Add(new Student.Rating(students[8].StudentCode, "Прогрмування", 4, 3));

        students[9].Ratings.Add(new Student.Rating(students[9].StudentCode, "Вища математика", 2, 5));
        students[9].Ratings.Add(new Student.Rating(students[9].StudentCode, "Дискретка",       2, 5));
        students[9].Ratings.Add(new Student.Rating(students[9].StudentCode, "Прогрмування", 2, 5));

        students[10].Ratings.Add(new Student.Rating(students[10].StudentCode, "Вища математика", 1, 3));
        students[10].Ratings.Add(new Student.Rating(students[10].StudentCode, "Дискретка",       1, 3));
        students[10].Ratings.Add(new Student.Rating(students[10].StudentCode, "Прогрмування", 1, 3));

        students[11].Ratings.Add(new Student.Rating(students[11].StudentCode, "Вища математика", 2, 5));
        students[11].Ratings.Add(new Student.Rating(students[11].StudentCode, "Дискретка",       2, 5));
        students[11].Ratings.Add(new Student.Rating(students[11].StudentCode, "Прогрмування", 2, 5));

        students[12].Ratings.Add(new Student.Rating(students[12].StudentCode, "Вища математика", 4, 3));
        students[12].Ratings.Add(new Student.Rating(students[12].StudentCode, "Дискретка",       4, 3));
        students[12].Ratings.Add(new Student.Rating(students[12].StudentCode, "Прогрмування", 4, 3));

        students[13].Ratings.Add(new Student.Rating(students[13].StudentCode, "Вища математика", 2, 5));
        students[14].Ratings.Add(new Student.Rating(students[14].StudentCode, "Вища математика", 5, 3));
        students[15].Ratings.Add(new Student.Rating(students[15].StudentCode, "Вища математика", 2, 5));
        students[16].Ratings.Add(new Student.Rating(students[16].StudentCode, "Вища математика", 3, 3));
        students[17].Ratings.Add(new Student.Rating(students[17].StudentCode, "Вища математика", 2, 5));
        students[18].Ratings.Add(new Student.Rating(students[18].StudentCode, "Вища математика", 4, 3));
        students[19].Ratings.Add(new Student.Rating(students[19].StudentCode, "Вища математика", 2, 5));


        TaskA(students);
        TaskB(students);
        TaskC(students);
    }

    public static void TaskA(List<Student> students)
    {
        // використовується LINQ-запит для вибору студентів
        var selectedStudents = students
            .Where(student => student.Ratings.Any(rating => rating.Subject == "Вища математика" && rating.Module1Score == 4))
            .Select(student => new { LastName = student.LastName, Group = student.Group });

        Console.WriteLine("Студенти з оцiнкою 4 з предмету 'Вища математика':");
        foreach (var student in selectedStudents)//LINQ-запит зберігаються в  selectedStudents
        {
            Console.WriteLine($"Прiзвище: {student.LastName}, Спецiальнiсть: {student.Group}");
        }
    }
    public static void TaskB(List<Student> students)
    {
        var topStudents = students
            .Where(student => student.Ratings.Any(rating =>
                rating.Subject == "Вища математика" || rating.Subject == "Дискретка" || rating.Subject == "Програмування"))
            .OrderByDescending(student =>
                student.Ratings.Where(rating =>
                    rating.Subject == "Вища математика" || rating.Subject == "Дискретка" || rating.Subject == "Програмування")
                    .Average(rating => rating.Module1Score))
            .Select(student => student.LastName);

        Console.WriteLine("Студенти з найвищим середнім рейтингом за перший модуль у предметах Вища математика, Programming, або Diskretka:");
        foreach (var lastName in topStudents)
        {
            Console.WriteLine($"Прiзвище: {lastName}");
        }
    }

    public static void TaskC(List<Student> students)
    {
        var groupSubjectAverage = students
            .SelectMany(student => student.Ratings, (student, rating) => new { student, rating })
            .GroupBy(x => new { x.student.Group, x.rating.Subject })
            .Select(group => new
            {
                Group = group.Key.Group,
                Subject = group.Key.Subject,
                AverageRating = group.Average(x => x.rating.Module1Score)
            });

        Console.WriteLine("Список з середнiми рейтингами для груп з усіх предметів:");
        foreach (var item in groupSubjectAverage)
        {
            Console.WriteLine($"Група: {item.Group}, Предмет: {item.Subject}, Середнiй рейтинг: {item.AverageRating:F2}");
        }
    }

}
