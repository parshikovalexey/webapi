using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.DomainModels;
using Interfaces.Repositories;
using Interfaces.DTO;

namespace Implementation {
    public class UserService : IUserService {
        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository userRepository) {
            UserRepository = userRepository;
        }
        public MyUser AddUser(MyUser myUser) {
            var user = ConvertMyUserDtoToUser(myUser);
            UserRepository.Add(user);
            UserRepository.SaveChanges();
            return myUser;
        }

        public bool DeleteUser(MyUser myUser)
        {
            var user = ConvertMyUserDtoToUser(myUser);
            UserRepository.Delete(user);
            UserRepository.SaveChanges();
            return true;
        }

        public MyUser GetUserById(Guid userId) {
            var myUser = ConvertUserToMyUserDTO(UserRepository.GetUserById(userId));
            return myUser;
        }

        public MyUser GetUserByName(string name) {
            var myUser = ConvertUserToMyUserDTO(UserRepository.GetUserByName(name));
            return myUser;
        }

        public MyUser UpdateUser(MyUser myUser)
        {
            var user = ConvertMyUserDtoToUser(myUser);
            UserRepository.Update(user);
            UserRepository.SaveChanges();
            return myUser;
        }

        private User ConvertMyUserDtoToUser(MyUser myUser)
        {
            ICollection<Book> myBooks = new List<Book>();
            myUser.Books.ToList().ForEach(b =>myBooks.Add( new Book
            {
                Author  = b.Author,
                Content = b.Content,
                Id      = b.Id,
                UserId  = b.UserId,
                User    = UserRepository.GetUserById(b.UserId),
                CreatedDatetime = b.CreatedDatetime,
                Title   = b.Title
            })); 
            return new User
            {
                Id          = myUser.Id,
                FirstName   = myUser.FirstName,
                LastName    = myUser.LastName,
                Books       = myBooks
            };
        }

        private MyUser ConvertUserToMyUserDTO(User user)
        {
            ICollection<MyBook> myBooks = new List<MyBook>();
            user.Books.ToList().ForEach(b => myBooks.Add(new MyBook
            {
                Author = b.Author,
                Content = b.Content,
                Id = b.Id,
                UserId = b.UserId,
                CreatedDatetime = b.CreatedDatetime,
                Title = b.Title
            }));

            return new MyUser
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Books = myBooks
            };
        }
    }
}
