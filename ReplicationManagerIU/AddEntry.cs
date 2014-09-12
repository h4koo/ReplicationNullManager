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
            Replica newReplica = new Replica();
            
            //Getting all Source Information
            newReplica.IntIdSourceEngine = (cbSourceEngine.SelectedItem as Engine).IntIdEngine;
            newReplica.StrSourceEngine = (cbSourceEngine.SelectedItem as Engine).StrName;
            newReplica.IntSourcePort = Convert.ToInt32(tbSourcePort.Text);
            newReplica.StrSourceIPAddress = tbSourceIPAddress.Text;
            newReplica.StrSourceUser = tbSourceUser.Text;
            newReplica.StrSourcePassword = tbSourcePassword.Text;
            newReplica.StrSourceDatabase = cbSourceDatabase.Text;
            newReplica.StrSourceTable = cbSourceTable.Text;
            //Getting all Terminal Information
            newReplica.IntIdTerminalEngine = (cbEndPointEngine.SelectedItem as Engine).IntIdEngine;
            newReplica.StrTerminalEngine = (cbEndPointEngine.SelectedItem as Engine).StrName;
            newReplica.IntTerminalPort = Convert.ToInt32(tbEndPointPort.Text);
            newReplica.StrTerminalIPAddress = tbEndPointIPAddress.Text;
            newReplica.StrTerminalUser = tbEndPointUser.Text;
            newReplica.StrTerminalPassword = tbEndPointPassword.Text;
            newReplica.StrTerminalDatabase = cbEndPointDatabase.Text;
            ReplicaDA replicaDA = new ReplicaDA();
            replicaDA.Insert(newReplica);
            InitialReplicaClientConfig(newReplica);
            this.Close();


            //MessageBox.Show((cbEndPointEngine.SelectedItem as Engine).IntIdEngine.ToString());
            
        }
        /// <summary>
        /// This will configure the Initial Replica requirements on the client
        /// </summary>
        /// <param name="replica"></param>
        public void InitialReplicaClientConfig(Replica replica){
            //Source Config
            Table table = new Table();
            if (replica.StrSourceEngine.Contains("SQL Server")){
                SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                //GEtTabe
                table = sqlDatabaseAccess.getTableStructure(replica.StrSourceDatabase, replica.StrSourceTable);
            }
            if (replica.StrSourceEngine.Contains("MySQL"))
            {
                MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                table = sqlDatabaseAccess.getTableStructure(replica.StrSourceDatabase, replica.StrSourceTable);
            }
            //Terminal Config
            if (replica.StrTerminalEngine.Contains("SQL Server"))
            {
                SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrTerminalUser , replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                sqlDatabaseAccess.createTable(table);
            }
            if (replica.StrTerminalEngine.Contains("MySQL"))
            {
                MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                sqlDatabaseAccess.createTable(table);
                //MessageBox.Show(table.ToString());
            }
        }
        /// <summary>
        /// Test Conection in order to get the Complete DB list on the Engine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnSourceTest_Click(object sender, EventArgs e)
        {
            cbSourceDatabase.Items.Clear();
            cbSourceDatabase.Enabled = false;
            cbSourceDatabase.Text = "";
            //Connexion parameters
            string server = tbSourceIPAddress.Text;
            string user = tbSourceUser.Text;
            string password = tbSourcePassword.Text;
            string port = tbSourcePort.Text;
            List<Database> listDatabases = new List<Database>();

            if ((cbSourceEngine.SelectedItem as Engine).StrName.Contains("SQL Server")){

                SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user,password,server,port);
                listDatabases = sqlDatabaseDA.GetAllDatabases();
            }
            if ((cbSourceEngine.SelectedItem as Engine).StrName.Contains("MySQL"))
            {
                MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port);
                listDatabases = sqlDatabaseDA.GetAllDatabases();
            }

            if (listDatabases.Count <= 0)
            {
                MessageBox.Show("Unable to Connect Using those Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                foreach (Database db in listDatabases){
                    cbSourceDatabase.Items.Add(db.StrName);
                }
                cbSourceDatabase.SelectedIndex = 0; 
                cbSourceDatabase.Enabled = true;
            }
        }

        private void cbSourceDatabase_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Query the Engine DB for the Complete Table list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSourceDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbSourceTable.Items.Clear();
            cbSourceTable.Text = "";
            cbSourceTable.Enabled = false;
            //Connexion parameters
            string server = tbSourceIPAddress.Text;
            string user = tbSourceUser.Text;
            string password = tbSourcePassword.Text;
            string port = tbSourcePort.Text;
            string database = cbSourceDatabase.SelectedItem.ToString();
            List<Table> listTables = new List<Table>();

            if ((cbSourceEngine.SelectedItem as Engine).StrName.Contains("SQL Server"))
            {

                SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user, password, server, port, database);
                listTables = sqlDatabaseDA.GetAllTables(database);
            }
            if ((cbSourceEngine.SelectedItem as Engine).StrName.Contains("MySQL"))
            {

                MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port, database);
                listTables = sqlDatabaseDA.GetAllTables(database);
            }


            if (listTables.Count <= 0)
            {
                MessageBox.Show("Unable to Get the Tables for DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (Table tbl in listTables)
                {
                    cbSourceTable.Items.Add(tbl.StrName);
                }
                cbSourceTable.SelectedIndex = 0;
                cbSourceTable.Enabled = true;
            }
        }

        private void btnTerminalTest_Click(object sender, EventArgs e)
        {
            cbEndPointDatabase.Items.Clear();
            //Connexion parameters
            string server = tbEndPointIPAddress.Text;
            string user = tbEndPointUser.Text;
            string password = tbEndPointPassword.Text;
            string port = tbEndPointPort.Text;
            List<Database> listDatabases = new List<Database>();

            if ((cbEndPointEngine.SelectedItem as Engine).StrName.Contains("SQL Server"))
            {
                SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user, password, server, port);
                listDatabases = sqlDatabaseDA.GetAllDatabases();
            }
            if ((cbEndPointEngine.SelectedItem as Engine).StrName.Contains("MySQL"))
            {
                MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port);
                listDatabases = sqlDatabaseDA.GetAllDatabases();
            }
            if (listDatabases.Count <= 0)
            {
                MessageBox.Show("Unable to Connect Using those Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (Database db in listDatabases)
                {
                    cbEndPointDatabase.Items.Add(db.StrName);
                }
                cbEndPointDatabase.SelectedIndex = 0;
                cbEndPointDatabase.Enabled = true;
            }
        }

    }
}
