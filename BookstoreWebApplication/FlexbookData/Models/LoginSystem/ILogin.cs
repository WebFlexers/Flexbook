using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexbookData.Models
{
    public interface ILogin
    {
        void Login(string username, string password);

        void Logout();
    }
}
