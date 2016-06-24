using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class Supplier:ISupplier
    {
        private DAL.Supplier dal = new DAL.Supplier();
        public void Add(Entities.Supplier model)
        {
            dal.Add(model);
        }

        public void Update(Entities.Supplier model)
        {
            dal.Update(model);
        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public Entities.Supplier GetModel(int ID)
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