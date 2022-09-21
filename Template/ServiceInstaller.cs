#region (C) Koninklijke Philips N.V. 2018
//
// All rights are reserved. Reproduction or transmission in whole or in part,
// in any form or by any means, electronic, mechanical or otherwise, is
// prohibited without the prior written permission of the copyright owner.
//
// Filename: ServiceInstaller.cs
//
#endregion

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
