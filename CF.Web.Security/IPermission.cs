using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CF.Web.Security
{
    public interface IPermission
    {
        string Name
        {
            get;
        }

        int PermissionId
        {
            get;
        }
    }
}