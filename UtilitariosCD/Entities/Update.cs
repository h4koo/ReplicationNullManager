using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    class Update
    {

        private List<string> _columName;
        private List<string> _valores;
        private List<string> _Ids;
        private string _nombreTabla;
        private string _condicion;

        public Update(string pNombreTabla)
        {
            _columName = new List<string>();
            _valores = new List<string>();
            _Ids = new List<string>();
            _nombreTabla = pNombreTabla;
        }

        public string generarQuerry()
        {
            string querry = "UPDATE " + _nombreTabla + " SET ";
            string querryCambios = "";

            int cantColumnas = _columName.Count;
            int cantIds = _Ids.Count;

            for (int indice = 0; indice < cantColumnas; indice++)
            {
                if (indice < cantColumnas - 1)
                {
                    querryCambios += _columName[indice] + " = " + _valores[indice] + ", ";
                }
                else
                {
                    querryCambios += _columName[indice] + " = " + _valores[indice];
                }
            }

            querry += querryCambios + " WHERE " + _condicion;
            return querry;
        }


        #region GETTERS & SETTERS

        public List<string> Ids
        {
            get { return _Ids; }
            set { _Ids = value; }
        }

        public string Condicion
        {
            get { return _condicion; }
            set { _condicion = value; }
        }

        public List<string> ColumName
        {
            get { return _columName; }
            set { _columName = value; }
        }

        public List<string> Value
        {
            get { return _valores; }
            set { _valores = value; }
        }

        public string NombreTabla
        {
            get { return _nombreTabla; }
            set { _nombreTabla = value; }
        }

        #endregion


    }
}
