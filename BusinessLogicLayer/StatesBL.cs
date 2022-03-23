using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class StatesBL
    {
        public static DataSet FetchAllStates()
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblStates");
            proc.AddVarcharPara("@Mode", 30, "all");
            ds = proc.GetDataSet();
            return ds;
        }
        public static DataSet FetchStateById(int StateID)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblStates");
            proc.AddVarcharPara("@Mode", 30, "ById");
            proc.AddIntegerPara("@StateId", StateID);
            ds = proc.GetDataSet();
            return ds;
        }
    }
}
