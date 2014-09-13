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
using System.Threading;

namespace ReplicationManagerDA.DataAccess
{
    public class SqlDatabaseDA : SqlServerDA , DatabaseDA
    {

        private List<ReplicaLog> _listReplicaLogs;
        


        public SqlDatabaseDA(string user, string password, string server, string port): base(user,password,server,port,"master")
        {
            _listReplicaLogs = new List<ReplicaLog>();
        }

        public SqlDatabaseDA(string user, string password, string server, string port, string db)
            : base(user, password, server, port, db)
        {
            _listReplicaLogs = new List<ReplicaLog>();
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
        public List<Table> GetAllTables(string Database)
        {
            List<Table> listResult = new List<Table>();
            Table oTable = new Table();

            string strQuery = string.Empty;
            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "sp_tables";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                //cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();


                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {

                    if (dtrFila["TABLE_TYPE"].ToString().Equals("TABLE"))
                    {
                        oTable = new Table();
                        oTable.StrName = dtrFila["TABLE_NAME"].ToString();
                        listResult.Add(oTable);
                    }

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
                                         "[ReplicaTransaction] text NOT NULL," +
                                         "[IsSynchronized] [bit] NOT NULL default 0" +
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

        public Boolean createTable(Table table)
        {
            Boolean resultado = false;
            string strQuery = table.ToString();

            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);

                cmdComando.ExecuteNonQuery();
                resultado = true;
                //Load the Results on the DataTable
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally
            {
                this.CloseConnection();
            }
            return resultado;
        }

        public Boolean ExecuteInsert(Insert insert)
        {
            Boolean result = false;
            string strQuery = insert.ToString();

            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);

                cmdComando.ExecuteNonQuery();
                result = true;
                //Load the Results on the DataTable
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally
            {
                this.CloseConnection();
            }
            return result;
        }

        public Boolean ExecuteMultipleInsert(List<Insert> listInsert) {
            Boolean result = true;
            foreach (Insert insert in listInsert) {
                if (!this.ExecuteInsert(insert)) {
                    result = false;
                }
            }
            return result;
        }

        public Table getTableStructure(string strNombreBase, string pNombreTabla)
        {
            Table oTable = new Table();
            oTable.StrName = pNombreTabla;
            string strQuery = "sp_columns";

            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;
                cmdComando.Parameters.AddWithValue("@table_name", pNombreTabla);
                dtrResult = cmdComando.ExecuteReader();

                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    Column oColumn = new Column();
                    oColumn.StrName = dtrFila["COLUMN_NAME"].ToString();
                    oColumn.StrType = dtrFila["TYPE_NAME"].ToString();
                    
                    //nchar is set but default on all engines is varchar
                    if (oColumn.StrType.Equals("nchar") || oColumn.StrType.Equals("varchar"))
                    {
                        oColumn.StrType = "varchar("+dtrFila["PRECISION"].ToString()+")";
                    }

                    if (oColumn.StrType.Contains("int"))
                    {
                        oColumn.StrType = "int";
                    }
                    
                    if (oColumn.StrType.Contains("float"))
                    {
                        oColumn.StrType = "float";
                    }

                    if (oColumn.StrType.Contains("smallint"))
                    {
                        oColumn.StrType = "smallint";
                    }

                    //Identity is hidden on column
                    if (oColumn.StrType.Contains("identity")){
                        oColumn.StrType = oColumn.StrType.Remove(oColumn.StrType.Length - 8);
                    }
                    if (dtrFila["IS_NULLABLE"].ToString().Equals("NO"))
                    {
                        oColumn.BoolNull = true;
                    }
                    oTable.ListColumns.Add(oColumn);

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
            return oTable;
        }

        public Boolean CreateTriggerInsert(Table table)
        {
            bool result = false;
            string strQuery = "";

            try
            {

                string strTransaction = "' INSERT INTO " + table.StrName + 
                                        " ( " + 
                                        string.Join(",", table.ListColumns) +
                                        " ) " + 
                                        " VALUES " + 
                                        " ( ''' + " +
                                            "(SELECT INSERTED." + string.Join(" FROM INSERTED) + ''', ''' + (SELECT INSERTED.", table.ListColumns) + " FROM INSERTED) " +
                                        " + ''' ) '";

                strQuery = " CREATE TRIGGER " + table.StrName + "_INSERT " +
                                  " ON " + table.StrName +
                                  " AFTER INSERT " +
                                  " AS " + 
                                  " BEGIN " + 
                                  " " +
                                  "     INSERT INTO ReplicaLog " + 
                                  "     ( " +
                                  "         ReplicaTable " +
                                  "         ,ReplicaDatetime " +
                                  "         ,ReplicaTransaction " +
                                  "         ,IsSynchronized " +
                                  "     ) " +
                                  "     VALUES " +
                                  "     ( " +
                                  "         '" + table.StrName + "'" +
                                  "         ,GETDATE() " +
                                  "         , " + strTransaction + 
                                  "         ,0 " +
                                  "     ) " +
                                  " " + 
                                  " END";


                this.OpenConnection();
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);

                cmdComando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
                result = false;
            }


            return result;
        }


        public List<Insert> GetCurrentRows(Table table) {
            List<Insert> result = new List<Insert>();
            Insert oInsert = new Insert();
            string strListColumns =  string.Join(",", table.ListColumns);
            
            string strQuery = "SELECT " + strListColumns + " FROM " + table.StrName;
            

            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                
                dtrResult = cmdComando.ExecuteReader();

                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    oInsert = new Insert();
                    
                    foreach (Column column in table.ListColumns) {
                        oInsert.strTableName = table.StrName;
                        oInsert.listColumnNames.Add(column.StrName);
                        oInsert.listValues.Add(dtrFila[column.StrName].ToString().Trim());
                    }
                    //nchar is set but default on all engines is varchar
                    result.Add(oInsert);

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
            return result;

        } 

        #region Observer

            /// <summary>
            /// Return all logs that have not been synchronized
            /// </summary>
            /// <returns>A list of all the ReplicasLogs on the data base</returns>
            public List<ReplicaLog> GetReplicaLogsUnsynchronized()
            {
                ReplicaLog oReplicaLog = new ReplicaLog();
                List<ReplicaLog> listResult = new List<ReplicaLog>();

                string strQuery = string.Empty;
                SqlDataReader dtrResult = null;
                DataTable dtResult = new DataTable();

                try
                {
                    this.OpenConnection();

                    strQuery = "SELECT " +
	                                " [idReplicaLog], " + 
	                                " [ReplicaTable], " +
	                                " [ReplicaDatetime], " +
	                                " [ReplicaTransaction], " +
	                                "[IsSynchronized]" +
                                " FROM [dbo].[ReplicaLog] " +
                                " WHERE " +
	                                " [IsSynchronized] = 0 ";

                    SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                    dtrResult = cmdComando.ExecuteReader();


                    //Load the Results on the DataTable
                    dtResult.Load(dtrResult);

                    foreach (DataRow dtrFila in dtResult.Rows)
                    {
                        oReplicaLog = new ReplicaLog();

                        oReplicaLog.IntIdReplicaLog = Convert.ToInt32(dtrFila["idReplicaLog"].ToString());
                        oReplicaLog.StrReplicaTable = dtrFila["ReplicaTable"].ToString();
                        oReplicaLog.DtReplicaDatetime = Convert.ToDateTime(dtrFila["ReplicaDatetime"].ToString());
                        oReplicaLog.StrReplicaTransaction = dtrFila["ReplicaTransaction"].ToString();
                        oReplicaLog.BlnIsSynchronized = Convert.ToBoolean(dtrFila["IsSynchronized"].ToString());                    

                        listResult.Add(oReplicaLog);
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
            /// Indicates that a ReplicaLog has been synchronized
            /// </summary>
            /// <param name="pintIdReplicaLog">ID synchronized ReplicaLog</param>
            public void UpdateReplicaLogSynchronized(int pintIdReplicaLog)
            {
                string strQuery = string.Empty;

                try
                {
                    this.OpenConnection();

                    strQuery = " UPDATE [dbo].[ReplicaLog] " +
	                           " SET " +
		                            " [IsSynchronized] = 1 " +
	                            " WHERE " +
                                    " [idReplicaLog] = " + pintIdReplicaLog.ToString();
                

                    SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                    cmdComando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
                }
                finally
                {
                    this.CloseConnection();
                }        
            }


            public void Run()
            {
                try
                {
                    ListReplicaLogs = GetReplicaLogsUnsynchronized();

                    if (ListReplicaLogs != null)
                    {
                        if (ListReplicaLogs.Count > 0)
                        {
                            this.Notify();
                        }
                    }
                }
                catch (Exception ex)
                {
                    this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, string.Empty);
                }
            }

            public void VerifyChanges()
            {
                try
                {
                    Thread newThread = new Thread(new ThreadStart(Run));
                    newThread.Start(); 
                }
                catch (Exception ex)
                {
                    this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, string.Empty);
                }            
            }


            public List<ReplicaLog> ListReplicaLogs
        {
            get { return _listReplicaLogs; }
            set { _listReplicaLogs = value; }
        }

        #endregion
    }
}
