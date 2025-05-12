
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Security;

namespace $NAMESPACE$
{
    /// <summary>
    /// Class used for parsing commandline parameters given to ServiceHost
    /// </summary>
    internal class ServiceHostArguments
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceHostArguments() {
            Activity = ServiceHostActivity.Start;
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="installContextParameters">Collection of command line arguments passed to
        /// ServiceHost.exe</param>
        public ServiceHostArguments(StringDictionary installContextParameters) {
            ValidateArguments(installContextParameters);
            SetActivity(installContextParameters);
            SetProcesses(installContextParameters);
            SetArguments(installContextParameters);
        }

        private const string install = "install";
        private const string uninstall = "uninstall";
        private const string start = "start";
        private const string stop = "stop";
        private const string all = "all";
        private const string console = "console";        
        private const string args = "args";
        private const string nonInteractive = "noninteractive";
        private const string execArch = "execarch";
        private const string processName = "processname";
        private const string excludeProcessName = "excludeprocessname";
        //Used by installer
        private const string username = "username";
        private const string password = "password";
        private const string hostargs = "hostargs";
        private const string bootstrap = "bootstrap";
        //Used by Standalone AuditTrail
        private const string eafile = "eafile";
        //introduced for us2020
        private const string background = "background";
        internal const string outputprocessinfo = "outputprocessinfo";

        //For debugging purpose only
        private const string launchDebugger = "-launchdebugger";

        private string[] validTokens = {
            install, uninstall, start, stop, all, console, args, nonInteractive, execArch,
            processName, excludeProcessName, username, password, hostargs, bootstrap, eafile,
            background, outputprocessinfo
        };

        [SuppressMessage(
            "Microsoft.Globalization",
            "CA1308:NormalizeStringsToUppercase",
            Justification =
            "StringDictionary.ContainsKey always convert the passed parameter to lowercase")]
        private void ValidateArguments(StringDictionary dictionary) {
            if (dictionary.ContainsKey(launchDebugger)) {
                try {
                    if (Debugger.Launch()) {
                        Debugger.Break();
                    }
                } catch (SecurityException e) {
                    Console.WriteLine("Could not launch debugger: " + e.Message);
                }

                //only for debugging purpose - can be removed safely here
                dictionary.Remove(launchDebugger);
            }
            List<string> validArgs = new List<string>(validTokens);
            validArgs.Add(Environment.GetCommandLineArgs()[0].ToLower(
                CultureInfo.InvariantCulture));
            foreach (string key in dictionary.Keys) {
                if (!validArgs.Contains(key)) {
                    Console.WriteLine("ValidateArguments - Unknown argument passed: " + key);
                    //To support scenarios like Test01InstallAndStartWithBootstrapExtraArg of
                    //ServiceHosting we can not throw any exception or return from here
                }
            }
        }

        private void SetActivity(StringDictionary dictionary) {
            if (dictionary.ContainsKey(install)) {
                Activity = ServiceHostActivity.Install;
            } else if (dictionary.ContainsKey(uninstall)) {
                Activity = ServiceHostActivity.Uninstall;
            } else if (dictionary.ContainsKey(start)) {
                Activity = !dictionary.ContainsKey(background) ? 
                    ServiceHostActivity.Start : 
                    ServiceHostActivity.StartBackgroundServices;
            } else if (dictionary.ContainsKey(stop)) {
                Activity = !dictionary.ContainsKey(background) ?
                    ServiceHostActivity.Stop :
                    ServiceHostActivity.StopBackgroundServices;
            } else if (dictionary.ContainsKey(console)) {
                Activity = ServiceHostActivity.Start;
            } else if (dictionary.ContainsKey(outputprocessinfo)) {
                Activity = ServiceHostActivity.DumpProcessDetails;
            } else {
                Activity = ServiceHostActivity.StartUsingSmc;
            }
        }

        private void SetProcesses(StringDictionary dictionary) {
            if (dictionary.ContainsKey(processName)) {
                IncludeProcesses = dictionary[processName];
            } else if (dictionary.ContainsKey(excludeProcessName)) {
                ExcludeProcesses = dictionary[excludeProcessName];
            }
        }

        private void SetArguments(StringDictionary dictionary) {
            if (dictionary.ContainsKey(args)) {
                string serviceArgs = dictionary[args];
                arguments = serviceArgs.Split('#');
            }

            if (dictionary.ContainsKey(start)) {
                ServiceName = dictionary[start];
            } else if (dictionary.ContainsKey(stop)) {
                ServiceName = dictionary[stop];
            }

            if (
                dictionary.ContainsKey(all) ||
                //To retail old behaviour
                // /Start=SomeService will start SomeService even if it is manual
                    !string.IsNullOrEmpty(ServiceName)
                    ) {
                StartManualServices = true;
            }

            if (dictionary.ContainsKey(nonInteractive)) {
                NonInteractive = true;
            }

            if (dictionary.ContainsKey(console)) {
                ConsoleMode = true;

                if (
                    dictionary.ContainsKey(execArch) &&
                    dictionary[execArch].Equals("Yes", StringComparison.OrdinalIgnoreCase)
                ) {
                    ExecutionArchitecture = true;
                }
            }

            if (dictionary.ContainsKey(background)) {
                ConsoleMode = false;
                ServiceName = string.Empty; //ignore if passed
            }

            if (dictionary.ContainsKey(eafile)) {
                ConfigFile = dictionary[eafile];
            }
        }

        /// <summary>
        /// Installation, Uninstallation, Start or Stop services
        /// </summary>
        public ServiceHostActivity Activity { get; private set; }
        /// <summary>
        /// /start /all - Start manual services as well
        /// </summary>
        public bool StartManualServices { get; private set; }
        /// <summary>
        /// ServiceHosting config file
        /// </summary>
        [SuppressMessage(
            "Microsoft.Performance",
            "CA1811:AvoidUncalledPrivateCode",
            Justification = "This is used in ServiceEntry::HelperMain"
        )]
        public string ConfigFile { get; private set; }

        private string[] arguments;
        /// <summary>
        /// Command line arguments
        /// </summary>
        public string[] GetArguments() {
            return arguments;
        }
        /// <summary>
        /// It was mainly introduced for Installer purpose
        /// If true, User will not be prompted with "Press any key to stop service"
        /// </summary>
        public bool NonInteractive { get; private set; }
        /// <summary>
        /// Processes to start/stop
        /// </summary>
        public string IncludeProcesses { get; private set; }
        /// <summary>
        /// Processes not to start/stop
        /// </summary>
        public string ExcludeProcesses { get; private set; }
        /// <summary>
        /// Specific service to be start/stop
        /// </summary>
        public string ServiceName { get; private set; }
        /// <summary>
        /// Start all services in console/command window.
        /// Stop all services on user pressing any key.
        /// </summary>
        public bool ConsoleMode { get; private set; }
        /// <summary>
        /// Services will be grouped per processgroup and
        /// each processgroup will be hosted in a new console window.
        /// </summary>
        public bool ExecutionArchitecture { get; private set; }
    }

    /// <summary>
    /// Enumeration telling the usages of ServiceHosting
    /// </summary>
    public enum ServiceHostActivity {
        /// <summary>
        /// Installation scenario
        /// </summary>
        Install,
        /// <summary>
        /// Uninstallation scenario
        /// </summary>
        Uninstall,
        /// <summary>
        /// Service(s) start scenario
        /// </summary>
        Start,
        /// <summary>
        /// Start all services in background.
        /// Service will wait for an event to stop.
        /// </summary>
        StartBackgroundServices,
        /// <summary>
        /// Service(s) start scenario using Services Management Console
        /// </summary>
        StartUsingSmc,
        /// <summary>
        /// Service(s) stop scenario
        /// </summary>
        Stop,
        /// <summary>
        /// Stop earlier started background services. This will just trigger an event for which
        /// previously started background servies were waiting
        /// </summary>
        StopBackgroundServices,
        /// <summary>
        /// Does not start any of the services. Dumps process releated information to console.
        /// This can be later used to start services manually (without installing)
        /// </summary>
        DumpProcessDetails
    }
}
