using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Entities;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using System.Reflection;

namespace ReplicationManagerDA.DataAccess
{
    public class SqlDatabaseDA : SqlServerDA
    {
        public SqlDatabaseDA(string user, string password, string server, string port): base(user,password,server,port,"master")
        {
            
        }
        public SqlDatabaseDA(string user, string password, string server, string port, string db)
            : base(user, password, server, port, db)
        {

        }
        /// <summary>
        /// This is the DA for accessing the Replica table
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        /// <returns>A list of all the Replicas on the table, List<Replica></returns>
        public List<Database> GetAllDatabases()
        {
            Database oDatabase = new Database();
            List<Database> listResult = new List<Database>();
            string strQuery = string.Empty;
            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "sp_databases";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                //cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();


                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    oDatabase = new Database();
                    oDatabase.StrName = dtrFila["DATABASE_NAME"].ToString();
                    listResult.Add(oDatabase);
                }
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally
            {
                this.CloseConnection();
            }
            return listResult;
        }




        /// <summary>
        /// This method will retrieve all the Tables for and specific DB on SQL, this cannot be a SP because is on client side
        /// </summary>
        /// <param name="Database"></param>
        /// <returns></returns>
        /// 
        /// ****method should return the list of tables that are going to be replicated from the ReplicationManager internal tables
        /// **** needs to be modified so it does't get al tables, but the tables to be replicated
        public List<Table> GetAllTables(string Database) {
            List<Table> listResult = new List<Table>();
            Table oTable = new Table();
          
            string strQuery = string.Empty;
            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                //modified string to use sys.tables (assumes the "USE 'Database'" is correct (should be the internal
                //replication database), the use statement should be correct from the connection string, where the 
                //database to use is selected
                strQuery = "SELECT SourceTable FROM Replication WHERE SourceDatabase= '"+ Database+ "'"; 
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
//                cmdComando.CommandType = CommandType.StoredProcedure;

                //cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();


                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

//                foreach (DataRow dtrFila in dtResult.Rows)

                //modified to only use the Reader since only one column needed
                while(dtrResult.Read())
                {

//                    if (dtrFila["TABLE_TYPE"].ToString().Equals("TABLE"))
//                    {
                        oTable = new Table();
                        oTable.StrName = dtrResult.GetString(0);
                        listResult.Add(oTable);
//                    }

                }

                dtrResult.Close();
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally
            {
                
                this.CloseConnection();
            }
            return listResult;
            
        }


        //creates the destination tables on the destination databse according to the metadata 
        //retrieved from the source datbase for the replication tables
        public void createDestinationTables(string dbName) {
            OpenConnection();

            var TableNames = GetAllTables(dbName);
//                new List<string>();
          
//            SqlConnection dbConnection= _oConnection;
//            {
//                var cmd =
//                    new SqlCommand("SELECT Table_Name FROM information_schema.tables WHERE table_name LIKE 'mavara%'",
//                        dbConnection);
//                SqlDataReader reader = cmd.ExecuteReader();
//
//                while(reader.Read()) {
//                    TableNames.Add(reader[0].ToString());
//                }
//                reader.Close();
//            }


            //gets all columns for each table
            foreach(Table tableName in TableNames) {
                var cmd =
                    new SqlCommand(
                        "SELECT column_name, data_type, character_maximum_length" +
                            "FROM INFORMATION_SCHEMA.COLUMNS" +
                            "WHERE TABLE_NAME = '" +
                        tableName.StrName + "'", _oConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                var Columns = new List<string[]>();
                while(reader.Read()) {
                    var column = new string[3];
                    column[0] = reader[0].ToString();
                    column[1] = reader[1].ToString();
                    column[2] = reader[2].ToString();
                    Columns.Add(column);
                }

                reader.Close();

                // create tables in the destination database
                //formats the insert for mysql insertion
                string queryCreatTables = "CREATE TABLE " + tableName + " (\n";
                foreach(var cols in Columns) {
                    queryCreatTables += cols[0] + " " + cols[1] ;
                    if(cols[2]!="NULL" && cols[2]!="-1")
                        queryCreatTables += "("+cols[2]+")";//sets specified size
                    if(cols[3] == "NO")
                        queryCreatTables += " NOT NULL";
                    // else
                    //   queryCreatTables += "NULL";
                    queryCreatTables += " ,\n ";
                }
                queryCreatTables += ")";

                var smd =
                    new SqlCommand(queryCreatTables, _oConnection);
                SqlDataReader sreader = smd.ExecuteReader();
                sreader.Close();
            }
        }



        /// <summary>
        /// If not already exist it will create the LogReplicaTable on the Engine
        /// This cannot be a SP since it will run on a Client DB, SQL Embedded
        /// </summary>
        /// <returns></returns>
        public Boolean CreateReplicaLogs() {
            Boolean result = false;
            string strQuery = string.Empty;
            try
            {
                this.OpenConnection();
                strQuery = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[ReplicaLog]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)" +
                           "CREATE TABLE [dbo].[ReplicaLog](" +
                                         "[idReplicaLog] [int] IDENTITY(1,1) NOT NULL," +
                                         "[ReplicaTable] [nchar](30) NOT NULL," +
                                         "[ReplicaDatetime] [datetime] NOT NULL," +
                                         "[ReplicaTransaction] [nchar](100) NOT NULL" +
                                         ") ON [PRIMARY]";

                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.ExecuteNonQuery();
                result = true;
            
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally {
                this.CloseConnection();            
            }
            return result;
        }
        
    }
}
