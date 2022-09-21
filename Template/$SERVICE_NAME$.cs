using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;

namespace $NAMESPACE$
{
    public partial class $SERVICE_NAME$ : ServiceBase
    {
        public $SERVICE_NAME$()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called by the SCM to start the service
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            ActualStart();
        }

        /// <summary>
        /// Called by the SCM to stop the service
        /// </summary>
        protected override void OnStop()
        {
            ActualStop();
        }

        /// <summary>
        /// Starts fluentd services
        /// </summary>
        internal void ActualStart()
        {
            
        }

        internal void ActualStop()
        {
        }
    }
}
