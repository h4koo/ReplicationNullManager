using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Estado
    {
        private int _intIdEstado;        
        private string _strDescripcion;


        /*
         * Constructor 
         */
        public Estado()
        {
            IntIdEstado = -1;
            StrDescripcion = string.Empty;
        }


        #region SETTERS y GETTERS

        public int IntIdEstado
        {
            get { return _intIdEstado; }
            set { _intIdEstado = value; }
        }

        public string StrDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        #endregion
        


    }
}
