using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class SysManage
    {
        public int ID
        {
            get;
            set;
        }

        public int Identity
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string Explain
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