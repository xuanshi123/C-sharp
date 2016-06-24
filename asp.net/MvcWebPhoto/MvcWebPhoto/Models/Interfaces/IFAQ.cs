using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcWebPhoto.Models.Entities;
using System.Data;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface IFAQ
    {
        void Add(FAQ model);
        void Update(FAQ model);
        void Delete(int ID);
        FAQ GetModel(int ID);
        DataTable GetList(string iswhere);
        DataTable GetWholeList(string iswhere);
        int GetMaxID();
    }
}
