using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entidades
{
    public class Factura
    {
        private int _intIdFactura;        
        private int _intIdCliente;
        private int _intIdPaquete;
        private int _intIdRuta;
        private int _intIdContenedor;
        private string _strFechaCancelacion;
        private string _strConceptoPago;
        private double _dblCostoFlete;
        private double _dblImpImportacion;
        private double _dblCostoAlmacenaje;        
        private double _dblDescuento;
        private double _dblMontoTotal;
        private string _strDescripcionDesc;        
       

        /*
         * Constructor 
         */
        public Factura()
        {
            IntIdCliente = -1;
            IntIdPaquete = -1;
            IntIdRuta = -1;
            IntIdContenedor = -1;
            StrFechaCancelacion = string.Empty;
            StrConceptoPago = string.Empty;
            DblCostoFlete = 0.0;
            DblImpImportacion = 0.0;
            DblCostoAlmacenaje = 0.0;
            DblDescuento = 0.0;
            DblMontoTotal = 0.0;
            StrDescripcionDesc = string.Empty;
        }       


        #region SETTERS y GETTERS

        public int IntIdFactura
        {
            get { return _intIdFactura; }
            set { _intIdFactura = value; }
        }

        public int IntIdCliente
        {
            get { return _intIdCliente; }
            set { _intIdCliente = value; }
        }

        public int IntIdPaquete
        {
            get { return _intIdPaquete; }
            set { _intIdPaquete = value; }
        }

        public int IntIdRuta
        {
            get { return _intIdRuta; }
            set { _intIdRuta = value; }
        }

        public int IntIdContenedor
        {
            get { return _intIdContenedor; }
            set { _intIdContenedor = value; }
        }

        public string StrFechaCancelacion
        {
            get { return _strFechaCancelacion; }
            set { _strFechaCancelacion = value; }
        }

        public string StrConceptoPago
        {
            get { return _strConceptoPago; }
            set { _strConceptoPago = value; }
        }

        public double DblCostoFlete
        {
            get { return _dblCostoFlete; }
            set { _dblCostoFlete = value; }
        }

        public double DblImpImportacion
        {
            get { return _dblImpImportacion; }
            set { _dblImpImportacion = value; }
        }

        public double DblCostoAlmacenaje
        {
            get { return _dblCostoAlmacenaje; }
            set { _dblCostoAlmacenaje = value; }
        }

        public double DblDescuento
        {
            get { return _dblDescuento; }
            set { _dblDescuento = value; }
        }

        public double DblMontoTotal
        {
            get { return _dblMontoTotal; }
            set { _dblMontoTotal = value; }
        }

        public string StrDescripcionDesc
        {
            get { return _strDescripcionDesc; }
            set { _strDescripcionDesc = value; }
        }

        #endregion

    }
}
