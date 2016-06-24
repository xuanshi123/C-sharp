using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MvcWebPhoto.Models.Entities;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface IContactUs
    {
        void Add(ContactUs model);
        void Delete(int ID);
        void UpdateEmailAccounts(EmailAccounts model);
        ContactUs GetModel(int ID);
        EmailAccounts GetModelByEmailAccounts();
        DataTable GetList(string iswhere);
    }
}