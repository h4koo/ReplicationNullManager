using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReplicationManagerIU
{
    public partial class AddEntry : Form
    {
        public AddEntry()
        {
            InitializeComponent();
        }

        private void tbSourcePort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just Allow Numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void tbEndPointPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Just Allow Numbers
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
