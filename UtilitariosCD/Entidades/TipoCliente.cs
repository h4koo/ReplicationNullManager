using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class TipoRol
    {

        private int _intIdTipoRol;
        private string _strDescripcion;
        private double _dblPorcentajeDesc;        
        

        /*
         * Constructor 
         */
        public TipoRol()
        {
            IntIdTipoRol = -1;
            StrDescripcion = string.Empty;
            DblPorcentajeDesc = 0.0;
        }


        #region SETTERS y GETTERS

        public int IntIdTipoRol
        {
            get { return _intIdTipoRol; }
            set { _intIdTipoRol = value; }
        }

        public string StrDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        public double DblPorcentajeDesc
        {
            get { return _dblPorcentajeDesc; }
            set { _dblPorcentajeDesc = value; }
        }

        #endregion


    }
}
