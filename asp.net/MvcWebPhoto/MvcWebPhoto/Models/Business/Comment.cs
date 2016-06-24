using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class Comment : IComment
    {
        private DAL.Comment dal = new DAL.Comment();
        public void Add(Entities.Comment model)
        {
            dal.Add(model);
        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public Entities.Comment GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public System.Data.DataTable GetList(string iswhere)
        {
            return dal.GetList(iswhere);
        }
    }
}