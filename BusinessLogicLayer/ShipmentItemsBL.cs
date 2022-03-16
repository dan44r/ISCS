using System;
using System.Data;
using DataAccessLayer;
using EntityLayer;

namespace BusinessLogicLayer
{
    public class ShipmentItemsBL
    {
        public static Boolean AddShipmentItem(ShipmentItemsEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateShipmentItemStandAlone");
            proc.AddVarcharPara("@Mode", 10, "add");
            proc.AddIntegerPara("@ShipmentItemId", objEL.ShipmentItemId);
            proc.AddIntegerPara("@SkidId_SI",objEL.SkidId_SI);
            proc.AddIntegerPara("@PickupRequestId_SI",objEL.PickupRequestId_SI);
            proc.AddIntegerPara("@PackageQuantity_SI",objEL.PackageQuantity_SI);
            proc.AddVarcharPara("@PartNumber_SI",50,objEL.PartNumber_SI);
            proc.AddVarcharPara("@PurchaseOrderNumber_SI",50,objEL.PurchaseOrderNumber_SI);
            proc.AddVarcharPara("@LotNumber_SI",50,objEL.LotNumber_SI);
            proc.AddVarcharPara("@Description_SI",255,objEL.Description_SI);
            proc.AddVarcharPara("@ContainerName_SI",50,objEL.ContainerName_SI);
            proc.AddVarcharPara("@PackageType_SI",50,objEL.PackageType_SI);
            proc.AddIntegerPara("@Weight_SI",objEL.Weight_SI);
            proc.AddDecimalPara("@DeclaredValue_SI",2,14,objEL.DeclaredValue_SI);
            proc.AddVarcharPara("@Export_MFG_SI",10,objEL.Export_MFG_SI);
            proc.AddVarcharPara("@ExportScheduleB_SI",50,objEL.ExportScheduleB_SI);
            proc.AddDateTimePara("@DateAdded_SI",objEL.DateAdded_SI);
            proc.AddDateTimePara("@DateModified_SI",objEL.DateModified_SI);            

            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
        public static Boolean UpdateShipmentItem(ShipmentItemsEL objEL)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateShipmentItemStandAlone");
            proc.AddVarcharPara("@Mode", 10, "update");
            proc.AddIntegerPara("@ShipmentItemId", objEL.ShipmentItemId);
            proc.AddIntegerPara("@SkidId_SI", objEL.SkidId_SI);
            proc.AddIntegerPara("@PickupRequestId_SI", objEL.PickupRequestId_SI);
            proc.AddIntegerPara("@PackageQuantity_SI", objEL.PackageQuantity_SI);
            proc.AddVarcharPara("@PartNumber_SI", 50, objEL.PartNumber_SI);
            proc.AddVarcharPara("@PurchaseOrderNumber_SI", 50, objEL.PurchaseOrderNumber_SI);
            proc.AddVarcharPara("@LotNumber_SI", 50, objEL.LotNumber_SI);
            proc.AddVarcharPara("@Description_SI", 255, objEL.Description_SI);
            proc.AddVarcharPara("@ContainerName_SI", 50, objEL.ContainerName_SI);
            proc.AddVarcharPara("@PackageType_SI", 50, objEL.PackageType_SI);
            proc.AddIntegerPara("@Weight_SI", objEL.Weight_SI);
            proc.AddDecimalPara("@DeclaredValue_SI", 2, 14, objEL.DeclaredValue_SI);
            proc.AddVarcharPara("@Export_MFG_SI", 10, objEL.Export_MFG_SI);
            proc.AddVarcharPara("@ExportScheduleB_SI", 50, objEL.ExportScheduleB_SI);
            proc.AddDateTimePara("@DateModified_SI", objEL.DateModified_SI);            

            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet FetchShipmentUnit(int _pickuprequestid)
        {
            DataSet dsShipmentUnit = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_AdminSelectShipmentItemsForPickupRequestStandAlone");
                proc.AddIntegerPara("@PickupRequestId", _pickuprequestid);
                dsShipmentUnit = proc.GetDataSet();
            }
            catch (Exception ex)
            {
            }
            return dsShipmentUnit;
        }

        public static Boolean DeleteShipment(int Id)
        {
            Boolean stat = false;
            ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateShipmentItemStandAlone");
            proc.AddVarcharPara("@Mode", 30, "delete");
            proc.AddIntegerPara("@ShipmentItemId", Id);
            int i = proc.RunActionQuery();
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static DataSet FetchShipmentSingle(int shipid)
        {
            DataSet dsShipmentUnit = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_AdminInsertUpdateShipmentItemStandAlone");
                proc.AddVarcharPara("@Mode",10, "single");
                proc.AddIntegerPara("@ShipmentItemId", shipid);
                dsShipmentUnit = proc.GetDataSet();
            }
            catch (Exception ex)
            {
            }
            return dsShipmentUnit;
        }

        public static DataSet FetchShipmentForMailList(int skidid)
        {
            DataSet ds = null;
            try
            {
                ProcedureExecute proc = new ProcedureExecute("sp_fetchShiipmentsForListMail");
                proc.AddIntegerPara("@Skidid", skidid);
                ds = proc.GetDataSet();
            }
            catch (Exception ex)
            {
            }
            return ds;
        }      
    }
}
