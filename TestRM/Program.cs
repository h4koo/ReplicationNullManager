using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplicationManagerDA.DataAccess;
using UtilitariosCD.Entities;

namespace TestRM
{
    class Program
    {
        static void Main(string[] args)
        {

            SqlDatabaseDA prueba = new SqlDatabaseDA("", "", "", "");


            Table tabla = new Table();            

            tabla.StrName = "MiTabla";

            Column column = new Column();
            column.StrName = "Prueba";
            tabla.ListColumns.Add(column);

            column = new Column();
            column.StrName = "Prueba2";
            tabla.ListColumns.Add(column);

            column = new Column();
            column.StrName = "Prueba3";
            tabla.ListColumns.Add(column);

            column = new Column();
            column.StrName = "Prueba4";
            tabla.ListColumns.Add(column);

            prueba.CreateTrigger(tabla);


        }
    }
}
