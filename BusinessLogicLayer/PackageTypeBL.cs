using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class PackageTypeBL
    {
       public static DataSet FetchPackageTypes(string strSearchKey, string strSearchCol)
       {
           DataSet ds;
           ProcedureExecute proc = new ProcedureExecute("sp_PackageType");
           proc.AddVarcharPara("@Mode", 10, "all");
           if (strSearchKey != "")
           {
               proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
               proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
           }
           ds = proc.GetDataSet();
           return ds;
       }
       public static Boolean DeletePackageType(int id)
       {
           Boolean stat=false;
           ProcedureExecute proc = new ProcedureExecute("sp_PackageType");
           proc.AddVarcharPara("@Mode", 10, "delete");
           proc.AddIntegerPara("@PackageTypeId", id);
           int i= proc.RunActionQuery();
           if (i > 0)
           {
               stat = true;
           }
           return stat;
       }

       public static Boolean UpdatePackageType(int id, string strPType, ref int isExists)
       {
           Boolean stat = false;
           ProcedureExecute proc = new ProcedureExecute("sp_PackageType");
           proc.AddVarcharPara("@Mode", 10, "update");
           proc.AddIntegerPara("@PackageTypeId", id);
           proc.AddVarcharPara("@PackageType", 64, strPType);
           proc.AddIntegerPara("@IsExists", 0, QueryParameterDirection.Output);
           int i = proc.RunActionQuery();
           isExists = Convert.ToInt32(proc.GetParaValue("@IsExists"));
           if (i > 0)
           {
               stat = true;
           }
           return stat;
       }
       public static Boolean AddPackageType(string strPType,ref int isExists)
       {
           Boolean stat = false;
           ProcedureExecute proc = new ProcedureExecute("sp_PackageType");
           proc.AddVarcharPara("@Mode", 10, "add");
           proc.AddVarcharPara("@PackageType", 64, strPType);
           proc.AddIntegerPara("@IsExists", 0, QueryParameterDirection.Output);
           int i = proc.RunActionQuery();
           isExists = Convert.ToInt32(proc.GetParaValue("@IsExists"));
           if (i > 0)
           {
               stat = true;
           }
           return stat;
       }
    }
}
