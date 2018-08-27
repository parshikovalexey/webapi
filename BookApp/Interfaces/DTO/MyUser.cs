using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.DTO
{
    public class MyUser
    {
        public MyUser()
        {
            Books = new HashSet<MyBook>();
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<MyBook> Books { get; set; }
    }
}
