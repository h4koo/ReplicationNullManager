using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    class mySql_Insert
    {

        private List<string> _columName;
        private List<string> _valores;
        private string _strNombreTabla;

        public mySql_Insert(string pNombreTabla)
        {
            _columName = new List<string>();
            _valores = new List<string>();
            _strNombreTabla = pNombreTabla;
        }

        /// <summary>
        /// Retorna el Querry para insertar en una base de datos mysql
        /// </summary>
        /// <returns></returns>
        public string generarQuerry()
        {

            string querry = "INSERT INTO " + _strNombreTabla + " (";
            string querryColumnas = "";
            string querryValores = "";

            for (int indice = 0; indice < _columName.Count; indice++)
            {

                if (indice < _columName.Count - 1)
                {
                    querryColumnas += "'" + _columName[indice] + "', ";
                    querryValores += "'" + _valores[indice] + "', ";
                }
                else
                {
                    querryColumnas += "'" + _columName[indice] + "'";
                    querryValores += "'" + _valores[indice] + "'";
                }
            }
            querry += querryColumnas + ")" + " values ( " + querryValores + ");";
            return querry;
        }

        #region GETTERS & SETTERS

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
            get { return _strNombreTabla; }
            set { _strNombreTabla = value; }
        }

        #endregion




    }
}
