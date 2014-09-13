using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplicationManagerDA.DataAccess;
using UtilitariosCD.Entities;
namespace ReplicationManagerBL
{
    public class ReplicaBL
    {
        /*
         * Constructor
         */
        public ReplicaBL()
        {
        }
        /// <summary>
        /// This will configure the Initial Replica requirements on the client
        /// </summary>
        /// <param name="replica"></param>
        public void InitialReplicaClientConfig(Replica replica)
        {
            //Source Config
            Table table = new Table();
            List<Insert> valuesToInsert = new List<Insert>();
            if (replica.StrSourceEngine.Contains("SQL Server"))
            {
                SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                //GEtTabe
                table = sqlDatabaseAccess.getTableStructure(replica.StrSourceDatabase, replica.StrSourceTable);
                valuesToInsert = sqlDatabaseAccess.GetCurrentRows(table);
                sqlDatabaseAccess.CreateTrigger(table);
            }
            if (replica.StrSourceEngine.Contains("MySQL"))
            {
                MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                table = sqlDatabaseAccess.getTableStructure(replica.StrSourceDatabase, replica.StrSourceTable);
                valuesToInsert = sqlDatabaseAccess.GetCurrentRows(table);
                sqlDatabaseAccess.CreateTriggerDelete(table);
                sqlDatabaseAccess.CreateTriggerInsert(table);
                sqlDatabaseAccess.CreateTriggerUpdate(table);

            }
            //Terminal Config
            if (replica.StrTerminalEngine.Contains("SQL Server"))
            {
                SqlDatabaseDA sqlDatabaseAccess = new SqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                sqlDatabaseAccess.createTable(table);
                sqlDatabaseAccess.ExecuteMultipleInsert(valuesToInsert);
                sqlDatabaseAccess.CreateTrigger(table);
            }
            if (replica.StrTerminalEngine.Contains("MySQL"))
            {
                MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
                sqlDatabaseAccess.CreateReplicaLogs();
                sqlDatabaseAccess.createTable(table);
                sqlDatabaseAccess.ExecuteMultipleInsert(valuesToInsert);
                sqlDatabaseAccess.CreateTriggerDelete(table);
                sqlDatabaseAccess.CreateTriggerInsert(table);
                sqlDatabaseAccess.CreateTriggerUpdate(table);
            }
        }
        /// <summary>
        /// This method insert on ReplicaManager Database
        /// </summary>
        /// <param name="replica"></param>
        public void InsertReplica(Replica replica) { 
                    ReplicaDA replicaDA = new ReplicaDA();
                    replicaDA.Insert(replica);
        }

        /// <summary>
        /// Query the DB to get all supported engines
        /// </summary>
        /// <returns></returns>
        public List<Engine> GetAllEngines()
        {

            EngineDA EnginesDA = new EngineDA();
            return EnginesDA.GetAllSupportedEngines();
        }
        /// <summary>
        /// Sql Method to obtain Tables on DB
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public List<Database> GetSqlDatabases(string user, string password, string server, string port) {
            SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user, password, server, port);
            return sqlDatabaseDA.GetAllDatabases();
        }
        /// <summary>
        /// MySql Method to obtain Tables on DB
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public List<Database> GetMySqlDatabases(string user, string password, string server, string port)
        {
            MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port);
            return sqlDatabaseDA.GetAllDatabases();
        }


        public List<Table> GetSqlTables(string user, string password, string server, string port, string database)
        {
            SqlDatabaseDA sqlDatabaseDA = new SqlDatabaseDA(user, password, server, port, database);
            return sqlDatabaseDA.GetAllTables(database);
        }

        public List<Table> GetMySqlTables(string user, string password, string server, string port, string database)
        {
            MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port, database);
            return sqlDatabaseDA.GetAllTables(database);
        }
    }
}
