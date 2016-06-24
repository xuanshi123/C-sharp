using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.Models.Business
{
    public class SysManage : ISysManage
    {
        MvcWebPhoto.DAL.SysManage dal = new DAL.SysManage();

        public void Update(Entities.SysManage model)
        {
            dal.Update(model);
        }

        public Entities.SysManage GetModel(int ID)
        {
            return dal.GetModel(ID);
        }
    }
}