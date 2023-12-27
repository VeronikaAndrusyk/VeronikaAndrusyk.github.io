using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using my5Labka.models;

namespace Lab_7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Lab7Async();
        }

        public static async Task Lab7Async()
        {
            using (var context = new UniversityDb())
            {
                Console.WriteLine("Привіт. Будь ласка, введіть номер опції: \n 1 - простий вибір, \n 2 - використання спеціальних функцій, \n 3 - складний критерій, 4 - унікальні значення, \n 5 - розрахункове поле, 6 - груповий запит, \n 7 - сортування, \n 8 - оновлення");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Назва стовпця ([Group]): ");
                        string Acolumn = Console.ReadLine();

                        Console.WriteLine("Значення стовпця (A123): ");
                        string Avalue = Console.ReadLine();

                        var studentsA = await context.Students.Where(s => EF.Property<string>(s, Acolumn) == Avalue).ToListAsync();
                        DisplayStudents(studentsA);
                        break;

                    case 2:
                        Console.WriteLine("B. Використання спеціальних функцій: LIKE, IS NULL, IN, BETWEEN: ");

                        Console.WriteLine("B1.(LIKE) Назва стовпця ([City]): ");
                        string B1Column = Console.ReadLine();
                        Console.WriteLine("B1.(LIKE) Значення стовпця (Ки): ");
                        string B1Value = Console.ReadLine();
                        var studentsB1 = await context.Students
                           .Where(s => s.Group == "A123" && EF.Functions.Like(s.City, $"{B1Value}%")).ToListAsync();

                        Console.WriteLine("B2.(IS NULL) Назва стовпця ([Workplace]): ");
                        string B2Column = Console.ReadLine();
                        var studentsB2 = await context.Students.Where(s => s.Workplace == null).ToListAsync();
                        DisplayStudents(studentsB2);

                        Console.WriteLine("B3.(IN) Групи ('A123', 'B456'): ");
                        string[] groupArray = Console.ReadLine().Split(',');
                        var studentsB3 = await context.Students.Where(s => groupArray.Contains(s.Group)).ToListAsync();

                        Console.WriteLine("B4.(BETWEEN) Початковий рік: ");
                        int startYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("B4.(BETWEEN) Кінцевий рік: ");
                        int endYear = int.Parse(Console.ReadLine());
                        var studentsB4 = await context.Students.Where(s => s.BirthYear >= startYear && s.BirthYear <= endYear).ToListAsync();

                        DisplayStudents(studentsB1);
                        DisplayStudents(studentsB2);
                        DisplayStudents(studentsB3);
                        DisplayStudents(studentsB4);
                        break;

                    case 3:
                        Console.WriteLine("C. Запит із складним критерієм:");

                        var studentsC = await context.Students.Where(s => s.Faculty == "Фізика" || s.AverageGrade > 4.5m).ToListAsync();
                        DisplayStudents(studentsC);
                        break;

                    case 4:
                        Console.WriteLine("D. Унікальні значення:");

                        var faculties = await context.Students.Select(s => s.Faculty).Distinct().ToListAsync();
                        foreach (var faculty in faculties)
                        {
                            Console.WriteLine($"Факультет: {faculty}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("E. Запит із використанням розрахункового поля:");

                        var studentsE = await context.Students.Select(s => new
                        {
                            s.AverageGrade,
                            РізницяВідМаксимуму = s.AverageGrade - context.Students.Max(st => st.AverageGrade)
                        }).ToListAsync();
                        foreach (var student in studentsE)
                        {
                            Console.WriteLine($"Середній бал: {student.AverageGrade}, РізницяВідМаксимуму: {student.РізницяВідМаксимуму}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("F. Груповий запит:");

                        var groupedStudents = await context.Students.GroupBy(s => s.Group)
                            .Select(group => new { Group = group.Key, Count = group.Count() }).ToListAsync();

                        foreach (var group in groupedStudents)
                        {
                            Console.WriteLine($"Група: {group.Group}, Кількість: {group.Count}");
                        }
                        break;

                    case 7:
                        Console.WriteLine("G. Сортування запиту у зростаючому та спадаючому порядку:");

                        Console.WriteLine("Сортувати за зростанням за: ");
                        Console.WriteLine("Назва стовпця (наприклад, AverageGrade): ");
                        string G1Column = Console.ReadLine();
                        var studentsG1 = await context.Students.OrderBy(s => EF.Property<object>(s, G1Column)).ToListAsync();

                        Console.WriteLine("Сортувати за спаданням за: ");
                        Console.WriteLine("Назва стовпця (наприклад, BirthYear): ");
                        string G2Column = Console.ReadLine();
                        var studentsG2 = await context.Students.OrderByDescending(s => EF.Property<object>(s, G2Column)).ToListAsync();

                        DisplayStudents(studentsG1);
                        DisplayStudents(studentsG2);
                        break;

                    case 8:
                        Console.WriteLine("H. Оновлюючий запит:");
                        Console.WriteLine("Оновити місто на 'Львів' для групи 'A123'");

                        var studentsToUpdate = await context.Students.Where(s => s.Group == "A123").ToListAsync();
                        foreach (var student in studentsToUpdate)
                        {
                            student.City = "Львів";
                        }

                        int rowsAffected = await context.SaveChangesAsync();
                        Console.WriteLine($"Вплив на рядки: {rowsAffected}");
                        break;

                    default:
                        Console.WriteLine("Неправильна опція");
                        break;
                }
            }
        }

        private static void DisplayStudents(IEnumerable<Student> students)
        {
            Console.WriteLine("Результат запиту:");
            foreach (var student in students)
            {
                Console.WriteLine($"StudentId: {student.StudentId}, LastName: {student.LastName}, BirthYear: {student.BirthYear}, Group: {student.Group}, Faculty: {student.Faculty}, AverageGrade: {student.AverageGrade}, Workplace: {student.Workplace ?? "N/A"}, City: {student.City ?? "N/A"}");
            }
        }
    }
}
