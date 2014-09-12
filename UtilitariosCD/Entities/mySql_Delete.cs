using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    class mySql_Delete
    {


        private string _nombreTabla;
        private string _condicion;

        public mySql_Delete(string pNombreTabla)
        {
            _nombreTabla = pNombreTabla;
        }


        public string generarQuerry()
        {
            return "DELETE FROM " + _nombreTabla + " WHERE " + _condicion;
        }

        #region GETTERS & SETTERS

        public string NombreTabla
        {
            get { return _nombreTabla; }
            set { _nombreTabla = value; }
        }

        public string Condicion
        {
            set { _condicion = value; }
            get { return _condicion; }
        }

        #endregion

    }
}
