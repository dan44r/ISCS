using System.Data;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class StatusBL
    {
        public static DataSet FetchAllStatus()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_status");
            proc.AddVarcharPara("@Mode", 30, "all");            
            ds = proc.GetDataSet();
            return ds; 
        }
    }
}
