using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class Article : IArticle
    {
        private DAL.Article dal = new DAL.Article();
        public void Add(Entities.Article model)
        {
            dal.Add(model);
        }

        public void Update(Entities.Article model)
        {
            dal.Update(model);
        }

        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        public Entities.Article GetModel(int ID)
        {
            return dal.GetModel(ID);
        }

        public System.Data.DataTable GetList(string iswhere)
        {
            return dal.GetList(iswhere);
        }

        public System.Data.DataTable GetWholeList(string iswhere)
        {
            return dal.GetWholeList(iswhere);
        }

        public System.Data.DataTable GetWholeList(string iswhere, int number)
        {
            return dal.GetWholeList(iswhere, number);
        }

        public int GetMaxID()
        {
            return dal.GetMaxID();
        }

        public System.Data.DataTable GetList(string iswhere, int pagesize, int page)
        {
            return dal.GetList(iswhere, pagesize, page);
        }

        public int GetCount(string iswhere)
        {
            return dal.GetCount(iswhere);
        }
    }
}