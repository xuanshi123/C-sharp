using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class Catalog : ICatalog
    {
        MvcWebPhoto.DAL.Catalog dal = new DAL.Catalog();

        public void Add(Entities.Catalog model)
        {
            dal.Add(model);
        }

        public void Update(Entities.Catalog model)
        {
            dal.Update(model);
        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public Entities.Catalog GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public System.Data.DataTable GetList(string iswhere)
        {
            return dal.GetList(iswhere);
        }

        public int GetMaxID()
        {
            return dal.GetMaxID();
        }
    }
}