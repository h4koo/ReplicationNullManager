using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    public class ReplicaLog
    {

        private int _intIdReplicaLog;        
        private string _strReplicaTable;
        private DateTime _dtReplicaDatetime;
        private string _strReplicaTransaction;
        private bool _blnIsSynchronized;


        /*
         * Constructor 
         */
        public ReplicaLog()
        {
            IntIdReplicaLog = -1;
            StrReplicaTable = string.Empty;
            DtReplicaDatetime = new DateTime();
            StrReplicaTransaction = string.Empty;
            BlnIsSynchronized = false;
        }


        #region SETTER & GETTERS

        public int IntIdReplicaLog
        {
            get { return _intIdReplicaLog; }
            set { _intIdReplicaLog = value; }
        }


        public string StrReplicaTable
        {
            get { return _strReplicaTable; }
            set { _strReplicaTable = value; }
        }


        public DateTime DtReplicaDatetime
        {
            get { return _dtReplicaDatetime; }
            set { _dtReplicaDatetime = value; }
        }


        public string StrReplicaTransaction
        {
            get { return _strReplicaTransaction; }
            set { _strReplicaTransaction = value; }
        }


        public bool BlnIsSynchronized
        {
            get { return _blnIsSynchronized; }
            set { _blnIsSynchronized = value; }
        }

        #endregion

    }
}
