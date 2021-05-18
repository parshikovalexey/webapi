using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.ExtendedModels;
using Interfaces.Repositories;

namespace Implementation {
    public class BookService : IBookService {
        private readonly IBookRepository BookRepository;

        public BookService(IBookRepository bookRepository) {
            BookRepository = bookRepository;
        }


        public Book AddBook(Book book) {
            BookRepository.Add(book);
            BookRepository.SaveChanges();
            return book;
        }

        public bool DeleteBook(Book book) {
            BookRepository.Delete(book);
            BookRepository.SaveChanges();
            return true;
        }

        public Book GetBookById(Guid bookId) {
            return BookRepository.GetBookByID(bookId);
        }

        public IEnumerable<BookExtended> GetBooksByUserId(Guid userId) {
            // We need a lightweight method for getting all books for a user
            return BookRepository.GetBooksByUserId(userId).ToList();
        }

        public IEnumerable<BookExtended> GetMoreBooksByUserIdItemId(Guid userId, Guid itemId)
        {
            return BookRepository.GetMoreUserBooks(userId, itemId).ToList();
        }

        public Book UpdateBook(Book book) {
            BookRepository.Update(book);
            BookRepository.SaveChanges();
            return book;
        }
    }
}
