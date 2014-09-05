using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReplicationManagerDA;
using UtilitariosCD.Entidades;
namespace ReplicationManagerIU
{
    public partial class Core : Form
    {
        public Core()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVReplicatorData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            string headerText = DGVReplicatorData.Columns[e.ColumnIndex].HeaderText;
            string value = (string) DGVReplicatorData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            // Confirm that the cell is not empty. 
            if (string.IsNullOrEmpty(value)){
                DGVReplicatorData.Rows[e.RowIndex].ErrorText = headerText +" must not be empty";
            }


        }

        private void BtnCommitChanges_Click(object sender, EventArgs e)
        {
            AddEntry addEntry = new AddEntry();
            addEntry.Show();
        }

        private void Core_Load(object sender, EventArgs e)
        {
          
        }


    }
}
