using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReplicationManagerDA.DataAccess;
using UtilitariosCD.Entities;
using ReplicationManagerDA.Observer_Design_Pattern;

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
            SqlDatabaseBL sqlDatabaseBL = new SqlDatabaseBL();
            MysqlDatabaseBL mysqlDatabaseBL = new MysqlDatabaseBL();
            List<Insert> valuesToInsert = new List<Insert>();
            if (replica.StrSourceEngine.Contains("SQL Server"))
            {

                table = sqlDatabaseBL.ConfigSource(replica);
                valuesToInsert = sqlDatabaseBL.GetConfigValues(replica, table);
            }
            if (replica.StrSourceEngine.Contains("MySQL"))
            {
                table = mysqlDatabaseBL.ConfigSource(replica);
                valuesToInsert = mysqlDatabaseBL.GetConfigValues(replica, table);


            }
            //Terminal Config
            if (replica.StrTerminalEngine.Contains("SQL Server"))
            {
                sqlDatabaseBL.ConfigTerminal(replica, table, valuesToInsert);

            }
            if (replica.StrTerminalEngine.Contains("MySQL"))
            {
                mysqlDatabaseBL.ConfigTerminal(replica, table, valuesToInsert);
            }
        }
        /// <summary>
        /// This method insert on ReplicaManager Database
        /// </summary>
        /// <param name="replica"></param>
        public void InsertReplica(Replica replica)
        {
            ReplicaDA replicaDA = new ReplicaDA();
            replicaDA.Insert(replica);
        }

        public void CheckChangesReplica(Replica replica)
        {

            List<ReplicaLog> replicaLogSource = new List<ReplicaLog>();
            List<ReplicaLog> replicaLogTerminal = new List<ReplicaLog>();

            SqlDatabaseBL sqlDatabaseBL = new SqlDatabaseBL();
            MysqlDatabaseBL mysqlDatabaseBL = new MysqlDatabaseBL();

            if (replica.StrSourceEngine.Contains("SQL Server"))
            {
                replicaLogSource = sqlDatabaseBL.GetReplicaLogsSourceUnsynchronized(replica);
            }
            if (replica.StrSourceEngine.Contains("MySQL"))
            {
                replicaLogSource = mysqlDatabaseBL.GetReplicaLogsSourceUnsynchronized(replica);
            }
            if (replica.StrTerminalEngine.Contains("SQL Server"))
            {
                replicaLogTerminal = sqlDatabaseBL.GetReplicaLogsTerminalUnsynchronized(replica);
            }
            if (replica.StrTerminalEngine.Contains("MySQL"))
            {
                replicaLogTerminal = mysqlDatabaseBL.GetReplicaLogsTerminalUnsynchronized(replica);
            }

            if (replicaLogSource.Count() > 0)
            {

                //Sync Terminal
                foreach (ReplicaLog replicaLog in replicaLogSource)
                {
                    if (replica.StrTerminalEngine.Contains("SQL Server"))
                    {
                        sqlDatabaseBL.TableSyncTerminal(replica, replicaLog);
                    }
                    if (replica.StrTerminalEngine.Contains("MySQL"))
                    {
                        mysqlDatabaseBL.TableSyncTerminal(replica,replicaLog);
                    }
                    if (replica.StrSourceEngine.Contains("SQL Server"))
                    {
                        
                        sqlDatabaseBL.SetReplicaSourceLogSync(replica, replicaLog);
                    }
                    if (replica.StrSourceEngine.Contains("MySQL"))
                    {
                        //mysqlDatabaseBL.TableSyncTerminal(replica,replicaLog);
                        mysqlDatabaseBL.SetReplicaSourceLogSync(replica, replicaLog);
                    }
                }
            }
            if (replicaLogTerminal.Count() > 0)
            {

                //Sync Terminal
                foreach (ReplicaLog replicaLog in replicaLogTerminal)
                {
                    if (replica.StrSourceEngine.Contains("SQL Server"))
                    {
                        sqlDatabaseBL.TableSyncSource(replica, replicaLog);
                        sqlDatabaseBL.SetReplicaTerminalLogSync(replica, replicaLog);
                    }
                    if (replica.StrSourceEngine.Contains("MySQL"))
                    {
                        mysqlDatabaseBL.TableSyncSource(replica, replicaLog);
                        //sqlDatabaseBL.SetReplicaTerminalLogSync(replica, replicaLog);
                    }
                    if (replica.StrTerminalEngine.Contains("SQL Server"))
                    {

                        sqlDatabaseBL.SetReplicaTerminalLogSync(replica, replicaLog);
                    }
                    if (replica.StrTerminalEngine.Contains("MySQL"))
                    {
                        //mysqlDatabaseBL.TableSyncTerminal(replica,replicaLog);
                        mysqlDatabaseBL.SetReplicaTerminalLogSync(replica, replicaLog);
                    }
                }
            }
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


    }
}
