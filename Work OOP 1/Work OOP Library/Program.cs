using System;
using System.Collections.Generic;

namespace Work_OOP_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool isWork = true;

            while(isWork)
            {
                Console.WriteLine("Library book menu\n \nAdd\nRemuve\nFined\nEsc\n");
                string comand = Console.ReadLine();
                Console.Clear();

                switch(comand)
                {
                    case "Add":
                        library.AddBook();
                        break;
                    case "Remuve":
                        library.RemoveBook();
                        break;
                    case "Fined":
                        library.FinedBook();
                        break;
                    case "Esc":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Book
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int ReleaseDate { get; private set; }

        public Book(string name, string author, int releaseDate)
        {
            Name = name;
            Author = author;
            ReleaseDate = releaseDate;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook()
        {
            string name;
            string author;
            int releaseDate;

            Console.Write("Enter name: ");
            name = Console.ReadLine();
            Console.Write("Enter Author: ");
            author = Console.ReadLine();
            Console.Write("Enter date release: ");
            releaseDate = GetInputDate();

            books.Add(new Book(name, author, releaseDate));
        }

        public void RemoveBook()
        {
            if(TryGetBook(out Book book))
            {
                books.Remove(book);
            }
        }

        public void FinedBook()
        {
            Console.WriteLine("Fined: \nAll\nName\nAuthor\nDate");
            string comand = Console.ReadLine();

            switch (comand)
            {
                case "All":
                    ShowAllBooks();
                    break;
                case "Name":
                    FindByName();
                    break;
                case "Author":
                    FindByAuthor();
                    break;
                case "Date":
                    FindByDate();
                    break;
            }
        }

        private void ShowAllBooks()
        {
            foreach(Book book in books)
            {
                Console.WriteLine($"Name: {book.Name}\nAuthor: {book.Author}\nDate {book.ReleaseDate}");
            }
        }

        private void FindByDate()
        {
            Console.Write("Enter date: ");
            int date = GetInputDate();

            foreach(Book book in books)
            {
                if(date == book.ReleaseDate)
                {
                    Console.WriteLine($"Name: {book.Name}\nAuthor: {book.Author}\nDate {book.ReleaseDate}");
                }
            }
        }

        private void FindByAuthor()
        {
            Console.Write("Enter author: ");
            string author = Console.ReadLine();

            foreach (Book book in books)
            {
                if (author == book.Author)
                {
                    Console.WriteLine($"Name: {book.Name}\nAuthor: {book.Author}\nDate {book.ReleaseDate}");
                }
            }
        }

        private void FindByName()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            foreach (Book book in books)
            {
                if (name == book.Name)
                {
                    Console.WriteLine($"Name: {book.Name}\nAuthor: {book.Author}\nDate {book.ReleaseDate}");
                }
            }
        }

        private bool TryGetBook(out Book book)
        {
            Console.Write("Enter number of book for remuve: ");
            bool isNumber = int.TryParse(Console.ReadLine(), out int inputNumber);

            if(isNumber)
            {
                book = books[inputNumber - 1];
                return true;
            }
            else
            {
                Console.WriteLine("Error");
                book = null;
                return false;
            }
        }

        private int GetInputDate()
        {
            bool isNumber = int.TryParse(Console.ReadLine(), out int dateRelease);

            if(isNumber)
            {
                return dateRelease;
            }
            else
            {
                Console.WriteLine("Error");
                return dateRelease = 0;
            }
        }
    }
}
