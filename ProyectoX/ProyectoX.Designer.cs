namespace ProyectoX
{
    partial class ProyectoX
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV_Tabla = new System.Windows.Forms.DataGridView();
            this.btn_Ejecutar = new System.Windows.Forms.Button();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SurfaceArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IndepYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Population = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LifeExpectancy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GNPOld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GovernmentForm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadOfState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Tabla
            // 
            this.DGV_Tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Tabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Name,
            this.Region,
            this.SurfaceArea,
            this.IndepYear,
            this.Population,
            this.LifeExpectancy,
            this.GNP,
            this.GNPOld,
            this.LocalName,
            this.GovernmentForm,
            this.HeadOfState,
            this.Capital,
            this.Code2});
            this.DGV_Tabla.Location = new System.Drawing.Point(13, 12);
            this.DGV_Tabla.Name = "DGV_Tabla";
            this.DGV_Tabla.Size = new System.Drawing.Size(841, 236);
            this.DGV_Tabla.TabIndex = 1;
            // 
            // btn_Ejecutar
            // 
            this.btn_Ejecutar.Location = new System.Drawing.Point(393, 254);
            this.btn_Ejecutar.Name = "btn_Ejecutar";
            this.btn_Ejecutar.Size = new System.Drawing.Size(75, 23);
            this.btn_Ejecutar.TabIndex = 2;
            this.btn_Ejecutar.Text = "Ejecutar";
            this.btn_Ejecutar.UseVisualStyleBackColor = true;
            this.btn_Ejecutar.Click += new System.EventHandler(this.btn_Ejecutar_Click);
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Region
            // 
            this.Region.DataPropertyName = "Region";
            this.Region.HeaderText = "Region";
            this.Region.Name = "Region";
            // 
            // SurfaceArea
            // 
            this.SurfaceArea.DataPropertyName = "SurfaceArea";
            this.SurfaceArea.HeaderText = "SurfaceArea";
            this.SurfaceArea.Name = "SurfaceArea";
            this.SurfaceArea.ReadOnly = true;
            // 
            // IndepYear
            // 
            this.IndepYear.DataPropertyName = "IndepYear";
            this.IndepYear.HeaderText = "IndepYear";
            this.IndepYear.Name = "IndepYear";
            this.IndepYear.ReadOnly = true;
            // 
            // Population
            // 
            this.Population.DataPropertyName = "Population";
            this.Population.HeaderText = "Population";
            this.Population.Name = "Population";
            this.Population.ReadOnly = true;
            // 
            // LifeExpectancy
            // 
            this.LifeExpectancy.DataPropertyName = "LifeExpectancy";
            this.LifeExpectancy.HeaderText = "LifeExpectancy";
            this.LifeExpectancy.Name = "LifeExpectancy";
            this.LifeExpectancy.ReadOnly = true;
            // 
            // GNP
            // 
            this.GNP.DataPropertyName = "GNP";
            this.GNP.HeaderText = "GNP";
            this.GNP.Name = "GNP";
            this.GNP.ReadOnly = true;
            // 
            // GNPOld
            // 
            this.GNPOld.DataPropertyName = "GNPOld";
            this.GNPOld.HeaderText = "GNPOld";
            this.GNPOld.Name = "GNPOld";
            this.GNPOld.ReadOnly = true;
            // 
            // LocalName
            // 
            this.LocalName.DataPropertyName = "LocalName";
            this.LocalName.HeaderText = "LocalName";
            this.LocalName.Name = "LocalName";
            this.LocalName.ReadOnly = true;
            // 
            // GovernmentForm
            // 
            this.GovernmentForm.DataPropertyName = "GovernmentForm";
            this.GovernmentForm.HeaderText = "GovernmentForm";
            this.GovernmentForm.Name = "GovernmentForm";
            this.GovernmentForm.ReadOnly = true;
            // 
            // HeadOfState
            // 
            this.HeadOfState.DataPropertyName = "HeadOfState";
            this.HeadOfState.HeaderText = "HeadOfState";
            this.HeadOfState.Name = "HeadOfState";
            this.HeadOfState.ReadOnly = true;
            // 
            // Capital
            // 
            this.Capital.DataPropertyName = "Capital";
            this.Capital.HeaderText = "Capital";
            this.Capital.Name = "Capital";
            this.Capital.ReadOnly = true;
            // 
            // Code2
            // 
            this.Code2.DataPropertyName = "Code2";
            this.Code2.HeaderText = "Code2";
            this.Code2.Name = "Code2";
            this.Code2.ReadOnly = true;
            // 
            // ProyectoX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 289);
            this.Controls.Add(this.btn_Ejecutar);
            this.Controls.Add(this.DGV_Tabla);
            //this.Name = "ProyectoX";
            this.Text = "ProyectoX";
            this.Load += new System.EventHandler(this.ProyectoX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Tabla;
        private System.Windows.Forms.Button btn_Ejecutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Region;
        private System.Windows.Forms.DataGridViewTextBoxColumn SurfaceArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn IndepYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Population;
        private System.Windows.Forms.DataGridViewTextBoxColumn LifeExpectancy;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNP;
        private System.Windows.Forms.DataGridViewTextBoxColumn GNPOld;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GovernmentForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeadOfState;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capital;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code2;
    }
}

