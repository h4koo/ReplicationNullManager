namespace ReplicationManagerIU
{
    partial class AddEntry
    {
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
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.lbSourceEngine = new System.Windows.Forms.Label();
            this.cbSourceEngine = new System.Windows.Forms.ComboBox();
            this.lbSourceIPAddress = new System.Windows.Forms.Label();
            this.lbSourceDBName = new System.Windows.Forms.Label();
            this.lbSourceUser = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSourcePort = new System.Windows.Forms.TextBox();
            this.lbSourcePort = new System.Windows.Forms.Label();
            this.cbSourceTable = new System.Windows.Forms.ComboBox();
            this.cbSourceDatabase = new System.Windows.Forms.ComboBox();
            this.tbSourcePassword = new System.Windows.Forms.TextBox();
            this.tbSourceUser = new System.Windows.Forms.TextBox();
            this.tbSourceIPAddress = new System.Windows.Forms.TextBox();
            this.lbSourceTable = new System.Windows.Forms.Label();
            this.lbSourcePassword = new System.Windows.Forms.Label();
            this.gbEndPoint = new System.Windows.Forms.GroupBox();
            this.tbEndPointPort = new System.Windows.Forms.TextBox();
            this.lbEndPointPort = new System.Windows.Forms.Label();
            this.cbEndPointDatabase = new System.Windows.Forms.ComboBox();
            this.tbEndPointPassword = new System.Windows.Forms.TextBox();
            this.tbEndPointUser = new System.Windows.Forms.TextBox();
            this.tbEndPointEngine = new System.Windows.Forms.TextBox();
            this.lbEndPointPassword = new System.Windows.Forms.Label();
            this.lbEngineEndPoint = new System.Windows.Forms.Label();
            this.lbEndPointDatabase = new System.Windows.Forms.Label();
            this.lbEndPointUser = new System.Windows.Forms.Label();
            this.cbEndPointEngine = new System.Windows.Forms.ComboBox();
            this.lbEndPointIPAddress = new System.Windows.Forms.Label();
            this.btnAddEntry = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbEndPoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // lbSourceEngine
            // 
            this.lbSourceEngine.AutoSize = true;
            this.lbSourceEngine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceEngine.Location = new System.Drawing.Point(6, 26);
            this.lbSourceEngine.Name = "lbSourceEngine";
            this.lbSourceEngine.Size = new System.Drawing.Size(63, 20);
            this.lbSourceEngine.TabIndex = 0;
            this.lbSourceEngine.Text = "Engine:";
            // 
            // cbSourceEngine
            // 
            this.cbSourceEngine.FormattingEnabled = true;
            this.cbSourceEngine.Location = new System.Drawing.Point(130, 26);
            this.cbSourceEngine.Name = "cbSourceEngine";
            this.cbSourceEngine.Size = new System.Drawing.Size(194, 28);
            this.cbSourceEngine.TabIndex = 1;
            // 
            // lbSourceIPAddress
            // 
            this.lbSourceIPAddress.AutoSize = true;
            this.lbSourceIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceIPAddress.Location = new System.Drawing.Point(6, 69);
            this.lbSourceIPAddress.Name = "lbSourceIPAddress";
            this.lbSourceIPAddress.Size = new System.Drawing.Size(91, 20);
            this.lbSourceIPAddress.TabIndex = 2;
            this.lbSourceIPAddress.Text = "IP Address:";
            // 
            // lbSourceDBName
            // 
            this.lbSourceDBName.AutoSize = true;
            this.lbSourceDBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceDBName.Location = new System.Drawing.Point(6, 228);
            this.lbSourceDBName.Name = "lbSourceDBName";
            this.lbSourceDBName.Size = new System.Drawing.Size(83, 20);
            this.lbSourceDBName.TabIndex = 3;
            this.lbSourceDBName.Text = "Database:";
            // 
            // lbSourceUser
            // 
            this.lbSourceUser.AutoSize = true;
            this.lbSourceUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceUser.Location = new System.Drawing.Point(6, 138);
            this.lbSourceUser.Name = "lbSourceUser";
            this.lbSourceUser.Size = new System.Drawing.Size(47, 20);
            this.lbSourceUser.TabIndex = 4;
            this.lbSourceUser.Text = "User:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSourcePort);
            this.groupBox1.Controls.Add(this.lbSourcePort);
            this.groupBox1.Controls.Add(this.cbSourceTable);
            this.groupBox1.Controls.Add(this.cbSourceDatabase);
            this.groupBox1.Controls.Add(this.tbSourcePassword);
            this.groupBox1.Controls.Add(this.tbSourceUser);
            this.groupBox1.Controls.Add(this.tbSourceIPAddress);
            this.groupBox1.Controls.Add(this.lbSourceTable);
            this.groupBox1.Controls.Add(this.lbSourcePassword);
            this.groupBox1.Controls.Add(this.lbSourceEngine);
            this.groupBox1.Controls.Add(this.lbSourceDBName);
            this.groupBox1.Controls.Add(this.lbSourceUser);
            this.groupBox1.Controls.Add(this.cbSourceEngine);
            this.groupBox1.Controls.Add(this.lbSourceIPAddress);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 331);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // tbSourcePort
            // 
            this.tbSourcePort.Location = new System.Drawing.Point(130, 101);
            this.tbSourcePort.Name = "tbSourcePort";
            this.tbSourcePort.Size = new System.Drawing.Size(121, 26);
            this.tbSourcePort.TabIndex = 13;
            this.tbSourcePort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSourcePort_KeyPress);
            // 
            // lbSourcePort
            // 
            this.lbSourcePort.AutoSize = true;
            this.lbSourcePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourcePort.Location = new System.Drawing.Point(6, 107);
            this.lbSourcePort.Name = "lbSourcePort";
            this.lbSourcePort.Size = new System.Drawing.Size(42, 20);
            this.lbSourcePort.TabIndex = 12;
            this.lbSourcePort.Text = "Port:";
            // 
            // cbSourceTable
            // 
            this.cbSourceTable.FormattingEnabled = true;
            this.cbSourceTable.Location = new System.Drawing.Point(130, 268);
            this.cbSourceTable.Name = "cbSourceTable";
            this.cbSourceTable.Size = new System.Drawing.Size(121, 28);
            this.cbSourceTable.TabIndex = 11;
            // 
            // cbSourceDatabase
            // 
            this.cbSourceDatabase.FormattingEnabled = true;
            this.cbSourceDatabase.Location = new System.Drawing.Point(130, 230);
            this.cbSourceDatabase.Name = "cbSourceDatabase";
            this.cbSourceDatabase.Size = new System.Drawing.Size(121, 28);
            this.cbSourceDatabase.TabIndex = 10;
            // 
            // tbSourcePassword
            // 
            this.tbSourcePassword.Location = new System.Drawing.Point(130, 164);
            this.tbSourcePassword.Name = "tbSourcePassword";
            this.tbSourcePassword.Size = new System.Drawing.Size(121, 26);
            this.tbSourcePassword.TabIndex = 9;
            this.tbSourcePassword.UseSystemPasswordChar = true;
            // 
            // tbSourceUser
            // 
            this.tbSourceUser.Location = new System.Drawing.Point(130, 132);
            this.tbSourceUser.Name = "tbSourceUser";
            this.tbSourceUser.Size = new System.Drawing.Size(121, 26);
            this.tbSourceUser.TabIndex = 8;
            // 
            // tbSourceIPAddress
            // 
            this.tbSourceIPAddress.Location = new System.Drawing.Point(130, 69);
            this.tbSourceIPAddress.Name = "tbSourceIPAddress";
            this.tbSourceIPAddress.Size = new System.Drawing.Size(121, 26);
            this.tbSourceIPAddress.TabIndex = 7;
            // 
            // lbSourceTable
            // 
            this.lbSourceTable.AutoSize = true;
            this.lbSourceTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourceTable.Location = new System.Drawing.Point(6, 266);
            this.lbSourceTable.Name = "lbSourceTable";
            this.lbSourceTable.Size = new System.Drawing.Size(52, 20);
            this.lbSourceTable.TabIndex = 6;
            this.lbSourceTable.Text = "Table:";
            // 
            // lbSourcePassword
            // 
            this.lbSourcePassword.AutoSize = true;
            this.lbSourcePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSourcePassword.Location = new System.Drawing.Point(6, 170);
            this.lbSourcePassword.Name = "lbSourcePassword";
            this.lbSourcePassword.Size = new System.Drawing.Size(82, 20);
            this.lbSourcePassword.TabIndex = 5;
            this.lbSourcePassword.Text = "Password:";
            // 
            // gbEndPoint
            // 
            this.gbEndPoint.Controls.Add(this.tbEndPointPort);
            this.gbEndPoint.Controls.Add(this.lbEndPointPort);
            this.gbEndPoint.Controls.Add(this.cbEndPointDatabase);
            this.gbEndPoint.Controls.Add(this.tbEndPointPassword);
            this.gbEndPoint.Controls.Add(this.tbEndPointUser);
            this.gbEndPoint.Controls.Add(this.tbEndPointEngine);
            this.gbEndPoint.Controls.Add(this.lbEndPointPassword);
            this.gbEndPoint.Controls.Add(this.lbEngineEndPoint);
            this.gbEndPoint.Controls.Add(this.lbEndPointDatabase);
            this.gbEndPoint.Controls.Add(this.lbEndPointUser);
            this.gbEndPoint.Controls.Add(this.cbEndPointEngine);
            this.gbEndPoint.Controls.Add(this.lbEndPointIPAddress);
            this.gbEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEndPoint.Location = new System.Drawing.Point(348, 12);
            this.gbEndPoint.Name = "gbEndPoint";
            this.gbEndPoint.Size = new System.Drawing.Size(356, 331);
            this.gbEndPoint.TabIndex = 6;
            this.gbEndPoint.TabStop = false;
            this.gbEndPoint.Text = "EndPoint";
            // 
            // tbEndPointPort
            // 
            this.tbEndPointPort.Location = new System.Drawing.Point(130, 104);
            this.tbEndPointPort.Name = "tbEndPointPort";
            this.tbEndPointPort.Size = new System.Drawing.Size(121, 26);
            this.tbEndPointPort.TabIndex = 12;
            this.tbEndPointPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEndPointPort_KeyPress);
            // 
            // lbEndPointPort
            // 
            this.lbEndPointPort.AutoSize = true;
            this.lbEndPointPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndPointPort.Location = new System.Drawing.Point(7, 107);
            this.lbEndPointPort.Name = "lbEndPointPort";
            this.lbEndPointPort.Size = new System.Drawing.Size(42, 20);
            this.lbEndPointPort.TabIndex = 11;
            this.lbEndPointPort.Text = "Port:";
            // 
            // cbEndPointDatabase
            // 
            this.cbEndPointDatabase.FormattingEnabled = true;
            this.cbEndPointDatabase.Location = new System.Drawing.Point(130, 225);
            this.cbEndPointDatabase.Name = "cbEndPointDatabase";
            this.cbEndPointDatabase.Size = new System.Drawing.Size(121, 28);
            this.cbEndPointDatabase.TabIndex = 10;
            // 
            // tbEndPointPassword
            // 
            this.tbEndPointPassword.Location = new System.Drawing.Point(130, 167);
            this.tbEndPointPassword.Name = "tbEndPointPassword";
            this.tbEndPointPassword.Size = new System.Drawing.Size(121, 26);
            this.tbEndPointPassword.TabIndex = 9;
            this.tbEndPointPassword.UseSystemPasswordChar = true;
            // 
            // tbEndPointUser
            // 
            this.tbEndPointUser.Location = new System.Drawing.Point(130, 135);
            this.tbEndPointUser.Name = "tbEndPointUser";
            this.tbEndPointUser.Size = new System.Drawing.Size(121, 26);
            this.tbEndPointUser.TabIndex = 8;
            // 
            // tbEndPointEngine
            // 
            this.tbEndPointEngine.Location = new System.Drawing.Point(130, 69);
            this.tbEndPointEngine.Name = "tbEndPointEngine";
            this.tbEndPointEngine.Size = new System.Drawing.Size(121, 26);
            this.tbEndPointEngine.TabIndex = 7;
            // 
            // lbEndPointPassword
            // 
            this.lbEndPointPassword.AutoSize = true;
            this.lbEndPointPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndPointPassword.Location = new System.Drawing.Point(6, 170);
            this.lbEndPointPassword.Name = "lbEndPointPassword";
            this.lbEndPointPassword.Size = new System.Drawing.Size(82, 20);
            this.lbEndPointPassword.TabIndex = 5;
            this.lbEndPointPassword.Text = "Password:";
            // 
            // lbEngineEndPoint
            // 
            this.lbEngineEndPoint.AutoSize = true;
            this.lbEngineEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEngineEndPoint.Location = new System.Drawing.Point(6, 26);
            this.lbEngineEndPoint.Name = "lbEngineEndPoint";
            this.lbEngineEndPoint.Size = new System.Drawing.Size(63, 20);
            this.lbEngineEndPoint.TabIndex = 0;
            this.lbEngineEndPoint.Text = "Engine:";
            // 
            // lbEndPointDatabase
            // 
            this.lbEndPointDatabase.AutoSize = true;
            this.lbEndPointDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndPointDatabase.Location = new System.Drawing.Point(6, 223);
            this.lbEndPointDatabase.Name = "lbEndPointDatabase";
            this.lbEndPointDatabase.Size = new System.Drawing.Size(83, 20);
            this.lbEndPointDatabase.TabIndex = 3;
            this.lbEndPointDatabase.Text = "Database:";
            // 
            // lbEndPointUser
            // 
            this.lbEndPointUser.AutoSize = true;
            this.lbEndPointUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndPointUser.Location = new System.Drawing.Point(6, 138);
            this.lbEndPointUser.Name = "lbEndPointUser";
            this.lbEndPointUser.Size = new System.Drawing.Size(47, 20);
            this.lbEndPointUser.TabIndex = 4;
            this.lbEndPointUser.Text = "User:";
            // 
            // cbEndPointEngine
            // 
            this.cbEndPointEngine.FormattingEnabled = true;
            this.cbEndPointEngine.Location = new System.Drawing.Point(130, 26);
            this.cbEndPointEngine.Name = "cbEndPointEngine";
            this.cbEndPointEngine.Size = new System.Drawing.Size(199, 28);
            this.cbEndPointEngine.TabIndex = 1;
            // 
            // lbEndPointIPAddress
            // 
            this.lbEndPointIPAddress.AutoSize = true;
            this.lbEndPointIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEndPointIPAddress.Location = new System.Drawing.Point(6, 69);
            this.lbEndPointIPAddress.Name = "lbEndPointIPAddress";
            this.lbEndPointIPAddress.Size = new System.Drawing.Size(91, 20);
            this.lbEndPointIPAddress.TabIndex = 2;
            this.lbEndPointIPAddress.Text = "IP Address:";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(560, 381);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(75, 23);
            this.btnAddEntry.TabIndex = 7;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // AddEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 436);
            this.Controls.Add(this.btnAddEntry);
            this.Controls.Add(this.gbEndPoint);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEntry";
            this.Text = "AddEntry";
            this.Load += new System.EventHandler(this.AddEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEndPoint.ResumeLayout(false);
            this.gbEndPoint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.ComboBox cbSourceEngine;
        private System.Windows.Forms.Label lbSourceEngine;
        private System.Windows.Forms.Label lbSourceIPAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbSourceTable;
        private System.Windows.Forms.ComboBox cbSourceDatabase;
        private System.Windows.Forms.TextBox tbSourcePassword;
        private System.Windows.Forms.TextBox tbSourceUser;
        private System.Windows.Forms.TextBox tbSourceIPAddress;
        private System.Windows.Forms.Label lbSourceTable;
        private System.Windows.Forms.Label lbSourcePassword;
        private System.Windows.Forms.Label lbSourceDBName;
        private System.Windows.Forms.Label lbSourceUser;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.GroupBox gbEndPoint;
        private System.Windows.Forms.ComboBox cbEndPointDatabase;
        private System.Windows.Forms.TextBox tbEndPointPassword;
        private System.Windows.Forms.TextBox tbEndPointUser;
        private System.Windows.Forms.TextBox tbEndPointEngine;
        private System.Windows.Forms.Label lbEndPointPassword;
        private System.Windows.Forms.Label lbEngineEndPoint;
        private System.Windows.Forms.Label lbEndPointDatabase;
        private System.Windows.Forms.Label lbEndPointUser;
        private System.Windows.Forms.ComboBox cbEndPointEngine;
        private System.Windows.Forms.Label lbEndPointIPAddress;
        private System.Windows.Forms.TextBox tbEndPointPort;
        private System.Windows.Forms.Label lbEndPointPort;
        private System.Windows.Forms.TextBox tbSourcePort;
        private System.Windows.Forms.Label lbSourcePort;
    }
}