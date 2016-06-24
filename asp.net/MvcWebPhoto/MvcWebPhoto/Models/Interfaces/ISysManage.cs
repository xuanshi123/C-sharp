using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcWebPhoto.Models.Entities;
using System.Data;

namespace MvcWebPhoto.Models.Interfaces
{
    public interface ISysManage
    {
        void Update(SysManage model);
        SysManage GetModel(int ID);
    }
}
