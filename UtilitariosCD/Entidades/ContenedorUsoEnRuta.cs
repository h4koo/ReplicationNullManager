using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class ContenedorUsoEnRuta : ContenedorConUso
    {
        private string _strNombreRuta;

        /*
        * Constructor 
        */
        public ContenedorUsoEnRuta(){
            IntIdContenedor = -1;
            IntNumSerie = -1;
            IntTipoEnvio = -1;
            DblPesoMaximo = 0.0;
            IntUso = 0;
            StrNombreRuta = "";
        }


        #region SETTERS y GETTERS

        public string StrNombreRuta
        {
            get { return _strNombreRuta; }
            set { _strNombreRuta = value; }
        }

        #endregion


    }


}
