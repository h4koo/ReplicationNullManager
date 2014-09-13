using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProyectoX.DataAccess;

namespace ProyectoX
{
    public partial class ProyectoX : Form
    {
        public ProyectoX()
        {
            InitializeComponent();
        }

        private void ProyectoX_Load(object sender, EventArgs e)
        {

        }

        private void btn_Ejecutar_Click(object sender, EventArgs e)
        {
            ProyectoXDA proyectoXDA = new ProyectoXDA("root", "123456", "localhost", "3306", "world");           
            
            DGV_Tabla.DataSource = proyectoXDA.getAllCountry();
            DGV_Tabla.DataMember = "country";                        

        }
    }
}
