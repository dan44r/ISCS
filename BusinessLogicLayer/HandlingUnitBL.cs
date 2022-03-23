using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class HandlingUnitBL
    {
        public static Boolean AddHandlingUnit(HandlingUnitEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateSkidStandAlone");
            proc.AddVarcharPara("@Mode", 10, "add");
            proc.AddIntegerPara("@PickupRequestId", objEL.PickupRequestId);
            proc.AddVarcharPara("@HandlingUnitType", 50, objEL.HandlingUnitType);
            proc.AddIntegerPara("@Length", objEL.Length);
            proc.AddIntegerPara("@Width", objEL.Width);
            proc.AddIntegerPara("@Height", objEL.Height);
            proc.AddIntegerPara("@Weight_SI", objEL.Weight_SI); //added for weight in Handling Unit
            proc.AddIntegerPara("@HazMat", objEL.HazMat);
            proc.AddVarcharPara("@Class", 5, objEL.Class);
            proc.AddVarcharPara("@NMFCCode", 20, objEL.NMFCCode);
            proc.AddVarcharPara("@CommodityDescription", 255, objEL.CommodityDescription);
            proc.AddVarcharPara("@HazMatEmergencyPhone", 20, objEL.HazMatEmergencyPhone);
            proc.AddDateTimePara("@DateModified", objEL.DateModified);
            proc.AddDateTimePara("@DateAdded", objEL.DateAdded);
            proc.AddIntegerPara("@NewSkidId", 0, QueryParameterDirection.Output);
            int i = proc.RunActionQuery();
            objEL.SkidId = Convert.ToInt32(proc.GetParaValue("@NewSkidId"));
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet FetchHandlingUnit(int _pickuprequestid, int _pickuprequesttype)
        {
            DataSet dsHandlingUnit = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectSkidsForPickupRequestStandAlone");
                proc.AddIntegerPara("@PickupRequestId", _pickuprequestid);
                proc.AddIntegerPara("@PickupRequestType", _pickuprequesttype);
                dsHandlingUnit = proc.GetDataSet();
            }
            catch (Exception ex)
            {
            }
            return dsHandlingUnit;
        }

        public static DataSet FetchHandlingUnitSingle(int huid)
        {
            DataSet dsHUnit = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateSkidStandAlone");
                proc.AddVarcharPara("@Mode", 10, "single");
                proc.AddIntegerPara("@SkidId", huid);
                dsHUnit = proc.GetDataSet();
            }
            catch (Exception ex)
            {
            }
            return dsHUnit;
        }
        public static Boolean UpdateHandlingUnitItem(HandlingUnitEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateSkidStandAlone");
            proc.AddVarcharPara("@Mode", 10, "update");
            proc.AddVarcharPara("@HandlingUnitType", 50, objEL.HandlingUnitType);
            proc.AddIntegerPara("@Length", objEL.Length);
            proc.AddIntegerPara("@Width", objEL.Width);
            proc.AddIntegerPara("@Height", objEL.Height);
            proc.AddIntegerPara("@Weight_SI", objEL.Weight_SI); //added for weight in Handling Unit
            proc.AddIntegerPara("@HazMat", objEL.HazMat);
            proc.AddVarcharPara("@Class", 5, objEL.Class);
            proc.AddVarcharPara("@NMFCCode", 20, objEL.NMFCCode);
            proc.AddVarcharPara("@CommodityDescription", 255, objEL.CommodityDescription);
            proc.AddVarcharPara("@HazMatEmergencyPhone", 20, objEL.HazMatEmergencyPhone);
            proc.AddDateTimePara("@DateModified", objEL.DateModified);
            proc.AddIntegerPara("@SkidId", objEL.SkidId);

            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean DeleteHandlingUnit(int Id)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateSkidStandAlone");
            proc.AddVarcharPara("@Mode", 30, "delete");
            proc.AddIntegerPara("@SkidId", Id);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
    }
}
