using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcWebPhoto.Models.Entities;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface IUser
    {
        User GetModel(string userid);
        bool Login(string userid, string password);
        void Update(string userid, string password);
    }
}