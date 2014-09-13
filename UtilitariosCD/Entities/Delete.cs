using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    class Delete
    {

        private string _strTableName;
        private string _strCondition;

        public Delete()
        {
           strCondition = string.Empty();
           strTableName = string.Empty();
        }

        public override string ToString()
        {
            return "DELETE FROM " + this.strTableName + " WHERE " + this.strCondition;
        }

        #region GETTERS & SETTERS

        public string strTableName
        {
            get { return _strTableName; }
            set { _strTableName = value; }
        }

        public string strCondition
        {
            set { _strCondition = value; }
            get { return _strCondition; }
        }

        #endregion

    }
}
