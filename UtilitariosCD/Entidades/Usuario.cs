using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Usuario
    {

        private int _intIdUsuario;        
        private string _strNickname;
        private string _strClave;
        private string _strCedula;            
        private string _strNombre;
        private string _strApellidos;
        private string _strEmail;
        private string _strTelefono;
        private string _strCelular;


        /*
         * Constructor 
         */
        public Usuario()
        {
            IntIdUsuario = -1;
            StrNickname = string.Empty;
            StrClave = string.Empty;
            StrCedula = string.Empty;
            StrNombre = string.Empty;
            StrApellidos = string.Empty;
            StrEmail = string.Empty;
            StrTelefono = string.Empty;
            StrCelular = string.Empty;
        }


        #region SETTERS y GETTERS

        public int IntIdUsuario
        {
            get { return _intIdUsuario; }
            set { _intIdUsuario = value; }
        }

        public string StrNickname
        {
            get { return _strNickname; }
            set { _strNickname = value; }
        }

        public string StrClave
        {
            get { return _strClave; }
            set { _strClave = value; }
        }

        public string StrCedula
        {
            get { return _strCedula; }
            set { _strCedula = value; }
        }    

        public string StrNombre
        {
            get { return _strNombre; }
            set { _strNombre = value; }
        }

        public string StrApellidos
        {
            get { return _strApellidos; }
            set { _strApellidos = value; }
        }

        public string StrEmail
        {
            get { return _strEmail; }
            set { _strEmail = value; }
        }

        public string StrTelefono
        {
            get { return _strTelefono; }
            set { _strTelefono = value; }
        }

        public string StrCelular
        {
            get { return _strCelular; }
            set { _strCelular = value; }
        }

        #endregion


    }
}
