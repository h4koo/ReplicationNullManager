﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosCD.Entities
{
    public class Table
    {
        private string _strName;

        public Table()
        {
            StrName = string.Empty;
        }

        #region SETTERS y GETTERS

        public string StrName
        {
            get { return _strName; }
            set { _strName = value; }
        }
        #endregion

    }
}
