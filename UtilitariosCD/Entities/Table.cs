using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    public class Table
    {
        private string _strName;
        private List<Column> _listColumns;

        public Table()
        {
            StrName = string.Empty;
            ListColumns = new List<Column>();
        }


        #region SETTERS y GETTERS

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public List<Column> ListColumns
        {
            get { return _listColumns; }
            set { _listColumns = value; }
        }


        #endregion

        public override string ToString() {
            string strQuerry = "CREATE TABLE " + this.StrName.ToUpper() + " (";

            int counterColumns = this.ListColumns.Count();

            foreach (Column Ocolumn in this.ListColumns)
            {
                strQuerry += Ocolumn.StrName.ToUpper() + " " + Ocolumn.StrType;

                if (Ocolumn.BoolNull)
                {
                    strQuerry += " NOT NULL ";
                }

                //Delimiter , for more than 1 colum
                counterColumns--;
                if (counterColumns > 0)
                {
                    strQuerry += ", ";
                }

            }

            //strQuerry += "primary key(" + pColumnas[0] + ")
            strQuerry += ");";
            return strQuerry;
    


        }
    }
}
