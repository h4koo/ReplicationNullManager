using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Promedio
    {
        private Double _dblValor;        
        
        /*
         * Constructor 
         */
        public Promedio()
        {
            DblValor = 0.0;
        }


        #region SETTERS y GETTERS

        public Double DblValor
        {
            get { return _dblValor; }
            set { _dblValor = value; }
        }
        #endregion
    }
}
