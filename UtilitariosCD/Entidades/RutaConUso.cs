using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class RutaConUso : Ruta
    {
        private int _intUso;
        
         /*
         * Constructor 
         */
        public RutaConUso()
        {
            IntIdRuta = -1;
            StrNombre = string.Empty;
            IntLugarSalida = -1;
            IntLugarLlegada = -1;
            IntDuracionDias = 0;
            IntCantMaxContenedores = 0;
            DblCosto = 0.0;
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
