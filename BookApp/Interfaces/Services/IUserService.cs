using Interfaces.DTO;
using Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services {
    public interface IUserService {
        MyUser GetUserById(Guid userId);
        MyUser GetUserByName(string name);
        MyUser AddUser(MyUser user);
        MyUser UpdateUser(MyUser user);
        bool DeleteUser(MyUser user);
    }
}
