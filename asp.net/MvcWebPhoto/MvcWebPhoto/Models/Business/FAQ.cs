using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;
using MvcWebPhoto.DAL;
using System.Data;

namespace MvcWebPhoto.Models.Business
{
    public class FAQ : IFAQ
    {
        private DAL.FAQ dal = new DAL.FAQ();

        public int GetMaxID()
        {
            return dal.GetMaxID();
        }

        public void Add(Entities.FAQ model)
        {
            dal.Add(model);
        }

        public void Update(Entities.FAQ model)
        {
            dal.Update(model);
        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public Entities.FAQ GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public DataTable GetList(string iswhere)
        {
            return dal.GetList(iswhere);
        }

        public DataTable GetWholeList(string iswhere)
        {
            return dal.GetWholeList(iswhere);
        }
    }
}