using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplicationManagerDA.DataAccess;
using UtilitariosCD.Entities;

using System.Reflection;
using MySql.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace TestRM
{
    class Program
    {
        static void Main(string[] args)
        {

            //SqlDatabaseDA prueba = new SqlDatabaseDA("", "", "", "");


            //Table tabla = new Table();            

            //tabla.StrName = "MiTabla";

            //Column column = new Column();
            //column.StrName = "Prueba";
            //tabla.ListColumns.Add(column);

            //column = new Column();
            //column.StrName = "Prueba2";
            //tabla.ListColumns.Add(column);

            //column = new Column();
            //column.StrName = "Prueba3";
            //tabla.ListColumns.Add(column);

            //column = new Column();
            //column.StrName = "Prueba4";
            //tabla.ListColumns.Add(column);

            //prueba.CreateTrigger(tabla);



            // ######################################## MYSQL ########################################

            MysqlDatabaseDA pruebaBD = new MysqlDatabaseDA("root", "123456", "localhost", "3306", "world");

            string ConnectionString = "server=localhost" + ";user= root" + ";database=world" + ";port=3306" + ";password=123456;";

            MySqlConnection _oConnection = new MySqlConnection(ConnectionString);
            _oConnection.Open();

            string strQuery = "SELECT * FROM COUNTRY";

            MySqlCommand cmdComando = new MySqlCommand(strQuery, _oConnection);
            cmdComando.ExecuteNonQuery();



        }
    }
}
