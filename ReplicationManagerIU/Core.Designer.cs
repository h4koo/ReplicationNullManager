namespace ReplicationManagerIU
{
    partial class Core
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
            this.DGVReplicatorData = new System.Windows.Forms.DataGridView();
            this.ClnSourceMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnSourceIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDestinyIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDestinyMotor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDestinyUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClnDestinyPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnCommitChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplicatorData)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVReplicatorData
            // 
            this.DGVReplicatorData.AllowUserToAddRows = false;
            this.DGVReplicatorData.AllowUserToOrderColumns = true;
            this.DGVReplicatorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReplicatorData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClnSourceMotor,
            this.ClnSourceIP,
            this.ClnDatabaseName,
            this.ClnUser,
            this.ClnPassword,
            this.ClnTable,
            this.ClnDestinyIP,
            this.ClnDestinyMotor,
            this.ClnDestinyUser,
            this.ClnDestinyPassword});
            this.DGVReplicatorData.Location = new System.Drawing.Point(13, 23);
            this.DGVReplicatorData.Name = "DGVReplicatorData";
            this.DGVReplicatorData.ReadOnly = true;
            this.DGVReplicatorData.Size = new System.Drawing.Size(1044, 150);
            this.DGVReplicatorData.TabIndex = 0;
            this.DGVReplicatorData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVReplicatorData_CellValidated);
            // 
            // ClnSourceMotor
            // 
            this.ClnSourceMotor.HeaderText = "Source Motor";
            this.ClnSourceMotor.Name = "ClnSourceMotor";
            this.ClnSourceMotor.ReadOnly = true;
            // 
            // ClnSourceIP
            // 
            this.ClnSourceIP.HeaderText = "Source IP";
            this.ClnSourceIP.Name = "ClnSourceIP";
            this.ClnSourceIP.ReadOnly = true;
            // 
            // ClnDatabaseName
            // 
            this.ClnDatabaseName.HeaderText = "DatabaseName";
            this.ClnDatabaseName.Name = "ClnDatabaseName";
            this.ClnDatabaseName.ReadOnly = true;
            // 
            // ClnUser
            // 
            this.ClnUser.HeaderText = "User";
            this.ClnUser.Name = "ClnUser";
            this.ClnUser.ReadOnly = true;
            // 
            // ClnPassword
            // 
            this.ClnPassword.HeaderText = "Password";
            this.ClnPassword.Name = "ClnPassword";
            this.ClnPassword.ReadOnly = true;
            // 
            // ClnTable
            // 
            this.ClnTable.HeaderText = "Table";
            this.ClnTable.Name = "ClnTable";
            this.ClnTable.ReadOnly = true;
            // 
            // ClnDestinyIP
            // 
            this.ClnDestinyIP.HeaderText = "Destiny IP";
            this.ClnDestinyIP.Name = "ClnDestinyIP";
            this.ClnDestinyIP.ReadOnly = true;
            // 
            // ClnDestinyMotor
            // 
            this.ClnDestinyMotor.HeaderText = "Destiny Motor";
            this.ClnDestinyMotor.Name = "ClnDestinyMotor";
            this.ClnDestinyMotor.ReadOnly = true;
            // 
            // ClnDestinyUser
            // 
            this.ClnDestinyUser.HeaderText = "Destiny User";
            this.ClnDestinyUser.Name = "ClnDestinyUser";
            this.ClnDestinyUser.ReadOnly = true;
            // 
            // ClnDestinyPassword
            // 
            this.ClnDestinyPassword.HeaderText = "Destiny Password";
            this.ClnDestinyPassword.Name = "ClnDestinyPassword";
            this.ClnDestinyPassword.ReadOnly = true;
            // 
            // BtnCommitChanges
            // 
            this.BtnCommitChanges.Location = new System.Drawing.Point(934, 197);
            this.BtnCommitChanges.Name = "BtnCommitChanges";
            this.BtnCommitChanges.Size = new System.Drawing.Size(120, 23);
            this.BtnCommitChanges.TabIndex = 1;
            this.BtnCommitChanges.Text = "Commit Changes";
            this.BtnCommitChanges.UseVisualStyleBackColor = true;
            this.BtnCommitChanges.Click += new System.EventHandler(this.BtnCommitChanges_Click);
            // 
            // Core
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 243);
            this.Controls.Add(this.BtnCommitChanges);
            this.Controls.Add(this.DGVReplicatorData);
            this.Name = "Core";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplicatorData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVReplicatorData;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnSourceMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnSourceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDatabaseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnPassword;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDestinyIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDestinyMotor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDestinyUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClnDestinyPassword;
        private System.Windows.Forms.Button BtnCommitChanges;

    }
}

