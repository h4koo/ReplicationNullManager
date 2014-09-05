using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosCD.Entities;
using ReplicationManagerDA.DataAccess;

namespace ReplicationManagerIU
{
    public partial class AddEntry : Form
    {
        public AddEntry()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Source Port Digit Validation
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSourcePort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just Allow Numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// EndPoint Port Digit Validation
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbEndPointPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just Allow Numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// This Method allow the Interface to Load all the Supported Engines using the Data Access Layer
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        /// <param name="sender">Related to the UI C#</param>
        /// <param name="e">Related to the UI C#</param>
        private void AddEntry_Load(object sender, EventArgs e)
        {
            EngineDA EnginesDA = new EngineDA();
            List<Engine> Engines = EnginesDA.GetAllSupportedEngines();

            if (Engines.Count > 0)
            {
                foreach (Engine engine in Engines)
                {
                    cbSourceEngine.Items.Add(engine);
                    cbEndPointEngine.Items.Add(engine);
                }
                cbSourceEngine.SelectedIndex = 0;
                cbEndPointEngine.SelectedIndex = 0;
            }
            else {
                MessageBox.Show("Supported Engines Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            MessageBox.Show((cbEndPointEngine.SelectedItem as Engine).IntIdEngine.ToString());
        }


    }
}
