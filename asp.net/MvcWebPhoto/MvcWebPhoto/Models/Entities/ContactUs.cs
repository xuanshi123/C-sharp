using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class ContactUs
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Mobile
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