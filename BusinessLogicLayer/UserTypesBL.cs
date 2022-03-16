using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserTypesBL
    {
        public static DataTable FetchAllUserTypes()
        {
            DataTable dtUserTypes;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypes");
            proc.AddVarcharPara("@Mode", 30, "all");
            dtUserTypes = proc.GetTable();
            return dtUserTypes;
        }

        public static string FetchUserTypeById(int _UserTypeId)
        {
            DataTable dtUserTypes;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypes");
            proc.AddVarcharPara("@Mode", 30, "selectbyid");
            proc.AddIntegerPara("@UserTypeId", _UserTypeId);
            dtUserTypes = proc.GetTable();
            if (dtUserTypes != null)
            {
                if (dtUserTypes.Rows.Count > 0)
                {
                    return Convert.ToString(dtUserTypes.Rows[0]["UserType"]);
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public static DataTable FetchUserTypeAllById(int _UserTypeId)
        {
            DataTable dtUserTypes;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUserTypes");
            proc.AddVarcharPara("@Mode", 30, "selectbyid");
            proc.AddIntegerPara("@UserTypeId", _UserTypeId);
            dtUserTypes = proc.GetTable();
            if (dtUserTypes != null)
            {
                if (dtUserTypes.Rows.Count > 0)
                {
                    return dtUserTypes;
                }
                else
                {
                    return dtUserTypes;
                }
            }
            else
            {
                return dtUserTypes;
            }
        }
    }
}
