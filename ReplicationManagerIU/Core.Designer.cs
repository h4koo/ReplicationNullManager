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
            this.Load += new System.EventHandler(this.Core_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReplicatorData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVReplicatorData;
        private System.Windows.Forms.Button BtnCommitChanges;

    }
}

