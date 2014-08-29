using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.ClasesTipadas
{
    public class ParamConsultaCT
    {
        private int _intIdUsuario;
        private int _intIdRol;
        private int _intIdParGeneral;
        private int _intIdCliente;
        private int _intIdTipoRol;
        private int _intIdPaquete;
        private int _intIdEstado;
        private int _intIdContenedor;
        private int _intIdTipoEnvio;
        private int _intIdRuta;
        private int _intIdLugar;
        private int _intIdFactura;        

        
        /*
         * Constructor 
         */
        public ParamConsultaCT()
        {
            IntIdUsuario = -1;
            IntIdRol = -1;
            IntIdParGeneral = -1;
            IntIdCliente = -1;
            IntIdTipoRol = -1;
            IntIdPaquete = -1;
            IntIdEstados = -1;
            IntIdContenedor = -1;
            IntIdTipoEnvio = -1;
            IntIdRuta = -1;
            IntIdLugar = -1;
            IntIdFactura = -1;            
        }


        #region SETTERS y GETTERS

        public int IntIdUsuario
        {
            get { return _intIdUsuario; }
            set { _intIdUsuario = value; }
        }


        public int IntIdRol
        {
            get { return _intIdRol; }
            set { _intIdRol = value; }
        }


        public int IntIdParGeneral
        {
            get { return _intIdParGeneral; }
            set { _intIdParGeneral = value; }
        }


        public int IntIdCliente
        {
            get { return _intIdCliente; }
            set { _intIdCliente = value; }
        }


        public int IntIdTipoRol
        {
            get { return _intIdTipoRol; }
            set { _intIdTipoRol = value; }
        }


        public int IntIdPaquete
        {
            get { return _intIdPaquete; }
            set { _intIdPaquete = value; }
        }


        public int IntIdEstados
        {
            get { return _intIdEstado; }
            set { _intIdEstado = value; }
        }


        public int IntIdContenedor
        {
            get { return _intIdContenedor; }
            set { _intIdContenedor = value; }
        }


        public int IntIdTipoEnvio
        {
            get { return _intIdTipoEnvio; }
            set { _intIdTipoEnvio = value; }
        }


        public int IntIdRuta
        {
            get { return _intIdRuta; }
            set { _intIdRuta = value; }
        }


        public int IntIdLugar
        {
            get { return _intIdLugar; }
            set { _intIdLugar = value; }
        }


        public int IntIdFactura
        {
            get { return _intIdFactura; }
            set { _intIdFactura = value; }
        }

        #endregion


    }
}
