using CodeAcademyAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CodeAcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly List<Book> _listOfBooks;
        private readonly List<Author> _listOfAuthors;

        public BooksController()
        {
            _listOfAuthors = new List<Author>
            {
                new Author { Id = 1, FirstName = "John", LastName = "Doe" },
                new Author { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new Author { Id = 3, FirstName = "Alice", LastName = "Johnson" },
                new Author { Id = 4, FirstName = "Michael", LastName = "Brown" },
                new Author { Id = 5, FirstName = "David", LastName = "Wilson" }
            };

            _listOfBooks = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "C# Programming Basics",
                    Authors = new List<Author> { _listOfAuthors[0] }, // John Doe
                    Year = 2020
                },
                new Book
                {
                    Id = 2,
                    Title = "Advanced C# Programming",
                    Authors = new List<Author> { _listOfAuthors[0], _listOfAuthors[1] }, // John Doe, Jane Smith
                    Year = 2021
                },
                new Book
                {
                    Id = 3,
                    Title = "Introduction to ASP.NET",
                    Authors = new List<Author> { _listOfAuthors[1] }, // Jane Smith
                    Year = 2019
                },
                new Book
                {
                    Id = 4,
                    Title = "Mastering ASP.NET Core",
                    Authors = new List<Author> { _listOfAuthors[1], _listOfAuthors[4] }, // Jane Smith, David Wilson
                    Year = 2022
                },
                new Book
                {
                    Id = 5,
                    Title = "JavaScript Essentials",
                    Authors = new List<Author> { _listOfAuthors[2] }, // Alice Johnson
                    Year = 2020
                },
                new Book
                {
                    Id = 6,
                    Title = "JavaScript Advanced Topics",
                    Authors = new List<Author> { _listOfAuthors[2], _listOfAuthors[3] }, // Alice Johnson, Michael Brown
                    Year = 2021
                },
                new Book
                {
                    Id = 7,
                    Title = "Python for Beginners",
                    Authors = new List<Author> { _listOfAuthors[3] }, // Michael Brown
                    Year = 2020
                },
                new Book
                {
                    Id = 8,
                    Title = "Deep Dive into Python",
                    Authors = new List<Author> { _listOfAuthors[3] }, // Michael Brown
                    Year = 2023
                },
                new Book
                {
                    Id = 9,
                    Title = "Data Science with Python",
                    Authors = new List<Author> { _listOfAuthors[3], _listOfAuthors[4] }, // Michael Brown, David Wilson
                    Year = 2021
                },
                new Book
                {
                    Id = 10,
                    Title = "C# Patterns and Practices",
                    Authors = new List<Author> { _listOfAuthors[0] }, // John Doe
                    Year = 2023
                }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks([FromQuery] string? author)
        {
            var books = _listOfBooks
                .Where(book => string.IsNullOrEmpty(author) ||
                               book.Authors.Any(a =>
                                   a.FirstName.Contains(author, StringComparison.OrdinalIgnoreCase) ||
                                   a.LastName.Contains(author, StringComparison.OrdinalIgnoreCase)))
                .ToList();



            if (!books.Any())
                return NoContent();

            return Ok(books);
        }

    }
}
