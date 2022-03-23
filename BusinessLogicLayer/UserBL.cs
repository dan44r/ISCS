using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class UserBL
    {
        public static DataTable GetUserByUserName(string _userName)
        {
            DataTable dtUser = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
                proc.AddVarcharPara("@Mode", 30, "selectbyusername");
                proc.AddVarcharPara("@Email", 128, _userName);
                dtUser = proc.GetTable();
            }
            catch (Exception ex)
            { }
            return dtUser;
        }

        public static DataTable GetUserByUserNamePassword(string _userName, string _password)
        {
            DataTable dtUser = new DataTable();
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
                proc.AddVarcharPara("@Mode", 30, "selectbyusernamePassword");
                proc.AddVarcharPara("@Email", 128, _userName);
                proc.AddVarcharPara("@Password", 32, _password);
                dtUser = proc.GetTable();
            }
            catch (Exception ex)
            { }
            return dtUser;
        }

        public static DataSet FetchAllUsers()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 30, "all");
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllUsers(string strSearchKey, string strSearchCol)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 30, "allwithcols");
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
            }
            ds = proc.GetDataSet();
            return ds;
        }

        public static int DeleteUsers(int Id)
        {
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 30, "delete");
            proc.AddIntegerPara("@UserId", Id);
            int i = proc.RunActionQuery();
            return i;
        }
        public static DataTable GetUserByUserId(int Id)
        {
            DataTable ds = null;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 30, "byid");
            proc.AddIntegerPara("@UserId", Id);
            ds = proc.GetTable();
            return ds;
        }

        public static Boolean InsertUser(EntityLayer.Users objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 10, "add");
            proc.AddNVarcharPara("@FirstName", 64, objEl.FirstName);
            proc.AddNVarcharPara("@LastName", 64, objEl.LastName);
            proc.AddIntegerPara("@UserTypeId", objEl.UserTypeId);
            proc.AddIntegerPara("@AccountCodeId", objEl.AccountCodeId);
            proc.AddNVarcharPara("@Phone", 32, objEl.Phone);
            proc.AddNVarcharPara("@Fax", 32, objEl.Fax);
            proc.AddNVarcharPara("@Email", 128, objEl.Email);
            proc.AddNVarcharPara("@Password", 32, objEl.Password);
            proc.AddBooleanPara("@Active", objEl.Active);
            proc.AddNVarcharPara("@CompanyName", 128, objEl.CompanyName);
            proc.AddNVarcharPara("@Address1", 128, objEl.Address1);
            proc.AddNVarcharPara("@Address2", 128, objEl.Address2);
            proc.AddNVarcharPara("@City", 128, objEl.City);
            proc.AddIntegerPara("@StateId", objEl.StateId);
            proc.AddNVarcharPara("@PostalCode", 32, objEl.PostalCode);
            proc.AddIntegerPara("@CountryId", objEl.CountryId);
            try
            {
                i = proc.RunActionQuery();
            }
            catch (Exception ex)
            { }
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean UpdateUser(EntityLayer.Users objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 10, "edit");
            proc.AddIntegerPara("@UserId", objEl.UserId);
            proc.AddNVarcharPara("@FirstName", 64, objEl.FirstName);
            proc.AddNVarcharPara("@LastName", 64, objEl.LastName);
            proc.AddIntegerPara("@UserTypeId", objEl.UserTypeId);
            proc.AddIntegerPara("@AccountCodeId", objEl.AccountCodeId);
            proc.AddNVarcharPara("@Phone", 32, objEl.Phone);
            proc.AddNVarcharPara("@Fax", 32, objEl.Fax);
            proc.AddNVarcharPara("@Email", 128, objEl.Email);
            proc.AddNVarcharPara("@Password", 32, objEl.Password);
            proc.AddBooleanPara("@Active", objEl.Active);
            proc.AddNVarcharPara("@CompanyName", 128, objEl.CompanyName);
            proc.AddNVarcharPara("@Address1", 128, objEl.Address1);
            proc.AddNVarcharPara("@Address2", 128, objEl.Address2);
            proc.AddNVarcharPara("@City", 128, objEl.City);
            proc.AddIntegerPara("@StateId", objEl.StateId);
            proc.AddNVarcharPara("@PostalCode", 32, objEl.PostalCode);
            proc.AddIntegerPara("@CountryId", objEl.CountryId);
            try
            {
                i = proc.RunActionQuery();
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataTable GetByUserTypeId(int UserTypeId)
        {
            DataTable ds = null;
            ProcedureExecute proc = new ProcedureExecute("sp_tblUsers");
            proc.AddVarcharPara("@Mode", 30, "selectByUserTypeId");
            proc.AddIntegerPara("@UserTypeId", UserTypeId);
            ds = proc.GetTable();
            return ds;
        }
        public static DataSet GetUserStateCountryByUserId(int Id)
        {
            DataSet ds = null;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectPickupRequestInfoForUserId");
            proc.AddIntegerPara("@UserId", Id);
            ds = proc.GetDataSet();
            return ds;
        }
        public static DataSet CompareAccountCodes(string ShipFromEmail)
        {
            DataSet ds = null;
            ProcedureExecute proc = new ProcedureExecute("spAdminCompareAccountCodes");
            proc.AddVarcharPara("@ShipFromEmail", 30, ShipFromEmail);
            ds = proc.GetDataSet();
            return ds;
        }
        public static DataSet GetAllEmailsByAccountCodes(string ShipFromEmail)
        {
            DataSet ds = null;
            ProcedureExecute proc = new ProcedureExecute("spGetAllEmailsByAccountCodes");
            proc.AddVarcharPara("@ShipFromEmail", 30, ShipFromEmail);
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
