﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using WCF_DuplexSvc;

namespace WindowsServiceForDuplexWCFService
{
    public partial class Service1 : ServiceBase
    {
        internal static ServiceHost myServiceHost = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
            }
            myServiceHost = new ServiceHost(typeof(DuplexSvc));
            myServiceHost.Open();
            this.MyLog("Service Started");
        }

        protected override void OnStop()
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
                myServiceHost = null;
            }
            this.MyLog("Service Stopped");
        }
        private void MyLog(string msg)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("svclog.txt", true);
                msg += "\t\t";
                msg += DateTime.Now.ToLongTimeString();
                sw.WriteLine(msg);
            }
            catch (Exception ex)
            {
                StreamWriter error = new StreamWriter("errors.txt", true);
                error.WriteLine(ex.Message);
                error.Close();
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
