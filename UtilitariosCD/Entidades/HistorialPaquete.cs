using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class HistorialPaquete
    {

        private int _intIdHistorialPaquete;       
        private string _strDescripcionEstado;
        private int _intIdPaquete;        
        private DateTime _datetimeFecha;
        private int _intEstado;
        private int _intDia;
        
        /*
         * Constructor
         */
        public HistorialPaquete()
        {
            IntIdHistorialPaquete = -1;
            StrDescripcionEstado = string.Empty;
            IntIdPaquete = -1;
            DtiFecha = DateTime.Now;
            IntEstado = -1;
            IntDia = 0;
        }


        #region SETTERS y GETTERS

        public int IntIdHistorialPaquete
        {
            get { return _intIdHistorialPaquete; }
            set { _intIdHistorialPaquete = value; }
        }

        public string StrDescripcionEstado
        {
            get { return _strDescripcionEstado; }
            set { _strDescripcionEstado = value; }
        }

        public int IntIdPaquete
        {
            get { return _intIdPaquete; }
            set { _intIdPaquete = value; }
        }

        public int IntDia
        {
            get { return _intDia; }
            set { _intDia = value; }
        }

        public int IntEstado
        {
            get { return _intEstado; }
            set { _intEstado = value; }
        }

        public DateTime DtiFecha
        {
            get { return _datetimeFecha; }
            set { _datetimeFecha = value; }
        }

        #endregion


    }
}
