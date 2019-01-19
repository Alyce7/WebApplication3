using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUsersRepository: IDisposable
    {
        IEnumerable<Users> GetUsers();

        Users GetUserByID(int userId);

        void AddUser(Users user);

        void DeleteUser(int userId);

        void UpdateUser(Users user);

        void Save();
    }
}
