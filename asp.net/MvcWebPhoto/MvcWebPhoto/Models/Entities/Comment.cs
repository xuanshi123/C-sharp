using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class Comment
    {
        public int ID
        {
            get;
            set;
        }

        public int ArticleID
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string Creator
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