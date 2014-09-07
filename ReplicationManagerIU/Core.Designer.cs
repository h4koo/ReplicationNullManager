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
            this.BtnCommitChanges = new System.Windows.Forms.Button();
            this.btnEnableDisable = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplicatorData)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVReplicatorData
            // 
            this.DGVReplicatorData.AllowUserToAddRows = false;
            this.DGVReplicatorData.AllowUserToOrderColumns = true;
            this.DGVReplicatorData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReplicatorData.Location = new System.Drawing.Point(13, 23);
            this.DGVReplicatorData.Name = "DGVReplicatorData";
            this.DGVReplicatorData.ReadOnly = true;
            this.DGVReplicatorData.Size = new System.Drawing.Size(1044, 150);
            this.DGVReplicatorData.TabIndex = 0;
            this.DGVReplicatorData.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVReplicatorData_CellValidated);
            // 
            // BtnCommitChanges
            // 
            this.BtnCommitChanges.Location = new System.Drawing.Point(934, 197);
            this.BtnCommitChanges.Name = "BtnCommitChanges";
            this.BtnCommitChanges.Size = new System.Drawing.Size(120, 23);
            this.BtnCommitChanges.TabIndex = 1;
            this.BtnCommitChanges.Text = "Add Entry";
            this.BtnCommitChanges.UseVisualStyleBackColor = true;
            this.BtnCommitChanges.Click += new System.EventHandler(this.BtnCommitChanges_Click);
            // 
            // btnEnableDisable
            // 
            this.btnEnableDisable.Location = new System.Drawing.Point(808, 197);
            this.btnEnableDisable.Name = "btnEnableDisable";
            this.btnEnableDisable.Size = new System.Drawing.Size(120, 23);
            this.btnEnableDisable.TabIndex = 2;
            this.btnEnableDisable.Text = "Enable/Disable";
            this.btnEnableDisable.UseVisualStyleBackColor = true;
            this.btnEnableDisable.Click += new System.EventHandler(this.btnEnableDisable_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(727, 197);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(646, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Core
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 243);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnEnableDisable);
            this.Controls.Add(this.BtnCommitChanges);
            this.Controls.Add(this.DGVReplicatorData);
            this.Name = "Core";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Core_Load);
            this.VisibleChanged += new System.EventHandler(this.Core_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplicatorData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVReplicatorData;
        private System.Windows.Forms.Button BtnCommitChanges;
        private System.Windows.Forms.Button btnEnableDisable;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;

    }
}

