using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceProjectCreator.Properties;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {

        private string exportDirectory;
        string projectNamespace;
        private string executableName;
        private string serviceName;
        private string serviceDisplayName;
        private string serviceDescription;

        private const string NamespaceToken = "$NAMESPACE$";
        private const string ExecutableNameToken = "$EXECUTABLE_NAME$";
        private const string ServiceNameToken = "$SERVICE_NAME$";
        private const string ServiceDisplayNameToken = "$SERVICE_DISPLAY_NAME$";
        private const string ServiceDescriptionToken = "$SERVICE_DESCRIPTION$";

        private string[] fileNames = Assembly.GetExecutingAssembly().GetManifestResourceNames();
        public Form1()
        {
            InitializeComponent();
            System.Diagnostics.Trace.WriteLine(fileNames.Length);
            Closing += Form1_Closing;
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            Settings.Default.Save();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            exportDirectory = textBoxTargetDirectory.Text;
            projectNamespace = textBoxNamespace.Text;
            executableName = textBoxExecutableName.Text;
            serviceName = textBoxServiceName.Text;
            serviceDisplayName = textBoxServiceDisplayName.Text;
            serviceDescription = textBoxServiceDescription.Text;

            GenerateFiles();
        }

        void GenerateFiles()
        {
            string[] files =
            {
                "$EXECUTABLE_NAME$.csproj",
                "$SERVICE_NAME$.cs",
                "$SERVICE_NAME$.Designer.cs",
                "ServiceEntry.cs",
                "ServiceHostArguments.cs",
                "ServiceInstaller.cs",
                "ServiceInstaller.Designer.cs",
                "ServiceInstaller.resx",
                "Properties.AssemblyInfo.cs",
                "Properties.Settings.Designer.cs",
                "Properties.Settings.settings"
            };
            string baseUri = "ServiceProjectCreator.Template.";
            foreach (string file in files)
            {
                string destinationFileName = Path.Combine(exportDirectory, ReplaceContent(file).Replace("Properties.", "Properties\\"));
                string content = GetFileContent(baseUri + file);
                // ReSharper disable once AssignNullToNotNullAttribute
                Directory.CreateDirectory(Path.GetDirectoryName(destinationFileName));
                File.WriteAllText(destinationFileName, ReplaceContent(content));
            }
        }

        string ReplaceContent(string input)
        {
            string result = input;

            result = result
                .Replace(NamespaceToken, projectNamespace)
                .Replace(ExecutableNameToken, executableName)
                .Replace(ServiceNameToken, serviceName)
                .Replace(ServiceDisplayNameToken, serviceDisplayName)
                .Replace(ServiceDescriptionToken, serviceDescription)
                .Replace("$GUID$", Guid.NewGuid().ToString().ToUpperInvariant());

            return result;
        }

        string GetFileContent(string path)
        {
            string newPath = path;
            if (newPath.EndsWith(".resx"))
            {
                newPath = newPath.Replace(".resx", ".resx.template");
            }
            string content;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(newPath))
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                StreamReader reader = new StreamReader(stream);
                content = reader.ReadToEnd();
            }

            return content;
        }
    }
}
