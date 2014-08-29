using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class ContenedorConUso : Contenedor
    {        
        private int _intUso;
        
         /*
         * Constructor 
         */
        public ContenedorConUso()
        {
            IntIdContenedor = -1;
            IntNumSerie = -1;
            IntTipoEnvio = -1;
            DblPesoMaximo = 0.0;
            IntUso = 0;
        }

        #region SETTERS y GETTERS

        public int IntUso
        {
            get { return _intUso; }
            set { _intUso = value; }
        }

        #endregion

    }
}
