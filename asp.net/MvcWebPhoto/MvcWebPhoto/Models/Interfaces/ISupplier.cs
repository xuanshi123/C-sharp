using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcWebPhoto.Models.Entities;
using System.Data;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface ISupplier
    {
        void Add(Supplier model);
        void Update(Supplier model);
        void Delete(int ID);
        Supplier GetModel(int ID);
        DataTable GetList(string iswhere);
        int GetMaxID();
    }
}
