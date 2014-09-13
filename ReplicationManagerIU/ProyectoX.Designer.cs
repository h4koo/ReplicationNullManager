namespace ReplicationManagerIU
{
    partial class ProyectoX
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
            this.DGV_Tabla = new System.Windows.Forms.DataGridView();
            this.btn_Ejecutar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Tabla
            // 
            this.DGV_Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Tabla.Location = new System.Drawing.Point(12, 6);
            this.DGV_Tabla.Name = "DGV_Tabla";
            this.DGV_Tabla.Size = new System.Drawing.Size(841, 150);
            this.DGV_Tabla.TabIndex = 0;
            // 
            // btn_Ejecutar
            // 
            this.btn_Ejecutar.Location = new System.Drawing.Point(403, 162);
            this.btn_Ejecutar.Name = "btn_Ejecutar";
            this.btn_Ejecutar.Size = new System.Drawing.Size(75, 23);
            this.btn_Ejecutar.TabIndex = 1;
            this.btn_Ejecutar.Text = "Ejecutar";
            this.btn_Ejecutar.UseVisualStyleBackColor = true;
            this.btn_Ejecutar.Click += new System.EventHandler(this.btn_Ejecutar_Click);
            // 
            // ProyectoX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 194);
            this.Controls.Add(this.btn_Ejecutar);
            this.Controls.Add(this.DGV_Tabla);
            this.Name = "ProyectoX";
            this.Text = "ProyectoX";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Tabla;
        private System.Windows.Forms.Button btn_Ejecutar;
    }
}