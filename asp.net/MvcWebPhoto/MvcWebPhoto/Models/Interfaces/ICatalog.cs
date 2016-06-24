using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcWebPhoto.Models.Entities;
using System.Data;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface ICatalog
    {
        void Add(Catalog model);
        void Update(Catalog model);
        void Delete(int ID);
        Catalog GetModel(int ID);
        DataTable GetList(string iswhere);
        int GetMaxID();
    }
}