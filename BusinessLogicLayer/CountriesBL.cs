using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class CountriesBL
    {
        public static DataSet FetchAllCountries()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCountries");
            proc.AddVarcharPara("@Mode", 30, "all");
            ds = proc.GetDataSet();
            return ds;
        }
        public static DataSet FetchCountryById(int CountryID)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblCountries");
            proc.AddVarcharPara("@Mode", 30, "SelectById");
            proc.AddIntegerPara("@CountryId", CountryID);
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
