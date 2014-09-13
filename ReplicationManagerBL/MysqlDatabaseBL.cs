using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Entities;
using ReplicationManagerDA.DataAccess;
namespace ReplicationManagerBL
{
    public class MysqlDatabaseBL
    {

        public List<Database> GetDatabases(string user, string password, string server, string port)
        {
            MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port);
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
        public List<Table> GetTables(string user, string password, string server, string port, string database)
        {
            MysqlDatabaseDA sqlDatabaseDA = new MysqlDatabaseDA(user, password, server, port, database);
            return sqlDatabaseDA.GetAllTables(database);
        }

        public Table ConfigSource(Replica replica) {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            sqlDatabaseAccess.CreateReplicaLogs();
            Table table = sqlDatabaseAccess.getTableStructure(replica.StrSourceDatabase, replica.StrSourceTable);
            
            sqlDatabaseAccess.CreateTriggerDelete(table);
            sqlDatabaseAccess.CreateTriggerInsert(table);
            sqlDatabaseAccess.CreateTriggerUpdate(table);
            return table;
        }
        public List<Insert> GetConfigValues(Replica replica,Table table) {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            
            return sqlDatabaseAccess.GetCurrentRows(table);
        }

        public void ConfigTerminal(Replica replica, Table table, List<Insert> valuesToInsert)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
            sqlDatabaseAccess.CreateReplicaLogs();
            sqlDatabaseAccess.createTable(table);
            sqlDatabaseAccess.ExecuteMultipleInsert(valuesToInsert);
            sqlDatabaseAccess.CreateTriggerDelete(table);
            sqlDatabaseAccess.CreateTriggerInsert(table);
            sqlDatabaseAccess.CreateTriggerUpdate(table);
        }

        public List<ReplicaLog> GetReplicaLogsSourceUnsynchronized(Replica replica)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            return sqlDatabaseAccess.GetReplicaLogsUnsynchronized(replica.StrSourceTable);
        }
        public List<ReplicaLog> GetReplicaLogsTerminalUnsynchronized(Replica replica)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
            return sqlDatabaseAccess.GetReplicaLogsUnsynchronized(replica.StrSourceTable);
        }

        public Boolean TableSyncTerminal(Replica replica, ReplicaLog replicaLog)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
            return sqlDatabaseAccess.TableSync(replica.StrSourceTable, replicaLog.StrReplicaTransaction);
        }
        public Boolean TableSyncSource(Replica replica, ReplicaLog replicaLog)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            return sqlDatabaseAccess.TableSync(replica.StrSourceTable, replicaLog.StrReplicaTransaction);
        }
        public Boolean SetReplicaSourceLogSync(Replica replica, ReplicaLog oreplicaLog)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrSourceUser, replica.StrSourcePassword, replica.StrSourceIPAddress, replica.IntSourcePort.ToString(), replica.StrSourceDatabase);
            return sqlDatabaseAccess.SetReplicaLogSync(oreplicaLog);
        }

        public Boolean SetReplicaTerminalLogSync(Replica replica, ReplicaLog oreplicaLog)
        {
            MysqlDatabaseDA sqlDatabaseAccess = new MysqlDatabaseDA(replica.StrTerminalUser, replica.StrTerminalPassword, replica.StrTerminalIPAddress, replica.IntTerminalPort.ToString(), replica.StrTerminalDatabase);
            return sqlDatabaseAccess.SetReplicaLogSync(oreplicaLog);
        }
    }
}