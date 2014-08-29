using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Contenedor
    {
        private int _intIdContenedor;        
        private int _intNumSerie;
        private int _intTipoEnvio;
        private double _dblPesoMaximo;
        private int _intIdRuta;

        /*
         * Constructor 
         */
        public Contenedor()
        {
            IntIdContenedor = -1;
            IntNumSerie = -1;
            IntTipoEnvio = -1;
            DblPesoMaximo = 0.0;   
        }


        #region SETTERS y GETTERS

        public int IntIdContenedor
        {
            get { return _intIdContenedor; }
            set { _intIdContenedor = value; }
        }

        public int IntNumSerie
        {
            get { return _intNumSerie; }
            set { _intNumSerie = value; }
        }

        public int IntTipoEnvio
        {
            get { return _intTipoEnvio; }
            set { _intTipoEnvio = value; }
        }

        public double DblPesoMaximo
        {
            get { return _dblPesoMaximo; }
            set { _dblPesoMaximo = value; }
        }

        #endregion



    }
}
