using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Rol
    {

        private int _intIdRol;        
        private string _strDescripcion;        


        /*
         * Constructor 
         */
        public Rol()
        {
            IntIdRol = -1;
            StrDescripcion = string.Empty;
        }


        #region SETTERS y GETTERS

        public int IntIdRol
        {
            get { return _intIdRol; }
            set { _intIdRol = value; }
        }

        public string StrDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        #endregion

       
        
    }
}
