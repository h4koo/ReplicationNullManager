using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class TipoEnvio
    {

         private int _intIdTipoEnvio;        
         private string _strDescripcion;


        /*
         * Constructor 
         */
        public TipoEnvio()
        {
            IntIdTipoEnvio = -1;
            StrDescripcion = string.Empty;
        }


        #region SETTERS y GETTERS

        public int IntIdTipoEnvio
        {
            get { return _intIdTipoEnvio; }
            set { _intIdTipoEnvio = value; }
        }

        public string StrDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        #endregion

        
    }
}
