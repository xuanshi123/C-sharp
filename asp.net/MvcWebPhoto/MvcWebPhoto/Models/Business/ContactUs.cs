using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class ContactUs : IContactUs
    {
        private readonly DAL.ContactUs dal = new DAL.ContactUs();
        public void Add(Entities.ContactUs model)
        {
            dal.Add(model);
        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public Entities.ContactUs GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public System.Data.DataTable GetList(string iswhere)
        {
            return dal.GetList(iswhere);
        }

        public Models.Entities.EmailAccounts GetModelByEmailAccounts()
        {
            return dal.GetModelByEmailAccounts();
        }

        public void UpdateEmailAccounts(Entities.EmailAccounts model)
        {
            dal.UpdateEmailAccounts(model);
        }
    }
}