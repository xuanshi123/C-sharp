using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Controllers
{
    public class ControllersUtility
    {
        /// <summary>
        /// 新增的标识
        /// </summary>
        public static string Add_Url
        {
            get
            {
                return "Add_Url";
            }
        }
        /// <summary>
        /// 修改的标识
        /// </summary>
        public static string Modify_Url
        {
            get
            {
                return "Modify_Url";
            }
        }

        /// <summary>
        /// 删除的标识
        /// </summary>
        public static string Delete_Url
        {
            get
            {
                return "Delete_Url";
            }
        }

        /// <summary>
        /// 保存的标识
        /// </summary>
        public static string Update_Method
        {
            get
            {
                return "Update_Method";
            }
        }
    }
}