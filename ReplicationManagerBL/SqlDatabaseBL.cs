using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Entities;
using ReplicationManagerDA.DataAccess;

namespace ReplicationManagerBL
{
    public class SqlDatabaseBL
    {
        
        /// <summary>
        /// Sql Method to obtain Tables on DB
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public List<Database> GetDatabases(string user, string password, string server, string port)
        {
            SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user, password, server, port);
            return sqlDatabaseDA.GetAllDatabases();
        }



        public List<Table> GetTables(string user, string password, string server, string port, string database)
        {
            SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user, password, server, port, database);
            return sqlDatabaseDA.GetAllTables(database);
        }

        public Table ConfigSource(Replica replica) {
            SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            sqlDatabaseAccess.CreateReplicaLogs();
            //GEtTabe
            Table table = sqlDatabaseAccess.getTableStructure(replica.StrSourceDatabase, replica.StrSourceTable);
            //valuesToInsert = sqlDatabaseAccess.GetCurrentRows(table);
            sqlDatabaseAccess.CreateTrigger(table);
            return table;
        }

        public List<Insert> GetConfigValues(Replica replica, Table table) {
            SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            return sqlDatabaseAccess.GetCurrentRows(table);
        }

        public void ConfigTerminal(Replica replica, Table table, List<Insert> valuesToInsert) {
            SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
            sqlDatabaseAccess.CreateReplicaLogs();
            sqlDatabaseAccess.createTable(table);
            sqlDatabaseAccess.ExecuteMultipleInsert(valuesToInsert);
            sqlDatabaseAccess.CreateTrigger(table);
        }

        public void VerifyChanges()
        {
            //SqlDatabaseDA sqlDataBaseDA = new SqlDatabaseDA();

            //sqlDataBaseDA.VerifyChanges();
        }
    }
}
