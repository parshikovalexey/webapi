using Interfaces.Repositories;
using Models.DomainModels;
using Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ExtendedModels;
using Unity;
using System.Data.Entity;

namespace Repository.Repositories {
    public class UserRepository : BaseRepository<User>, IUserRepository {
        public UserRepository(IUnityContainer container) : base(container) {
        }

        protected override IDbSet<User> DbSet => MasterDB.Users;

        public User GetUserById(Guid userId) {
            return GetAll().FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByName(string name) {
            return GetAll().FirstOrDefault(u => u.LastName == name);
        }
    }
}
