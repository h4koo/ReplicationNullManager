using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class ParametroGeneral
    {

        private int _intIdParGeneral;
        private string _strNombre;
        private string _strDescripcion;
        private string _strValor;
        
       /*
        * Constructor 
        */
        public ParametroGeneral()
        {
            IntIdParGeneral = -1;
            StrNombre = string.Empty;
            StrDescripcion = string.Empty;
            StrValor = string.Empty;
        }


        #region SETTERS y GETTERS


        public int IntIdParGeneral
        {
            get { return _intIdParGeneral; }
            set { _intIdParGeneral = value; }
        }

        public string StrNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        public string StrDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        public string StrValor
        {
            get { return _strValor; }
            set { _strValor = value; }
        }

        #endregion



    }
}
