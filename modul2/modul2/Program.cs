using modul2.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul2.models
{
    internal class Program
    {
        const string connection_string = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Asus\OneDrive\Робочий стіл\C#\modul2\modul2\Biblioteka.mdf"";Integrated Security=True;Connect Timeout=30";

        public static void FUNC()
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                connection.Open();
                Console.Write("kod: ");
                string kod = Console.ReadLine();

                Console.Write("surname: ");
                string surname = Console.ReadLine();

                Console.Write("title: ");
                string title = Console.ReadLine();

                Console.Write("year: ");
                if (!int.TryParse(Console.ReadLine(), out int year) || year <= 0)
                {
                    Console.WriteLine("Invalid input for year. Please enter a valid positive integer.");
                    return;
                }

                Console.Write("price: ");
                string price = Console.ReadLine();

                string sqlQuery = "INSERT INTO Biblioteka (kod, surname, title, year, price) VALUES (@Kod, @Surname, @Title, @Year, @Price)";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);

                sqlCommand.Parameters.AddWithValue("@Kod", kod);
                sqlCommand.Parameters.AddWithValue("@Surname", surname);
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlCommand.Parameters.AddWithValue("@Year", year);
                sqlCommand.Parameters.AddWithValue("@Price", price);

                sqlCommand.ExecuteNonQuery();

                Console.WriteLine("Added biblioteka's data successfully!");
            }
        }

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
            Console.WriteLine("Hello. Please enter numbers what you want to do: \n 1 - simple select, \n 2 - authSurname, \n 3 - Price");

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return;
            }

            switch (option)
            {
                case 1:
                    // Виведення всіх даних у консоль
                    string selectQuery = "SELECT * FROM Biblioteka";
                    Console.WriteLine($"Generated SQL Query: {selectQuery}");

                    ExecuteQuery(selectQuery);
                    break;

                case 2:
                    Console.WriteLine("Column name for author's surname (e.g., [surname]): ");
                    string B1Column = Console.ReadLine();
                    Console.WriteLine("Author's code (e.g., 1): ");
                    if (!int.TryParse(Console.ReadLine(), out int authorCode))
                    {
                        Console.WriteLine("Invalid input for author code. Please enter a valid integer.");
                        return;
                    }

                    // Виведення прізвища автора, назви книги та року видання за кодом
                    string selectQueryB1 = $"SELECT {B1Column}, title, year FROM Biblioteka WHERE kod = {authorCode}";
                    Console.WriteLine($"Generated SQL Query: {selectQueryB1}");

                    ExecuteQuery(selectQueryB1);
                    break;
                case 3:
                    Console.WriteLine("Enter the year (e.g., 2000): ");
                    if (!int.TryParse(Console.ReadLine(), out int year))
                    {
                        Console.WriteLine("Invalid input for the year. Please enter a valid integer.");
                        return;
                    }

                    // Виведення сумарної ціни книг
                    string selectQueryB2 = $"SELECT SUM(price) AS sumarna_tsina FROM Biblioteka WHERE kilkist_storinok BETWEEN 100 AND 200 AND year = {year}";
                    Console.WriteLine($"Generated SQL Query: {selectQueryB2}");

                    ExecuteQuery(selectQueryB2);
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
