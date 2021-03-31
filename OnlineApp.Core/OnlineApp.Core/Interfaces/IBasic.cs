using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Interfaces
{
    public interface IBasic
    {
        IEnumerable<Basic> GetManufacturersIdName();
        IEnumerable<Basic> GetTypeIdName();
        IEnumerable<Basic> GetAuthorizationStatusIdName();

        IEnumerable<Basic> GetUsersIdName();
    }
}
