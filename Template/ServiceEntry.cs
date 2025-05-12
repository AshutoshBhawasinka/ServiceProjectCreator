
using System;
using System.Configuration.Install;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;

namespace $NAMESPACE$
{
    /// <summary>
    /// Contains the entry point for the executable
    /// </summary>
    internal class ServiceEntry
    {
        private string[] mainArgs;

        private static TimeSpan serviceStartWaitTimeout = TimeSpan.FromSeconds(30);
        private const string ServiceName = "$SERVICE_NAME$";

        /// <summary>
        /// Contains the entry point for the process.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        static int Main(string[] arguments)
        {
            ServiceEntry serviceEntry = new ServiceEntry();
            serviceEntry.mainArgs = arguments;
            if (serviceEntry.mainArgs == null || serviceEntry.mainArgs.Length == 0)
            {
                serviceEntry.mainArgs = Environment.GetCommandLineArgs();
            }
            Trace.AutoFlush = true;
            return serviceEntry.ActualMain();
        }

        int ActualMain()
        {
            InstallContext context = new InstallContext(null, mainArgs);

            ServiceHostArguments serviceHostArgs;
            try
            {
                serviceHostArgs = new ServiceHostArguments(context.Parameters);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid arguments passed: " + ex.Message);
                return 1;
            }

            string executablePath = Assembly.GetExecutingAssembly().Location;

            switch (serviceHostArgs.Activity)
            {
                case ServiceHostActivity.Install:
                    ManagedInstallerClass.InstallHelper(new[] { "/LogFile=", executablePath });
                    Console.WriteLine("Successfully Installed the Service: " + ServiceName);
                    //Set the service to start automatically on failures.
                    var proc = Process.Start(
                        "sc.exe",
                        "failure $SERVICE_NAME$ reset=0 actions= restart/0");
                    if (proc != null)
                    {
                        proc.WaitForExit((int)serviceStartWaitTimeout.TotalMilliseconds);
                        Console.WriteLine(
                            "Updated Service Recovery Action to restart automatically");
                    }

                    break;
                case ServiceHostActivity.Uninstall:
                    ManagedInstallerClass.InstallHelper(
                        new[] { "/LogFile=", "/u", executablePath });
                    break;
                case ServiceHostActivity.Start:
                    if (serviceHostArgs.ConsoleMode)
                    {
                        RunService(serviceHostArgs);
                    }
                    else if (serviceHostArgs.NonInteractive)
                    {
                        StartService(serviceHostArgs);
                    }
                    else if (!serviceHostArgs.NonInteractive)
                    {
                        if (!string.IsNullOrEmpty(serviceHostArgs.ServiceName))
                        {
                            RunService(serviceHostArgs);
                        }
                        else
                        {
                            StartService(serviceHostArgs);
                        }
                    }
                    break;
                case ServiceHostActivity.StartBackgroundServices:
                    Console.WriteLine("Starting DeploymentService in this mode is not supported");
                    return 2;
                case ServiceHostActivity.StartUsingSmc:
                    StartService(serviceHostArgs);
                    break;
                case ServiceHostActivity.Stop:
                    Console.WriteLine("Stopping Service in this way is not supported.");
                    return 3;
                case ServiceHostActivity.StopBackgroundServices:
                    Console.WriteLine("Stopping DeploymentService in this mode is not supported");
                    return 4;
                case ServiceHostActivity.DumpProcessDetails:
                    Console.WriteLine(
                        "Dumping Process Details for DeploymentService is not supported");
                    break;
            }

            return 0;
        }

        /// <summary>
        /// Starts the service using the Windows Scervice control Mananger (SCM)
        /// <param name="serviceHostArgs">Contains information about how to start 
        /// the servie</param>
        /// </summary>
        private void StartService(ServiceHostArguments serviceHostArgs)
        {
            Console.WriteLine("Starting Service: " + ServiceName);
            var ServicesToRun = new ServiceBase[] {
                new $SERVICE_NAME$()
            };
            ServiceBase.Run(ServicesToRun);
            Console.WriteLine("Started Service: " + ServiceName);

            if (
                serviceHostArgs.Activity != ServiceHostActivity.StartUsingSmc &&
                !serviceHostArgs.ConsoleMode && string.IsNullOrEmpty(serviceHostArgs.ServiceName)
            )
            {
                Console.WriteLine("Waiting for service to change state to Running ");
                ServiceController sc = new ServiceController(ServiceName);
                try
                {
                    sc.WaitForStatus(ServiceControllerStatus.Running, serviceStartWaitTimeout);
                }
                catch (System.ServiceProcess.TimeoutException tex)
                {
                    Console.WriteLine("Failed waiting for the Service to start." + tex.Message);
                }
            }
        }

        /// <summary>
        /// Starts the service directly and waits for a key press from the interactive user
        /// to stop the service. This is a blocking call.
        /// </summary>
        /// <param name="serviceHostArgs">Contains information about how to start 
        /// the servie</param>
        private void RunService(ServiceHostArguments serviceHostArgs)
        {
            $SERVICE_NAME$ service = new $SERVICE_NAME$();
            service.ActualStart();
            Console.WriteLine("$SERVICE_NAME$ Started. Press any key to stop the service");
            if (serviceHostArgs.ConsoleMode)
            {
                Console.WriteLine("Press ENTER key to stop the service...");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Press any key to stop the service...");
                Console.ReadKey(true);
            }

            service.ActualStop();
        }
    }
}
