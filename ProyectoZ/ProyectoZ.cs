using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoZ.DataAccess;

namespace ProyectoZ
{
    public partial class ProyectoZ : Form
    {
        public ProyectoZ()
        {
            InitializeComponent();
        }

        private void ProyectoZ_Load(object sender, EventArgs e)
        {

        }


        private void btn_Ejecutar_Click(object sender, EventArgs e)
        {
            ProyectoZDA proyectoZDA = new ProyectoZDA("", "", "localhost", "1433", "world");

            DGV_Tabla.DataSource = proyectoZDA.getAllCountry();
            DGV_Tabla.DataMember = "country";

        }
    }
}
