using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class User : IUser
    {
        private DAL.User dal = new DAL.User();
        public Entities.User GetModel(string userid)
        {
            return dal.GetModel(userid);
        }

        public void Update(string userid, string password)
        {
            dal.Update(userid, password);
        }

        public bool Login(string userid, string password)
        {
            return dal.Login(userid, password);
        }
    }
}