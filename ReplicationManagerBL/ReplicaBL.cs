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
                sqlDatabaseBL.ConfigTerminal(replica,table,valuesToInsert);

            }
            if (replica.StrTerminalEngine.Contains("MySQL"))
            {
                mysqlDatabaseBL.ConfigTerminal(replica,table,valuesToInsert);
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

        
    }
}
