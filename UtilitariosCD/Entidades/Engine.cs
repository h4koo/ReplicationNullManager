using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Engine
    {

        private int _intIdEngine;
        private string _strName;
      
        /*
         * Constructor 
         */
        public Engine()
        {
            IntIdEngine = -1;
            _strName = string.Empty;
        }

        #region SETTERS y GETTERS

        public int IntIdEngine
        {
            get { return _intIdEngine; }
            set { _intIdEngine = value; }
        }

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }

        #endregion

        public override string ToString()
        {
            return _strName;
        }
    }
}
