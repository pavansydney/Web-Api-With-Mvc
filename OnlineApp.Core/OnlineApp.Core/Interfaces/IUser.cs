using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Interfaces
{
    public interface IUser
    {
        User LoginValidate(User user);

        //User GetByUserId(string username, string password);

        bool Registration(User user);

        IEnumerable<User> GetUsers();

        void EditUser(User user);

        User FindUserById(int User_Id);
    }
}
