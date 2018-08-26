using Interfaces.DTO;
using Models.DomainModels;
using Models.ExtendedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services {
    public interface IBookService {
        MyBook GetBookById(Guid bookId);
        IEnumerable<MyBookExtended> GetBooksByUserId(Guid userId);
        MyBook AddBook(MyBook book);
        MyBook UpdateBook(MyBook book);
        bool DeleteBook(Guid bookId);
        bool BookIdExist(Guid bookId);
    }
}
