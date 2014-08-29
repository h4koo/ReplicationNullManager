using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Ruta
    {

        private int _intIdRuta;        
        private string _strNombre;
        private int _intLugarSalida;
        private int _intLugarLlegada;
        private int _intDuracionDias;
        private int _intCantMaxContenedores;
        private double _dblCosto;

       
        /*
         * Constructor 
         */
        public Ruta()
        {
            IntIdRuta = -1;
            StrNombre = string.Empty;
            IntLugarSalida = -1;
            IntLugarLlegada = -1;
            IntDuracionDias = 0;
            IntCantMaxContenedores = 0;
            DblCosto = 0.0;
        }


        #region SETTERS y GETTERS

        public int IntIdRuta
        {
            get { return _intIdRuta; }
            set { _intIdRuta = value; }
        }

        public string StrNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        public int IntLugarSalida
        {
            get { return _intLugarSalida; }
            set { _intLugarSalida = value; }
        }

        public int IntLugarLlegada
        {
            get { return _intLugarLlegada; }
            set { _intLugarLlegada = value; }
        }

        public int IntDuracionDias
        {
            get { return _intDuracionDias; }
            set { _intDuracionDias = value; }
        }

        public int IntCantMaxContenedores
        {
            get { return _intCantMaxContenedores; }
            set { _intCantMaxContenedores = value; }
        }

        public double DblCosto
        {
            get { return _dblCosto; }
            set { _dblCosto = value; }
        }


        #endregion

    }
}
