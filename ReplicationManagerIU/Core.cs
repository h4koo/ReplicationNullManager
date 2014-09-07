using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReplicationManagerDA.DataAccess;
using UtilitariosCD.Entities;

namespace ReplicationManagerIU
{
    public partial class Core : Form
    {
        List<Replica> replicas = new List<Replica>();
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

        }

        private void BtnCommitChanges_Click(object sender, EventArgs e)
        {
            AddEntry addEntry = new AddEntry();
            addEntry.Show();
        }
        /// <summary>
        /// Method that is going to update the ReplicaView List so the GridView will be updated.
        /// </summary>
        private void Reload_Replicas() {
            ReplicaDA replicaDA = new ReplicaDA();
            replicas = replicaDA.GetAllReplicas();
            List<ReplicaView> replicasView = new List<ReplicaView>();
            if (replicas.Count > 0)
            {
                foreach (Replica replica in replicas)
                {
                    replicasView.Add(new ReplicaView(replica));

                }
                //Adding Order to the Unorder List
                DGVReplicatorData.DataSource = replicasView;
                DGVReplicatorData.Columns["Enable"].DisplayIndex = 0;
                DGVReplicatorData.Columns["SourceEngine"].DisplayIndex = 1;
                DGVReplicatorData.Columns["SourceIPAddress"].DisplayIndex = 2;
                DGVReplicatorData.Columns["SourcePort"].DisplayIndex = 3;
                DGVReplicatorData.Columns["SourceUser"].DisplayIndex = 4;
                DGVReplicatorData.Columns["SourcePassword"].DisplayIndex = 5;
                DGVReplicatorData.Columns["SourceDatabase"].DisplayIndex = 6;
                DGVReplicatorData.Columns["SourceTable"].DisplayIndex = 7;

                DGVReplicatorData.Columns["TerminalEngine"].DisplayIndex = 8;
                DGVReplicatorData.Columns["TerminalIPAddress"].DisplayIndex = 9;
                DGVReplicatorData.Columns["TerminalPort"].DisplayIndex = 10;
                DGVReplicatorData.Columns["TerminalUser"].DisplayIndex = 11;
                DGVReplicatorData.Columns["TerminalPassword"].DisplayIndex = 12;
                DGVReplicatorData.Columns["TerminalDatabase"].DisplayIndex = 13;

                DGVReplicatorData.Columns["Created"].DisplayIndex = 14;
                DGVReplicatorData.Columns["LastCheckOnSource"].DisplayIndex = 15;
                DGVReplicatorData.Columns["LastCheckOnTerminal"].DisplayIndex = 16;
                btnDelete.Enabled = true;
                btnEnableDisable.Enabled = true;
            }
            else
            {
                MessageBox.Show("Replicas Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDelete.Enabled = false;
                btnEnableDisable.Enabled = false;
                DGVReplicatorData.DataSource = null;
            }
        }

        private void Core_Load(object sender, EventArgs e)
        {
            Reload_Replicas();
        }

        private void btnEnableDisable_Click(object sender, EventArgs e)
        {
            ReplicaDA replicaDA = new ReplicaDA();
            int selectedReplicaId = replicas[DGVReplicatorData.CurrentCell.RowIndex].IntIdReplica;
            if (!replicas[DGVReplicatorData.CurrentCell.RowIndex].BoolEnable)
            {
                replicaDA.Enable(selectedReplicaId);
            }
            else {
                replicaDA.Disable(selectedReplicaId);
            }
            Reload_Replicas();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload_Replicas();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int idReplica = replicas[DGVReplicatorData.CurrentCell.RowIndex].IntIdReplica;
            ReplicaDA replicaDA = new ReplicaDA();
            replicaDA.Delete( idReplica );
            Reload_Replicas();
        }

        private void Core_VisibleChanged(object sender, EventArgs e)
        {
            Reload_Replicas();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LogViewer logViewer = new LogViewer();
            logViewer.Show();
        
        }
    }
}
