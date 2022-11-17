using System;
using System.Collections.Generic;
using System.Linq;

namespace DebuggingDemo
{
    class Program
    {
        private static List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, Name = "Stephen King" },
            new Author { Id = 2, Name = "Sylvia Plath" },
            new Author { Id = 3, Name = "Martin Fowler" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "The Shining", AuthorId = 1 },
            new Book { Id = 2, Title = "The Gunslinger", AuthorId = 1 },
            new Book { Id = 3, Title = "The Bell Jar", AuthorId = 2 },
            new Book { Id = 4, Title = "Refactoring", AuthorId = 3 },
            new Book { Id = 5, Title = "Lady Lazarus", AuthorId = 2 },
        };

        static void Main(string[] args)
        {
            var author = GetAuthorByName("Stephen King");

            if (author == null)
            {
                Console.WriteLine("Author was not found");
            }

            var books = GetBooksByAuthor(author.Id);

            if (books == null)
            {
                Console.WriteLine("No books by that author");
            }

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }

        private static Author GetAuthorByName(string name)
        {
            var author = _authors.FirstOrDefault(a => a.Name == name);
            return author;
        }

        private static List<Book> GetBooksByAuthor(int authorId)
        {
            var books = _books.Where(b => b.AuthorId == authorId).ToList();
            return books;
        }
    }
}