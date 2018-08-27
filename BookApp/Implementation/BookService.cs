using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Models.ExtendedModels;
using Interfaces.Repositories;
using Interfaces.DTO;

namespace Implementation {

    /*
     * Changed Book to a DTO MyBook 
     * 
     * Changed Delete(Book book) to Delete(GUID bookId)
     */
    public class BookService : IBookService {
        private readonly IBookRepository BookRepository;
        private readonly IUserRepository UserRepository;

        public BookService(IBookRepository bookRepository, IUserRepository userRepository) {
            BookRepository = bookRepository;
            UserRepository = userRepository;
        }


        public MyBook AddBook(MyBook myBook) {
            Book book = new Book
            {
                Author = myBook.Author,
                Content = myBook.Content,
                Id = myBook.Id,
                UserId = myBook.UserId,
                User = UserRepository.Find(myBook.UserId),
                CreatedDatetime = myBook.CreatedDatetime,
                Title = myBook.Title
            };

            BookRepository.Add(book);
            BookRepository.SaveChanges();
            return myBook;
        }

        public bool DeleteBook(Guid bookId) {
            BookRepository.Delete(BookRepository.Find(bookId));
            BookRepository.SaveChanges();
            return true;
        }

       

        public MyBook GetBookById(Guid bookId) {
            Book book = BookRepository.Find(bookId);
            return new MyBook
            {
                Author = book.Author,
                Content = book.Content,
                Id = book.Id,
                UserId = book.UserId,
               // User = UserRepository.GetUserById(book.UserId),
                CreatedDatetime = book.CreatedDatetime,
                Title = book.Title
            };
            
        }

        /*
         * Changed BookExtended to DTO MyBookExtended
         * The method return a List of books by userId
         * MoreUserBooks holds also a list of user's ExtendedBooks.
         * 
         * we could either change the method to return the Object BookExtended holding the list of book own by the user - 
         *  
         *  Change  public IEnumerable<MyExtendedBook> MoreUserBooks { get; set; } 
         *
         *   to    =>   public IEnumerable<MyBook> MoreUserBooks { get; set; }
         * 
         * or removed the MoreUserBooks property and return a List of BookExtended object by userID    
         * 
         * 
         */
        public IEnumerable<MyBookExtended> GetBooksByUserId(Guid userId) {
            var books = BookRepository.GetBooksByUserId(userId).ToList();
            var result = new List<MyBookExtended>();
            foreach (var book in books) {
                var user = UserRepository.Find(book.UserId);
                string username = user.FirstName + user.LastName;
              
                result.Add(new MyBookExtended {
                    Author  = book.Author,
                    Content = book.Content,
                    Id      = book.Id,
                    UserId  = book.UserId,
                    UserName = username,
                    Title   = book.Title,
                    CreatedDatetime = book.CreatedDatetime
                });
            }
            return result;
        }

        public MyBook UpdateBook(MyBook book) {
            Book _book = new Book
            {
                Author = book.Author,
                Content = book.Content,
                Id = book.Id,
                UserId = book.UserId,
                User = UserRepository.Find(book.UserId),
                CreatedDatetime = book.CreatedDatetime,
                Title = book.Title
            };
            BookRepository.Update(_book);
            BookRepository.SaveChanges();
            return book;
        }

        public bool BookIdExist(Guid bookId)
        {
            if (GetBookById(bookId) != null)
                return true;

            return false;
        }
    }
}
