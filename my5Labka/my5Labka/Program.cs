using my5Labka.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Program
    {
        const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Asus\OneDrive\Робочий стіл\C#\my5Labka\my5Labka\SA2ANDRUSYK.mdf"";Integrated Security=True;Connect Timeout=30";
        


        static void ExecuteQuery(string query)
        {

            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                connection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, connection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    Console.WriteLine("Query Result:");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}: {reader[i]} ");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public static void lab6()
        {

            Console.WriteLine("Hello. Please enter numbers what you want to do: \n 1 - simple select, \n 2 - using spec func, \n 3 - complex criterion, 4 - unique values, \n 5 - calculated field, 6 - grouping query, \n 7 - sorting, \n 8 - update");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Column name ( Group): ");
                    string Acolumn = Console.ReadLine();

                    Console.WriteLine("Column value ( A123): ");
                    string Avalue = Console.ReadLine();

                    // a) Simple select query
                    string selectQueryA = $"SELECT * FROM students WHERE [{Acolumn}] = '{Avalue}'";
                    Console.WriteLine($"Generated SQL Query: {selectQueryA}");

                    ExecuteQuery(selectQueryA);
                    break;

                case 2:

                    Console.WriteLine("B. Using special functions: LIKE, IS NULL, IN, BETWEEN: ");

                    // B1. (LIKE) Column name and value
                    Console.WriteLine("B1.(LIKE) Column name ([City]): ");
                    string B1Column = Console.ReadLine();
                    Console.WriteLine("B1.(LIKE) Column value ( Ки): ");
                    string B1Value = Console.ReadLine();
                    string selectQueryB1 = $"SELECT * FROM students WHERE [Group] = 'A123' AND {B1Column} LIKE '{B1Value}%'";

                    // B2. (IS NULL) Column name
                    Console.WriteLine("B2.(IS NULL) Column name ( [Workplace]): ");
                    string B2Column = Console.ReadLine();
                    string selectQueryB2 = $"SELECT * FROM students WHERE {B2Column} IS NULL";

                    // B3. (IN)
                    Console.WriteLine("B3.(IN) Groups ( 'A123', 'B456'): ");
                    string[] groupArray = Console.ReadLine().Split(',');
                    string groupsInClause = string.Join(", ", groupArray.Select(group => $"'{group.Trim()}'"));
                    string selectQueryB3 = $"SELECT * FROM students WHERE [Group] IN ({groupsInClause})";

                    // B4. (BETWEEN) Birth years
                    Console.WriteLine("B4.(BETWEEN) Start year: ");
                    int startYear = int.Parse(Console.ReadLine());
                    Console.WriteLine("B4.(BETWEEN) End year: ");
                    int endYear = int.Parse(Console.ReadLine());
                    string selectQueryB4 = $"SELECT * FROM students WHERE [BirthYear] BETWEEN {startYear} AND {endYear}";

                    // Execute queries
                    ExecuteQuery(selectQueryB1);
                    ExecuteQuery(selectQueryB2);
                    ExecuteQuery(selectQueryB3);
                    ExecuteQuery(selectQueryB4);
                    break;

                case 3:
                    Console.WriteLine("c) Query with a complex criterion:");
                    // c) Запит зі складним критерієм:
                    string selectQueryC = "SELECT * FROM students WHERE ([Faculty] = 'Фізика' OR [AverageGrade] > 4.5)";
                    ExecuteQuery(selectQueryC);
                    break;

                case 4:
                    Console.WriteLine("D. Unique values:");

                    // d) Запит з унікальними значеннями:
                    string selectQueryD = "SELECT DISTINCT [Faculty] FROM students";
                    ExecuteQuery(selectQueryD);
                    break;

                case 5:
                    Console.WriteLine("e) Query using a calculated field:");

                    // e) Запит з використанням обчислювального поля:
                    string selectQueryE = "SELECT [AverageGrade], [AverageGrade] - (SELECT MAX([AverageGrade]) FROM Students) AS 'Різниця від максимального балу' FROM Students";
                    ExecuteQuery(selectQueryE);
                    break;

                case 6:
                    Console.WriteLine("f) Grouping query:");

                    // f) Запит з групуванням по заданому полю, використовуючи умову групування:
                    string selectQueryF = "SELECT [Group], COUNT(*) AS 'Кількість студентів' FROM Students GROUP BY [Group]";
                    ExecuteQuery(selectQueryF);
                    break;

                case 7:
                    Console.WriteLine("g) Sorting query in ascending and descending order:");

                    // g) Запит із сортуванням по заданому полю в порядку зростання та спадання значень:
                    Console.WriteLine("Sort asc by: ");
                    Console.WriteLine("Column name (e.g., [AverageGrade]): ");
                    string G1Column = Console.ReadLine();
                    string selectQueryG1 = $"SELECT * FROM students ORDER BY {G1Column} ASC";
                    ExecuteQuery(selectQueryG1);

                    Console.WriteLine("Sort desc by: ");
                    Console.WriteLine("Column name (e.g., [BirthYear]): ");
                    string G2Column = Console.ReadLine();
                    string selectQueryG2 = $"SELECT * FROM students ORDER BY {G2Column} DESC";
                    ExecuteQuery(selectQueryG2);
                    break;
                case 8:
                    Console.WriteLine("h) Update query:");
                    // h) Запит з використанням дій по модифікації записів:
                    string updateQueryH = "UPDATE Students SET [City] = 'Львів' WHERE [Group] = 'A123'";
                    ExecuteQuery(updateQueryH);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        static void Main(string[] args)
        {
            lab6();
        }
    }
}