using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Lugar
    {

        private int _intIdLugar;
        private string _strNombre;
        private double _dblCostoAlmacenaje;
        private bool _blnEsSalida;
        

        /*
         * Constructor 
         */
        public Lugar()
        {
            IntIdLugar = -1;
            StrNombre = string.Empty;
            DblCostoAlmacenaje = 0.0;
            BlnEsSalida = false;
        }


        #region SETTERS y GETTERS

        public int IntIdLugar
        {
            get { return _intIdLugar; }
            set { _intIdLugar = value; }
        }

        public string StrNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        public double DblCostoAlmacenaje
        {
            get { return _dblCostoAlmacenaje; }
            set { _dblCostoAlmacenaje = value; }
        }

        public bool BlnEsSalida
        {
            get { return _blnEsSalida; }
            set { _blnEsSalida = value; }
        }

        #endregion



    }
}
