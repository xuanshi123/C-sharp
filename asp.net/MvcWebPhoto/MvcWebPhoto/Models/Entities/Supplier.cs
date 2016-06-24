using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class Supplier
    {
        public int ID
        {
            get;
            set;
        }

        public string SupplierName
        {
            get;
            set;
        }

        public string SupplierUrl
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