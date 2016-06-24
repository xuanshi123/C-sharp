using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class User
    {
        public int ID
        {
            get;
            set;
        }

        public string UserID
        {
            get;
            set;
        }

        public string PassWord
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