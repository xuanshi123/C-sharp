using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcWebPhoto.Models.Entities;
using System.Data;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface IComment
    {
        void Add(Comment model);
        void Delete(int ID);
        Comment GetModel(int ID);
        DataTable GetList(string iswhere);
    }
}