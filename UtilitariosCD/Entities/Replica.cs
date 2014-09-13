using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    public class Replica
    {
        private int _intIdReplica;
        private int _intIdSourceEngine;
        private string _strSourceEngine;
        private string _strSourceIPAddress;
        private int _intSourcePort;
        private string _strSourceUser;
        private string _strSourcePassword;
        private string _strSourceDatabase;
        private string _strSourceTable;
        private int _intIdTerminalEngine;
        private string _strTerminalEngine;
        private string _strTerminalIPAddress;
        private int _intTerminalPort;
        private string _strTerminalUser;
        private string _strTerminalPassword;
        private string _strTerminalDatabase;
        private Boolean _boolEnable;
        private string _strCreated;
        private string _strLastCheckOnSource;
        private string _strLastCheckOnTerminal;
  
        public Replica(){
        
            IntIdReplica = -1;
            IntIdSourceEngine = -1;
            StrSourceEngine = string.Empty;
            StrSourceIPAddress = string.Empty;
            IntSourcePort = -1;
            StrSourceUser = string.Empty;
            StrSourcePassword = string.Empty;
            StrSourceDatabase = string.Empty;
            StrSourceTable = string.Empty;
            IntIdTerminalEngine = -1;
            StrTerminalEngine = string.Empty;
            StrTerminalIPAddress = string.Empty;
            IntTerminalPort = -1;
            StrTerminalUser = string.Empty;
            StrTerminalPassword = string.Empty;
            StrTerminalDatabase = string.Empty;
            BoolEnable = false;
            StrCreated = string.Empty;
            StrLastCheckOnSource = string.Empty;
            StrLastCheckOnTerminal = string.Empty;
        }
        
        #region SETTERS y GETTERS

        public int IntIdReplica
        {
            get { return _intIdReplica; }
            set { _intIdReplica = value; }
        }

        public int IntSourcePort
        {
            get {return _intSourcePort; }
            set { _intSourcePort = value; }
        }

        public int IntIdSourceEngine
        {
            get { return _intIdSourceEngine; }
            set { _intIdSourceEngine = value; }
        }
        
        public int IntIdTerminalEngine
        {
            get { return _intIdTerminalEngine; }
            set { _intIdTerminalEngine = value; }
        }
        public int IntTerminalPort
        {
            get { return _intTerminalPort; }
            set { _intTerminalPort = value; }
        }

        public string StrSourceEngine
        {
            get { return _strSourceEngine; }
            set { _strSourceEngine = value; }
        }

        public string StrSourceIPAddress
        {
            get { return _strSourceIPAddress; }
            set { _strSourceIPAddress = value; }
        }

        public string StrSourceUser
        {
            get { return _strSourceUser; }
            set { _strSourceUser = value; }
        }

        public string StrSourcePassword
        {
            get { return _strSourcePassword; }
            set { _strSourcePassword = value; }
        }

        public string StrSourceDatabase
        {
            get { return _strSourceDatabase; }
            set { _strSourceDatabase = value; }
        }

        public string StrSourceTable
        {
            get { return _strSourceTable; }
            set { _strSourceTable = value; }
        }

        public string StrTerminalEngine
        {
            get { return _strTerminalEngine; }
            set { _strTerminalEngine = value; }
        }

        public string StrTerminalIPAddress
        {
            get { return _strTerminalIPAddress; }
            set { _strTerminalIPAddress = value; }
        }

        public string StrTerminalUser
        {
            get { return _strTerminalUser; }
            set { _strTerminalUser = value; }
        }

        public string StrTerminalPassword
        {
            get { return _strTerminalPassword; }
            set { _strTerminalPassword = value; }
        }
         
        public string StrTerminalDatabase
        {
            get { return _strTerminalDatabase; }
            set { _strTerminalDatabase = value; }
        }

       
        public string StrCreated
        {
            get { return _strCreated; }
            set { _strCreated = value; }
        }

        public string StrLastCheckOnSource
        {
            get { return _strLastCheckOnSource; }
            set { _strLastCheckOnSource = value; }
        }

        public string StrLastCheckOnTerminal
        {
            get { return _strLastCheckOnTerminal; }
            set { _strLastCheckOnTerminal = value; }
        }

        public Boolean BoolEnable
        {
            get { return _boolEnable; }
            set { _boolEnable = value; }
        }

    #endregion



    }    
}

