using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using BusinessLogicLayer;
using EntityLayer;

namespace WinService1
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer oTimer = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected void oTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ServiceMethod();
        }

        protected override void OnStart(string[] args)
        {
            //EventLog.WriteEntry("Started");
            oTimer = new System.Timers.Timer();
            oTimer.Interval = 300000; //300 seconds interval
            oTimer.Elapsed += new ElapsedEventHandler(oTimer_Elapsed);
            oTimer.Start();
        }

        protected override void OnStop()
        {
        }

        private void ServiceMethod()
        {
            EventLog.WriteEntry("Inside method");
            try
            {
                PickupRequestBL.UnlockPickupRequest();
                PickupRequestBL.WarehouseRollbackShippedItems();
            }
            catch (Exception ex) { EventLog.WriteEntry(ex.Message.ToString()); }
            EventLog.WriteEntry("Inside method1");
        }
    }
}
