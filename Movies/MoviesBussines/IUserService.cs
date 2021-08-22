using System;
using System.Collections.Generic;
using System.Text;
using Movies.Models;

namespace Movies.Business
{
    public interface IUserService
    {
        User GetUser(string userName, string password);
    }
}
