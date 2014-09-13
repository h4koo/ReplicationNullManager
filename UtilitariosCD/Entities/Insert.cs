using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    public class Insert
    {

        private List<string> _listColumnNames;
        private List<string> _listValues;
        private string _strTableName;

        public Insert()
        {
            listColumnNames = new List<string>();
            listValues = new List<string>();
            strTableName = string.Empty;
        }

        /// <summary>
        /// Retorna el Querry para insertar en una base de datos mysql
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            string querry = "INSERT INTO " + this.strTableName.ToUpper() + " (";
            string querryColumnas = "";
            string querryValores = "";

            for (int indice = 0; indice < this.listColumnNames.Count; indice++)
            {


                if (indice < this.listColumnNames.Count - 1)
                {
                    querryColumnas += "" + this.listColumnNames[indice] + ", ";
                    querryValores += "'" + this.listValues[indice] + "', ";
                }
                else
                {
                    querryColumnas += "" + this.listColumnNames[indice] + "";
                    querryValores += "'" + this.listValues[indice] + "'";
                }
            }
            querry += querryColumnas + ")" + " values ( " + querryValores + ");";
            return querry;
        }

        #region GETTERS & SETTERS

        public List<string> listColumnNames
        {
            get { return _listColumnNames; }
            set { _listColumnNames = value; }
        }

        public List<string> listValues
        {
            get { return _listValues; }
            set { _listValues = value; }
        }

        public string strTableName
        {
            get { return _strTableName; }
            set { _strTableName = value; }
        }

        #endregion


       

    }
}
