using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    public class Column
    {
        private string _strName;
        private string _strType;
        private Boolean _boolNull;

        private List<Column> _listColumns;

        public Column()
        {
            StrName = string.Empty;
            StrType = string.Empty;
            BoolNull = false;

        }


        #region SETTERS y GETTERS

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }

        public string StrType
        {
            get { return _strType; }
            set { _strType = value; }
        }

        public bool BoolNull
        {
            get { return _boolNull; }
            set { _boolNull = value; }
        }
        
        #endregion
    }
}
