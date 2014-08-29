using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Paquete
    {

        private int _intIdPaquete;       
        private string _strDescripcion;
        private int _intIdCliente;        
        private int _intTipoEnvio;
        private int _intEstado;
        private double _dblTamanio;
        private double _dblPeso;
        private int _intDiasAlmacenaje;
        

        /*
         * Constructor
         */
        public Paquete()
        {
            IntIdPaquete = -1;
            StrDescripcion = string.Empty;
            IntIdCliente = -1;
            IntTipoEnvio = -1;
            IntEstado = -1;
            DblTamanio = 0.0;
            DblPeso = 0.0;
            IntDiasAlmacenaje = 0;
        }


        #region SETTERS y GETTERS

        public int IntIdPaquete
        {
            get { return _intIdPaquete; }
            set { _intIdPaquete = value; }
        }

        public string StrDescripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }

        public int IntIdCliente
        {
            get { return _intIdCliente; }
            set { _intIdCliente = value; }
        }

        public int IntTipoEnvio
        {
            get { return _intTipoEnvio; }
            set { _intTipoEnvio = value; }
        }

        public int IntEstado
        {
            get { return _intEstado; }
            set { _intEstado = value; }
        }

        public double DblTamanio
        {
            get { return _dblTamanio; }
            set { _dblTamanio = value; }
        }

        public double DblPeso
        {
            get { return _dblPeso; }
            set { _dblPeso = value; }
        }

        public int IntDiasAlmacenaje
        {
            get { return _intDiasAlmacenaje; }
            set { _intDiasAlmacenaje = value; }
        }
       
        #endregion


    }
}
