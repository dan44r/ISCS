using System.Data;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class SpecialServicesBL
    {
        public static DataSet FetchAllSpecialServices()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblSpecialServices");
            proc.AddVarcharPara("@Mode", 30, "all");
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
