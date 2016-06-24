using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class Catalog
    {
        public int ID
        {
            get;
            set;
        }

        public string CatalogName
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