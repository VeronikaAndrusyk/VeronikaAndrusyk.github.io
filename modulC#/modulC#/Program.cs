using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace LibrarySystem
{
    public class Library
    {
        public string BookCode { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class Readers
    {
        public string ReaderName { get; set; }
        public string BookCode { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateReturned { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // просто інформація для тестування
            var libraryCollection = new List<Library>
            {
                new Library { BookCode = "B001", Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
                new Library { BookCode = "B002", Title = "To Kill a Mockingbird", Author = "Harper Lee" }
            };

            var readersCollection = new List<Readers>
            {
                new Readers { ReaderName = "John Doe", BookCode = "B001", DateIssued = new DateTime(2022, 5, 15), DateReturned = DateTime.MinValue },
                new Readers { ReaderName = "Jane Doe", BookCode = "B002", DateIssued = new DateTime(2022, 8, 20), DateReturned = new DateTime(2022, 9, 5) },
                new Readers { ReaderName = "Alice Smith", BookCode = "B001", DateIssued = new DateTime(2022, 10, 10), DateReturned = DateTime.MinValue }
            };

            // код для завадння a)
            DateTime lastYear = DateTime.Now.AddYears(-1);
            Console.WriteLine("Читачi, якi обрали книги минулого року i ще не повернули їх:");
            foreach (var reader in readersCollection)
            {
                if (reader.DateIssued.Year == lastYear.Year && reader.DateReturned == DateTime.MinValue)
                {
                    Console.WriteLine(reader.ReaderName);
                }
            }

            // код для завдання b)
            Dictionary<string, Tuple<string, int, int>> booksData = new Dictionary<string, Tuple<string, int, int>>();
            foreach (var reader in readersCollection)
            {
                if (booksData.ContainsKey(reader.BookCode))
                {
                    var data = booksData[reader.BookCode];
                    booksData[reader.BookCode] = new Tuple<string, int, int>(data.Item1, data.Item2 + 1, data.Item3 + (reader.DateReturned == DateTime.MinValue ? 0 : 1));
                }
                else
                {
                    string title = libraryCollection.Find(x => x.BookCode == reader.BookCode)?.Title;
                    booksData.Add(reader.BookCode, new Tuple<string, int, int>(title, 1, reader.DateReturned == DateTime.MinValue ? 0 : 1));
                }
            }

            Console.WriteLine("\nКоди, назви та загальна кiлькiсть видань i повернень цих книг:");
            foreach (var book in booksData)
            {
                Console.WriteLine($"Код: {book.Key}, Назва: {book.Value.Item1}, загальна кiлькiсть видань: {book.Value.Item2}, загальна кiлькiсть повернень: {book.Value.Item3}");
            }

            // код для завдання c)
            string filePath = "data.xml";

            using (XmlWriter writer = XmlWriter.Create(filePath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Data");

                foreach (var item in libraryCollection)
                {
                    writer.WriteStartElement("Book");
                    writer.WriteElementString("BookCode", item.BookCode);
                    writer.WriteElementString("Title", item.Title);
                    writer.WriteElementString("Author", item.Author);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("\nData saved to data.xml");
        }
    }
}

