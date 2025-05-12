using System.ComponentModel;

namespace $NAMESPACE$
{
    /// <summary>
    /// Contains the Logic to install the service
    /// </summary>
    [RunInstaller(true)]
    public partial class ServiceInstaller : System.Configuration.Install.Installer {

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInstaller() {
            InitializeComponent();
        }
    }
}
