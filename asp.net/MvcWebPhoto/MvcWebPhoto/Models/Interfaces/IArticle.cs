using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MvcWebPhoto.Models.Entities;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface IArticle
    {
        void Add(Article model);
        void Update(Article model);
        void Delete(int ID);
        Article GetModel(int ID);
        DataTable GetList(string iswhere);
        DataTable GetWholeList(string iswhere);
        DataTable GetWholeList(string iswhere, int number);
        DataTable GetList(string iswhere, int pagesize, int page);
        int GetCount(string iswhere);
        int GetMaxID();
    }
}
