using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Cliente : Usuario
    {
        private int _intIdCliente;
        private int _intIdRuta;        
        private int _intTipoRol;
        private string _strNumCuenta;
        private int _intCantPuntos;       
        

        /*
         * Constructor 
         */
        public Cliente()
        {
            //Usuario
            IntIdUsuario = -1; //Se debería usar IntIdCliente
            StrNickname = string.Empty;
            StrClave = string.Empty;
            StrCedula = string.Empty;
            StrNombre = string.Empty;
            StrApellidos = string.Empty;
            StrEmail = string.Empty;
            StrTelefono = string.Empty;
            StrCelular = string.Empty;
            //Cliente
            IntIdCliente = -1;
            IntIdRuta = -1;            
            IntTipoRol = -1;            
            StrNumCuenta = string.Empty;
            IntCantPuntos = 0;
        }



        #region SETTERS y GETTERS

        public int IntIdCliente
        {
            get { return _intIdCliente; }
            set { _intIdCliente = value; }
        }

        public int IntIdRuta
        {
            get { return _intIdRuta; }
            set { _intIdRuta = value; }
        }
      
        public int IntTipoRol
        {
            get { return _intTipoRol; }
            set { _intTipoRol = value; }
        }

        public string StrNumCuenta
        {
            get { return _strNumCuenta; }
            set { _strNumCuenta = value; }
        }

        public int IntCantPuntos
        {
            get { return _intCantPuntos; }
            set { _intCantPuntos = value; }
        }

        #endregion



    }
}
