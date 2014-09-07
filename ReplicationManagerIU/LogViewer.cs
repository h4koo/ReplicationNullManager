using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosCD.LogErrores;
using System.IO;
using System.Security.Permissions;

namespace ReplicationManagerIU
{
    public partial class LogViewer : Form
    {
        public LogViewer()
        {
            InitializeComponent();
        }

        private void LogViewer_Load(object sender, EventArgs e)
        {
            LogErrores tempLogErrores = new LogErrores();
            string path = tempLogErrores.LogLocation();
            rtbLog.LoadFile(path, RichTextBoxStreamType.PlainText);
           
       
        }
    }
}
