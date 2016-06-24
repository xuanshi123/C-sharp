using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models.Entities
{
    public class EmailAccounts
    {
        public string SendAddress
        {
            get;
            set;
        }

        public string SendAccounts
        {
            get;
            set;
        }

        public string SendUser
        {
            get;
            set;
        }

        public string SendPassword
        {
            get;
            set;
        }

        public string ReceiveAccounts
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }
    }
}