using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using my5Labka.models;

namespace Lab_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            lab6();
        }

        public static void lab6()
        {
            using (var context = new UniversityDb())
            {
                Console.WriteLine("Hello. Please enter numbers what you want to do: \n 1 - simple select, \n 2 - using spec func, \n 3 - complex criterion, 4 - unique values, \n 5 - calculated field, 6 - grouping query, \n 7 - sorting, \n 8 - update");

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Column name ([Group]): ");
                        string Acolumn = Console.ReadLine();

                        Console.WriteLine("Column value (A123): ");
                        string Avalue = Console.ReadLine();

                        var studentsA = context.Students.Where(s => EF.Property<string>(s, Acolumn) == Avalue);
                        DisplayStudents(studentsA);
                        break;

                    case 2:
                        Console.WriteLine("B. Using special functions: LIKE, IS NULL, IN, BETWEEN: ");

                        Console.WriteLine("B1.(LIKE) Column name ([City]): ");
                        string B1Column = Console.ReadLine();
                        Console.WriteLine("B1.(LIKE) Column value (Ки): ");
                        string B1Value = Console.ReadLine();
                        var studentsB1 = context.Students
                           .Where(s => s.Group == "A123" && EF.Functions.Like(s.City, $"{B1Value}%"));

                        Console.WriteLine("B2.(IS NULL) Column name ([Workplace]): ");
                        string B2Column = Console.ReadLine();
                        var studentsB2 = context.Students.Where(s => s.Workplace == null);
                        DisplayStudents(studentsB2);


                        Console.WriteLine("B3.(IN) Groups ('A123', 'B456'): ");
                        string[] groupArray = Console.ReadLine().Split(',');
                        var studentsB3 = context.Students.Where(s => groupArray.Contains(s.Group));

                        Console.WriteLine("B4.(BETWEEN) Start year: ");
                        int startYear = int.Parse(Console.ReadLine());
                        Console.WriteLine("B4.(BETWEEN) End year: ");
                        int endYear = int.Parse(Console.ReadLine());
                        var studentsB4 = context.Students.Where(s => s.BirthYear >= startYear && s.BirthYear <= endYear);

                        DisplayStudents(studentsB1);
                        DisplayStudents(studentsB2);
                        DisplayStudents(studentsB3);
                        DisplayStudents(studentsB4);
                        break;

                    case 3:
                        Console.WriteLine("C. Query with a complex criterion:");

                        var studentsC = context.Students.Where(s => s.Faculty == "Фізика" || s.AverageGrade > 4.5m);
                        DisplayStudents(studentsC);
                        break;

                    case 4:
                        Console.WriteLine("D. Unique values:");

                        var faculties = context.Students.Select(s => s.Faculty).Distinct();
                        foreach (var faculty in faculties)
                        {
                            Console.WriteLine($"Faculty: {faculty}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("E. Query using a calculated field:");

                        var studentsE = context.Students.Select(s => new
                        {
                            s.AverageGrade,
                            DifferenceFromMax = s.AverageGrade - context.Students.Max(st => st.AverageGrade)
                        });
                        foreach (var student in studentsE)
                        {
                            Console.WriteLine($"AverageGrade: {student.AverageGrade}, DifferenceFromMax: {student.DifferenceFromMax}");
                        }
                        break;

                    case 6:
                        Console.WriteLine("F. Grouping query:");

                        var groupedStudents = context.Students.GroupBy(s => s.Group)
                            .Select(group => new { Group = group.Key, Count = group.Count() });

                        foreach (var group in groupedStudents)
                        {
                            Console.WriteLine($"Group: {group.Group}, Count: {group.Count}");
                        }
                        break;

                    case 7:
                        Console.WriteLine("G. Sorting query in ascending and descending order:");

                        Console.WriteLine("Sort asc by: ");
                        Console.WriteLine("Column name (e.g., AverageGrade): ");
                        string G1Column = Console.ReadLine();
                        var studentsG1 = context.Students.OrderBy(s => EF.Property<object>(s, G1Column));

                        Console.WriteLine("Sort desc by: ");
                        Console.WriteLine("Column name (e.g., BirthYear): ");
                        string G2Column = Console.ReadLine();
                        var studentsG2 = context.Students.OrderByDescending(s => EF.Property<object>(s, G2Column));

                        DisplayStudents(studentsG1);
                        DisplayStudents(studentsG2);
                        break;

                    case 8:
                        Console.WriteLine("H. Update query:");
                        Console.WriteLine("Update City to 'Львів' where Group is 'A123'");

                        var studentsToUpdate = context.Students.Where(s => s.Group == "A123");
                        foreach (var student in studentsToUpdate)
                        {
                            student.City = "Львів";
                        }

                        int rowsAffected = context.SaveChanges();
                        Console.WriteLine($"Rows affected: {rowsAffected}");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void DisplayStudents(IQueryable<Student> students)
        {
            Console.WriteLine("Query Result:");
            foreach (var student in students)
            {
                Console.WriteLine($"StudentId: {student.StudentId}, LastName: {student.LastName}, BirthYear: {student.BirthYear}, Group: {student.Group}, Faculty: {student.Faculty}, AverageGrade: {student.AverageGrade}, Workplace: {student.Workplace ?? "N/A"}, City: {student.City ?? "N/A"}");
            }
        }
    }
}
