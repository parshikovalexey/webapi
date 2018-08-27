using Models.DomainModels;
using Models.ExtendedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositories {
    public interface IUserRepository : IBaseRepository<User, Guid> {
        User GetUserById(Guid userId);
        User GetUserByName(string name); // lastName , firstName
        IEnumerable<BookExtended> GetMoreUserBooks(Guid userId, Guid bookId);
    }
}
