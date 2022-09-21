namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxServiceDisplayName = new System.Windows.Forms.TextBox();
            this.textBoxServiceName = new System.Windows.Forms.TextBox();
            this.textBoxNamespace = new System.Windows.Forms.TextBox();
            this.textBoxServiceDescription = new System.Windows.Forms.TextBox();
            this.textBoxExecutableName = new System.Windows.Forms.TextBox();
            this.textBoxTargetDirectory = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Service Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Service Display Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Namespace";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Service Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Executable Name";
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(504, 219);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(137, 23);
            this.buttonGenerate.TabIndex = 7;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxServiceDisplayName
            // 
            this.textBoxServiceDisplayName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceProjectCreator.Properties.Settings.Default, "ServiceDisplayName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxServiceDisplayName.Location = new System.Drawing.Point(157, 148);
            this.textBoxServiceDisplayName.Name = "textBoxServiceDisplayName";
            this.textBoxServiceDisplayName.Size = new System.Drawing.Size(484, 20);
            this.textBoxServiceDisplayName.TabIndex = 5;
            this.textBoxServiceDisplayName.Text = global::ServiceProjectCreator.Properties.Settings.Default.ServiceDisplayName;
            // 
            // textBoxServiceName
            // 
            this.textBoxServiceName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceProjectCreator.Properties.Settings.Default, "ServiceName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxServiceName.Location = new System.Drawing.Point(157, 120);
            this.textBoxServiceName.Name = "textBoxServiceName";
            this.textBoxServiceName.Size = new System.Drawing.Size(484, 20);
            this.textBoxServiceName.TabIndex = 4;
            this.textBoxServiceName.Text = global::ServiceProjectCreator.Properties.Settings.Default.ServiceName;
            // 
            // textBoxNamespace
            // 
            this.textBoxNamespace.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceProjectCreator.Properties.Settings.Default, "Namespace", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxNamespace.Location = new System.Drawing.Point(157, 93);
            this.textBoxNamespace.Name = "textBoxNamespace";
            this.textBoxNamespace.Size = new System.Drawing.Size(484, 20);
            this.textBoxNamespace.TabIndex = 3;
            this.textBoxNamespace.Text = global::ServiceProjectCreator.Properties.Settings.Default.Namespace;
            // 
            // textBoxServiceDescription
            // 
            this.textBoxServiceDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceProjectCreator.Properties.Settings.Default, "ServiceDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxServiceDescription.Location = new System.Drawing.Point(157, 174);
            this.textBoxServiceDescription.Name = "textBoxServiceDescription";
            this.textBoxServiceDescription.Size = new System.Drawing.Size(484, 20);
            this.textBoxServiceDescription.TabIndex = 6;
            this.textBoxServiceDescription.Text = global::ServiceProjectCreator.Properties.Settings.Default.ServiceDescription;
            // 
            // textBoxExecutableName
            // 
            this.textBoxExecutableName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceProjectCreator.Properties.Settings.Default, "ExecutableName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxExecutableName.Location = new System.Drawing.Point(157, 70);
            this.textBoxExecutableName.Name = "textBoxExecutableName";
            this.textBoxExecutableName.Size = new System.Drawing.Size(484, 20);
            this.textBoxExecutableName.TabIndex = 2;
            this.textBoxExecutableName.Text = global::ServiceProjectCreator.Properties.Settings.Default.ExecutableName;
            // 
            // textBoxTargetDirectory
            // 
            this.textBoxTargetDirectory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxTargetDirectory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBoxTargetDirectory.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ServiceProjectCreator.Properties.Settings.Default, "TargetDirectory", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxTargetDirectory.Location = new System.Drawing.Point(157, 44);
            this.textBoxTargetDirectory.Name = "textBoxTargetDirectory";
            this.textBoxTargetDirectory.Size = new System.Drawing.Size(484, 20);
            this.textBoxTargetDirectory.TabIndex = 1;
            this.textBoxTargetDirectory.Text = global::ServiceProjectCreator.Properties.Settings.Default.TargetDirectory;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "(c) Ashutosh Bhawasinka";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 259);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.textBoxServiceDisplayName);
            this.Controls.Add(this.textBoxServiceName);
            this.Controls.Add(this.textBoxNamespace);
            this.Controls.Add(this.textBoxServiceDescription);
            this.Controls.Add(this.textBoxExecutableName);
            this.Controls.Add(this.textBoxTargetDirectory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Service Project Creator v1 Beta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTargetDirectory;
        private System.Windows.Forms.TextBox textBoxExecutableName;
        private System.Windows.Forms.TextBox textBoxNamespace;
        private System.Windows.Forms.TextBox textBoxServiceName;
        private System.Windows.Forms.TextBox textBoxServiceDisplayName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxServiceDescription;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label label7;
    }
}

