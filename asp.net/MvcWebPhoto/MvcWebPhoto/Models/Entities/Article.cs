using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class Article
    {
        public int ID
        {
            get;
            set;
        }

        public int CatalogID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }
    }
}