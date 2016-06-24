using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebPhoto.Models
{
    /// <summary>
    /// 服务组件，用于Business层与表
    /// </summary>
    public sealed class ServerBuilder
    {
        /// <summary>
        /// 用户服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.User BuilderUser()
        {
            return new Business.User();
        }

        /// <summary>
        /// FAQ服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.FAQ BuilderFAQ()
        {
            return new Business.FAQ();
        }

        /// <summary>
        /// Catalog服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.Catalog BuilderCatalog()
        {
            return new Business.Catalog();
        }

        /// <summary>
        /// Article服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.Article BuilderArticle()
        {
            return new Business.Article();
        }

        /// <summary>
        /// SysManage服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.SysManage BuilerSysManage()
        {
            return new Business.SysManage();
        }

        /// <summary>
        /// Supplier服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.Supplier BuilerSupplier()
        {
            return new Business.Supplier();
        }

        /// <summary>
        /// ContactUs服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.ContactUs BuilerContactUs()
        {
            return new Business.ContactUs();
        }

        /// <summary>
        /// Comment服务组件
        /// </summary>
        /// <returns></returns>
        public static Business.Comment BuilerComment()
        {
            return new Business.Comment();
        }
    }
}