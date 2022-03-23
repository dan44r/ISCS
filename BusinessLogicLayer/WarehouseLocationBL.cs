using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class WarehouseLocationBL
    {
        public static DataSet FetchWarehouseLocation(string strSearchKey, string strSearchCol)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_WarehouseLocation");
            proc.AddVarcharPara("@Mode", 10, "all");
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 16, strSearchCol);
            }
            ds = proc.GetDataSet();
            return ds;
        }

        public static WarehouseLocationEL SingleWarehouseLocation(int id)
        {
            SqlDataReader reader;
            WarehouseLocationEL whLocationEL = new WarehouseLocationEL();
            ProcedureExecute proc = new ProcedureExecute("sp_WarehouseLocation");
            proc.AddVarcharPara("@Mode", 10, "single");
            proc.AddIntegerPara("@Id", id);
            reader = proc.GetReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    whLocationEL.CompanyName = reader["CompanyName"].ToString();
                    whLocationEL.Address = reader["Address"].ToString();
                    whLocationEL.City = reader["City"].ToString();
                    whLocationEL.StateId = Convert.ToInt32(reader["StateId"].ToString());
                    whLocationEL.PostalCode = reader["PostalCode"].ToString();
                    whLocationEL.CountryId = Convert.ToInt32(reader["CountryId"].ToString());
                    whLocationEL.ContactName = reader["ContactName"].ToString();
                    whLocationEL.ContactPhone = reader["ContactPhone"].ToString();
                    whLocationEL.ContactFax = reader["ContactFax"].ToString();
                    whLocationEL.ContactEmail = reader["ContactEmail"].ToString();
                }
            }
            return whLocationEL;
        }
        public static Boolean AddWarehouseLocation(WarehouseLocationEL whLocationEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_WarehouseLocation");
            proc.AddVarcharPara("@Mode", 10, "add");
            proc.AddIntegerPara("@UserId", whLocationEL.UserId);
            proc.AddNVarcharPara("@CompanyName", 200, whLocationEL.CompanyName);
            proc.AddNVarcharPara("@Address", 300, whLocationEL.Address);
            proc.AddNVarcharPara("@City", 100, whLocationEL.City);
            proc.AddIntegerPara("@StateId", whLocationEL.StateId);
            proc.AddNVarcharPara("@PostalCode", 50, whLocationEL.PostalCode);
            proc.AddIntegerPara("@CountryId", whLocationEL.CountryId);
            proc.AddNVarcharPara("@ContactName", 100, whLocationEL.ContactName);
            proc.AddNVarcharPara("@ContactPhone", 50, whLocationEL.ContactPhone);
            proc.AddNVarcharPara("@ContactFax", 50, whLocationEL.ContactFax);
            proc.AddNVarcharPara("@ContactEmail", 100, whLocationEL.ContactEmail);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean UpdateWarehouseLocation(WarehouseLocationEL whLocationEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_WarehouseLocation");
            proc.AddVarcharPara("@Mode", 10, "update");
            proc.AddIntegerPara("@Id", whLocationEL.Id);
            proc.AddIntegerPara("@UserId", whLocationEL.UserId);
            proc.AddNVarcharPara("@CompanyName", 256, whLocationEL.CompanyName);
            proc.AddNVarcharPara("@Address", 256, whLocationEL.Address);
            proc.AddNVarcharPara("@City", 256, whLocationEL.City);
            proc.AddIntegerPara("@StateId", whLocationEL.StateId);
            proc.AddNVarcharPara("@PostalCode", 256, whLocationEL.PostalCode);
            proc.AddIntegerPara("@CountryId", whLocationEL.CountryId);
            proc.AddNVarcharPara("@ContactName", 256, whLocationEL.ContactName);
            proc.AddNVarcharPara("@ContactPhone", 256, whLocationEL.ContactPhone);
            proc.AddNVarcharPara("@ContactFax", 256, whLocationEL.ContactFax);
            proc.AddNVarcharPara("@ContactEmail", 256, whLocationEL.ContactEmail);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean DeleteWarehouseLocation(int id)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_WarehouseLocation");
            proc.AddVarcharPara("@Mode", 10, "delete");
            proc.AddIntegerPara("@Id", id);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet FetchWarehouseLocationAllPop(string strSearchKey, string strSearchText)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectAllWarehouseLocationsAlpha");
            proc.AddVarcharPara("@AlphaLetter", 2, strSearchKey);
            proc.AddVarcharPara("@SearchText", 1000, strSearchText);
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
