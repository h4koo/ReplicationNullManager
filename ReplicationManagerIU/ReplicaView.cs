using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Entities;

namespace ReplicationManagerIU
{
    /// <summary>
    /// Created in order to Encapsulate Replica Attributtes to the End User, on UI
    /// </summary>
    class ReplicaView{
        //private int _IdReplica;
        //private int _IdSourceEngine;
        private string _SourceEngine;
        private string _SourceIPAddress;
        private int _SourcePort;
        private string _SourceUser;
        private string _SourcePassword;
        private string _SourceDatabase;
        private string _SourceTable;
        //private int _IdTerminalEngine;
        private string _TerminalEngine;
        private string _TerminalIPAddress;
        private int _TerminalPort;
        private string _TerminalUser;
        private string _TerminalPassword;
        private string _TerminalDatabase;
        private Boolean _Enable;
        private string _Created;
        private string _LastCheckOnSource;
        private string _LastCheckOnTerminal;
  
        public ReplicaView(){
        
            //IdReplica = -1;
            //IdSourceEngine = -1;
            SourceEngine = string.Empty;
            SourceIPAddress = string.Empty;
            SourcePort = -1;
            SourceUser = string.Empty;
            SourcePassword = string.Empty;
            SourceDatabase = string.Empty;
            SourceTable = string.Empty;
            //IdTerminalEngine = -1;
            TerminalEngine = string.Empty;
            TerminalIPAddress = string.Empty;
            TerminalPort = -1;
            TerminalUser = string.Empty;
            TerminalPassword = string.Empty;
            TerminalDatabase = string.Empty;
            Enable = false;
            Created = string.Empty;
            LastCheckOnSource = string.Empty;
            LastCheckOnTerminal = string.Empty;
        }
        
        public ReplicaView(Replica replica){
            //IdReplica = replica.IntIdReplica;
            //IdSourceEngine = replica.IntIdSourceEngine;
            SourceEngine = replica.StrSourceEngine;
            SourceIPAddress = replica.StrSourceIPAddress;
            SourcePort = replica.IntSourcePort;
            SourceUser = replica.StrSourceUser;
            SourcePassword = replica.StrSourcePassword;
            SourceDatabase = replica.StrSourceDatabase;
            SourceTable = replica.StrSourceTable;
            //IdTerminalEngine = replica.IntIdTerminalEngine;
            TerminalEngine = replica.StrTerminalEngine;
            TerminalIPAddress = replica.StrTerminalIPAddress;
            TerminalPort = replica.IntTerminalPort;
            TerminalUser = replica.StrTerminalUser;
            TerminalPassword = replica.StrTerminalPassword;
            TerminalDatabase = replica.StrTerminalDatabase;
            Enable = replica.BoolEnable;
            Created =replica.StrCreated;
            LastCheckOnSource = replica.StrLastCheckOnSource;
            LastCheckOnTerminal = replica.StrLastCheckOnTerminal;            
        }
        #region SETTERS y GETTERS

        //public int IdReplica
        //{
        //    get { return _IdReplica; }
        //    set { _IdReplica = value; }
        //}

        public int SourcePort
        {
            get {return _SourcePort; }
            set { _SourcePort = value; }
        }

        //public int IdSourceEngine
       // {
       //     get { return _IdSourceEngine; }
       //     set { _IdSourceEngine = value; }
       // }
        
       // public int IdTerminalEngine
       // {
       //     get { return _IdTerminalEngine; }
       //     set { _IdTerminalEngine = value; }
       // }
        public int TerminalPort
        {
            get { return _TerminalPort; }
            set { _TerminalPort = value; }
        }

        public string SourceEngine
        {
            get { return _SourceEngine; }
            set { _SourceEngine = value; }
        }

        public string SourceIPAddress
        {
            get { return _SourceIPAddress; }
            set { _SourceIPAddress = value; }
        }

        public string SourceUser
        {
            get { return _SourceUser; }
            set { _SourceUser = value; }
        }

        public string SourcePassword
        {
            get { return _SourcePassword; }
            set { _SourcePassword = value; }
        }

        public string SourceDatabase
        {
            get { return _SourceDatabase; }
            set { _SourceDatabase = value; }
        }

        public string SourceTable
        {
            get { return _SourceTable; }
            set { _SourceTable = value; }
        }

        public string TerminalEngine
        {
            get { return _TerminalEngine; }
            set { _TerminalEngine = value; }
        }

        public string TerminalIPAddress
        {
            get { return _TerminalIPAddress; }
            set { _TerminalIPAddress = value; }
        }

        public string TerminalUser
        {
            get { return _TerminalUser; }
            set { _TerminalUser = value; }
        }

        public string TerminalPassword
        {
            get { return _TerminalPassword; }
            set { _TerminalPassword = value; }
        }
         
        public string TerminalDatabase
        {
            get { return _TerminalDatabase; }
            set { _TerminalDatabase = value; }
        }

       
        public string Created
        {
            get { return _Created; }
            set { _Created = value; }
        }

        public string LastCheckOnSource
        {
            get { return _LastCheckOnSource; }
            set { _LastCheckOnSource = value; }
        }

        public string LastCheckOnTerminal
        {
            get { return _LastCheckOnTerminal; }
            set { _LastCheckOnTerminal = value; }
        }

        public Boolean Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }

    #endregion
    }    
}

