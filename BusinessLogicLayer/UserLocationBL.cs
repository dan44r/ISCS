using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class UserLocationBL
    {
        public static DataSet FetchUserLocation(int intUserId, int intUserCode, string strAlfaletter, string strSearchText)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectAllUserLocationsAlpha");
            proc.AddIntegerPara("@UserId", intUserId);
            proc.AddIntegerPara("@UserCode", intUserCode);
            proc.AddVarcharPara("@AlphaLetter", 1, strAlfaletter);
            proc.AddVarcharPara("@SearchText", 1000, strSearchText);
            ds = proc.GetDataSet();
            return ds;
        }

        public static bool DeleteLocation(int Id)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_Userlocation");
            proc.AddVarcharPara("@Mode", 30, "delete");
            proc.AddIntegerPara("@Id", Id);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static bool AddLocation(UserLocationEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("spAdminSaveLocationInfo");
            proc.AddIntegerPara("@UserId", objEL.UserId);
            proc.AddVarcharPara("@CompanyName", 100, objEL.CompanyName);
            proc.AddVarcharPara("@Address", 100, objEL.Address);
            proc.AddVarcharPara("@City", 100, objEL.City);
            proc.AddIntegerPara("@StateId", objEL.StateId);
            proc.AddVarcharPara("@PostalCode", 20, objEL.PostalCode);
            proc.AddIntegerPara("@CountryId", objEL.CountryId);
            proc.AddVarcharPara("@ContactName", 100, objEL.ContactName);
            proc.AddVarcharPara("@ContactPhone", 30, objEL.ContactPhone);
            proc.AddVarcharPara("@ContactFax", 30, objEL.ContactFax);
            proc.AddVarcharPara("@ContactEmail", 100, objEL.ContactEmail);
            proc.AddVarcharPara("@AlsoNotifyName", 100, objEL.AlsoNotifyName);
            proc.AddVarcharPara("@AlsoNotifyPhone", 30, objEL.AlsoNotifyPhone);

            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static bool AddLocationIntl(UserLocationEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("spAdminSaveLocationInfoIntl");
            proc.AddIntegerPara("@UserId", objEL.UserId);
            proc.AddVarcharPara("@CompanyName", 100, objEL.CompanyName);
            proc.AddVarcharPara("@Address", 100, objEL.Address);
            proc.AddVarcharPara("@City", 100, objEL.City);
            proc.AddIntegerPara("@StateId", objEL.StateId);
            proc.AddVarcharPara("@PostalCode", 20, objEL.PostalCode);
            proc.AddIntegerPara("@CountryId", objEL.CountryId);
            proc.AddVarcharPara("@ContactName", 100, objEL.ContactName);
            proc.AddVarcharPara("@ContactPhone", 30, objEL.ContactPhone);
            proc.AddVarcharPara("@ContactFax", 30, objEL.ContactFax);
            proc.AddVarcharPara("@ContactEmail", 100, objEL.ContactEmail);

            proc.AddVarcharPara("@ExportEIN", 30, objEL.ExportEIN);
            proc.AddIntegerPara("@PartiesToTransaction", objEL.PartiesToTransaction);
            proc.AddVarcharPara("@ExportIntermediateConsignee", 30, objEL.ExportIntermediateConsignee);
            proc.AddVarcharPara("@ExportAddress", 30, objEL.ExportAddress);
            proc.AddVarcharPara("@ExportCity", 30, objEL.ExportCity);
            proc.AddVarcharPara("@ExportPostalCode", 30, objEL.ExportPostalCode);
            proc.AddIntegerPara("@ExportCountryId", objEL.ExportCountryId);
            proc.AddVarcharPara("@ExportIntermediateContact", 30, objEL.ExportIntermediateContact);
            proc.AddVarcharPara("@ExportIntermediatePhone", 30, objEL.ExportIntermediatePhone);
            int i = proc.RunActionQuery();

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet SelectUserLocation(int Id)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_Userlocation");
            proc.AddVarcharPara("@Mode", 30, "SelectById");
            proc.AddIntegerPara("@Id", Id);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet SelectUserTypeFromLocation(int Id)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_Userlocation");
            proc.AddVarcharPara("@Mode", 30, "SelectUserTypeById");
            proc.AddIntegerPara("@Id", Id);
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
