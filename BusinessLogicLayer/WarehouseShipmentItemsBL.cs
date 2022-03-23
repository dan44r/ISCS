using DataAccessLayer;
using EntityLayer;
using System;
using System.Data;

namespace BusinessLogicLayer
{
    public class WarehouseShipmentItemsBL
    {
        public static DataSet FetchAllWarehouseShipmentItems(int _UserCode, int _AccountCodeId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "all");
            proc.AddIntegerPara("@UserCode", _UserCode);
            proc.AddIntegerPara("@AccountCodeId", _AccountCodeId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllWarehouseShipmentItems(string strSearchKey, string strSearchCol, int _UserCode, int _AccountCodeId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "allwithcols");
            proc.AddIntegerPara("@UserCode", _UserCode);
            proc.AddIntegerPara("@AccountCodeId", _AccountCodeId);
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 64, strSearchCol);
            }
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllWarehouseShipmentItemsBySkuId(int _skuid)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "itemsbyskuid");
            proc.AddIntegerPara("@SkidId_WI", _skuid);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataTable FetchAllWarehouseShipmentItemByInvId(int _invid)
        {
            DataTable ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "byinventoryid");
            proc.AddIntegerPara("@InventoryId", _invid);
            ds = proc.GetTable();
            return ds;
        }

        public static DataSet FetchAllWarehouseShipmentItemsByLocation(int _UserCode, int _AccountCodeId, int _WarehouseShipFromLocationId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "allByLocation");
            proc.AddIntegerPara("@UserCode", _UserCode);
            proc.AddIntegerPara("@AccountCodeId", _AccountCodeId);
            proc.AddIntegerPara("@WarehouseShipFromLocationId", _WarehouseShipFromLocationId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllWarehouseShipmentItemsByLocation(string strSearchKey, string strSearchCol, int _UserCode, int _AccountCodeId, int _WarehouseShipFromLocationId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "allwithcolsByLocation");
            proc.AddIntegerPara("@UserCode", _UserCode);
            proc.AddIntegerPara("@AccountCodeId", _AccountCodeId);
            if (strSearchKey != "")
            {
                proc.AddNVarcharPara("@SearchText", 64, strSearchKey);
                proc.AddNVarcharPara("@SearchColumn", 64, strSearchCol);
            }
            proc.AddIntegerPara("@WarehouseShipFromLocationId", _WarehouseShipFromLocationId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataSet FetchAllWarehouseShipmentItemsBySkuIdByLocation(int _skuid, int _WarehouseShipFromLocationId)
        {
            DataSet ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "itemsbyskuidByLocation");
            proc.AddIntegerPara("@SkidId_WI", _skuid);
            proc.AddIntegerPara("@WarehouseShipFromLocationId", _WarehouseShipFromLocationId);
            ds = proc.GetDataSet();
            return ds;
        }

        public static DataTable FetchAllWarehouseShipmentItemByInvIdByLocation(int _invid, int _WarehouseShipFromLocationId)
        {
            DataTable ds;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "byinventoryidByLocation");
            proc.AddIntegerPara("@InventoryId", _invid);
            proc.AddIntegerPara("@WarehouseShipFromLocationId", _WarehouseShipFromLocationId);
            ds = proc.GetTable();
            return ds;
        }

        public static Boolean UpdateWarehouseShipmentItems(WarehouseShipmentItems objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("sp_tblWarehouseShipmentItems");
            proc.AddVarcharPara("@Mode", 30, "update");
            proc.AddIntegerPara("@InventoryId", objEl.InventoryId);
            proc.AddNVarcharPara("@PartNumber_WI", 50, objEl.PartNumber_WI);
            proc.AddNVarcharPara("@LotNumber_WI", 100, objEl.LotNumber_WI);
            proc.AddNVarcharPara("@Description_WI", 300, objEl.Description_WI);
            proc.AddNVarcharPara("@PackageType_WI", 100, objEl.PackageType_WI);
            proc.AddIntegerPara("@OnHandQuantity", objEl.OnHandQuantity);
            proc.AddIntegerPara("@PendingPickQuantity", objEl.PendingPickQuantity);
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

        public static Boolean AddPickedItemsFromWarehouse(WarehouseShipmentItems objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("spAdminAddPickedItemsFromWarehouse");
            proc.AddIntegerPara("@SkidID", objEl.SkidId_WI);
            proc.AddIntegerPara("@UserId", objEl.AdminUserId);
            proc.AddIntegerPara("@PickupRequestType", objEl.PickupRequestType);
            proc.AddIntegerPara("@InventoryID", objEl.InventoryId);
            proc.AddIntegerPara("@Quantity", objEl.QtyAdded);
            if (objEl.PickupRequestId == 0)
            {
                proc.AddIntegerPara("@NewRequestid", 0, QueryParameterDirection.Output);
            }
            else if (objEl.PickupRequestId > 0)
            {
                proc.AddIntegerPara("@NewRequestid", objEl.PickupRequestId, QueryParameterDirection.Output);
            }
            proc.AddIntegerPara("@NewSkidId", 0, QueryParameterDirection.Output);
            try
            {
                i = proc.RunActionQuery();
                objEl.PickupRequestId = Convert.ToInt32(proc.GetParaValue("@NewRequestid"));
                objEl.SkidId_SI = Convert.ToInt32(proc.GetParaValue("@NewSkidId"));
            }
            catch (Exception ex)
            {
            }
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean AddPickedItemsFromWarehouseUpdate(WarehouseShipmentItems objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("spAdminAddPickedItemsFromWarehouseUpdate");
            proc.AddIntegerPara("@PickupRequestId", objEl.PickupRequestId);
            proc.AddIntegerPara("@SkidID", objEl.SkidId_WI);
            proc.AddIntegerPara("@UserId", objEl.AdminUserId);
            proc.AddIntegerPara("@InventoryID", objEl.InventoryId);
            proc.AddIntegerPara("@Quantity", objEl.QtyAdded);
            try
            {
                i = proc.RunActionQuery();
                objEl.PickupRequestId = Convert.ToInt32(proc.GetParaValue("@NewRequestid"));
                objEl.SkidId_SI = Convert.ToInt32(proc.GetParaValue("@NewSkidId"));
            }
            catch (Exception ex)
            {
            }
            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean AddShipAllItemsFromWarehouse(WarehouseShipmentItems objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("spAdminAddEntireSkidFromWarehouse");
            proc.AddIntegerPara("@SkidID", objEl.SkidId_WI);
            proc.AddIntegerPara("@UserId", objEl.AdminUserId);
            proc.AddIntegerPara("@PickupRequestType", objEl.PickupRequestType);
            proc.AddIntegerPara("@NewRequestid", 0, QueryParameterDirection.Output);
            proc.AddIntegerPara("@NewSkidId", 0, QueryParameterDirection.Output);
            try
            {
                i = proc.RunActionQuery();
                objEl.PickupRequestId = Convert.ToInt32(proc.GetParaValue("@NewRequestid"));
                objEl.SkidId_SI = Convert.ToInt32(proc.GetParaValue("@NewSkidId"));
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }

        public static Boolean AddShipAllItemsFromWarehouseUpdate(WarehouseShipmentItems objEl)
        {
            Boolean stat = false;
            int i = 0;
            ProcedureExecute proc = new ProcedureExecute("spAdminAddEntireSkidFromWarehouseUpdate");
            proc.AddIntegerPara("@PickupRequestId", objEl.PickupRequestId);
            proc.AddIntegerPara("@SkidID", objEl.SkidId_SI);
            proc.AddIntegerPara("@UserId", objEl.AdminUserId);
            proc.AddIntegerPara("@ExistingSkidId", objEl.SkidId_WI);
            try
            {
                i = proc.RunActionQuery();
                objEl.PickupRequestId = Convert.ToInt32(proc.GetParaValue("@NewRequestid"));
                objEl.SkidId_SI = Convert.ToInt32(proc.GetParaValue("@NewSkidId"));
            }
            catch (Exception ex)
            { }

            if (i > 0)
            {
                stat = true;
            }
            return stat;
        }
    }
}
