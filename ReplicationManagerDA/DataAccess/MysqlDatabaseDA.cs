using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using UtilitariosCD.Entities;
using System.Reflection;
using MySql.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using ReplicationManagerBL.Observer_Design_Pattern;
using System.Threading;

namespace ReplicationManagerDA.DataAccess
{
    public class MysqlDatabaseDA : MysqlServerDA
    {

        private List<ReplicaLog> _listReplicaLogs;


        public MysqlDatabaseDA(string user, string password, string server, string port)
            : base(user, password, server, port, "test")
        {
            
        }
        public MysqlDatabaseDA(string user, string password, string server, string port, string db)
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
            MySqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "SHOW DATABASES;";
                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);
                //cmdComando.CommandType = CommandType.StoredProcedure;

                //cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();


                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    oDatabase = new Database();
                    oDatabase.StrName = dtrFila["Database"].ToString();
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
        /// This method will retrieve all the Tables for and specific DB on MySQL, this cannot be a SP because is on client side
        /// </summary>
        /// <param name="Database"></param>
        /// <returns></returns>
        public List<Table> GetAllTables(string Database)
        {
            List<Table> listResult = new List<Table>();
            Table oTable = new Table();

            string strQuery = string.Empty;
            MySqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "show tables FROM "+ Database;
                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);
                //cmdComando.CommandType = CommandType.StoredProcedure;

                //cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();


                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {

                   oTable = new Table();
                   oTable.StrName = dtrFila["Tables_in_"+Database].ToString();
                   listResult.Add(oTable);
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
        /// If not already exist it will create the LogReplicaTable on the Engine
        /// This cannot be a SP since it will run on a Client DB, SQL Embedded
        /// </summary>
        /// <returns></returns>
        public Boolean CreateReplicaLogs()
        {
            Boolean result = false;
            string strQuery = string.Empty;
            try
            {
                this.OpenConnection();
                strQuery = "CREATE TABLE  IF NOT EXISTS `replicalog` (" +
                                "`idReplicaLog` int(11) NOT NULL AUTO_INCREMENT," +
                                "`ReplicaTable` varchar(30) NOT NULL," +
                                "`ReplicaDatetime` datetime NOT NULL," +
                                "`ReplicaTransaction` varchar(100) NOT NULL," +
                                "`IsSynchronized` BIT NOT NULL DEFAULT 0," + 
                            "PRIMARY KEY (`idReplicaLog`)" +
                            ") ENGINE=InnoDB DEFAULT CHARSET=utf8;";

                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);
                cmdComando.ExecuteNonQuery();
                result = true;

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

        /// <summary>
        /// Return all logs that have not been synchronized
        /// </summary>
        /// <returns>A list of all the ReplicasLogs on the data base</returns>
        public List<ReplicaLog> GetReplicaLogsUnsynchronized()
        {
            ReplicaLog oReplicaLog = new ReplicaLog();
            List<ReplicaLog> listResult = new List<ReplicaLog>();

            string strQuery = string.Empty;
            MySqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "SELECT " +
                                " idReplicaLog, " +
                                " ReplicaTable, " +
                                " ReplicaDatetime, " +
                                " ReplicaTransaction, " +
                                " IsSynchronized " +
                            " FROM ReplicaLog " +
                            " WHERE " +
                                " IsSynchronized = 0 ";

                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);
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
        /// 
        /// </summary>
        /// <param name="pNombreTabla"></param>
        /// <returns></returns>
        public Table getTableStructure(string strNombreBase, string pNombreTabla)
        {
            Table oTable = new Table();
            oTable.StrName = pNombreTabla;
            string querry = "use " + strNombreBase + "; describe " + pNombreTabla;

            try
            {
            
                this.OpenConnection();
                MySqlCommand cmdComando = new MySqlCommand(querry, this._oConnection);
                MySqlDataReader lector = cmdComando.ExecuteReader();


                while (lector.Read())
                {
                    Column oColumn = new Column();
                    oColumn.StrName = lector.GetString(0);
                    oColumn.StrType = lector.GetString(1);

                    //nchar is set but default on all engines is varchar
//                    if (oColumn.StrType.Equals("nchar") || oColumn.StrType.Equals("varchar"))
//                    {
//                        oColumn.StrType = "varchar(" + dtrFila["PRECISION"].ToString() + ")";
//                    }

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


                    if (!lector.GetString(2).Equals("NO"))
                    {
                        oColumn.BoolNull = true;
                    }
                    oTable.ListColumns.Add(oColumn);
                }
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, querry);
            }
            finally
            {
                this.CloseConnection();
            }
            return oTable;
        }

        public Boolean createTable(Table table)
        {
            Boolean resultado = false;
            string strQuery = table.ToString();

            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);

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


        /// <summary>
        /// Crea una tabla a la base de datos.
        /// </summary>
        /// <param name="pNombreTabla"></param>
        /// <param name="pColumnas"></param>
        /// <param name="pTipo"></param>
        /// <returns></returns>
        //public string crearTabla(string pNombre, List<string> pColumnas, List<string> pTipo)
        public string createSQLTable(Table oTable)
        {
            string strQuerry = "create table " + oTable.StrName + " (";

            int counterColumns = oTable.ListColumns.Count();

            foreach (Column Ocolumn in oTable.ListColumns)
            {
                strQuerry += Ocolumn.StrName + " " + Ocolumn.StrType;

                if (Ocolumn.BoolNull)
                {
                    strQuerry += " NOT NULL ";
                }

                //Delimiter , for more than 1 colum
                counterColumns--;
                if (counterColumns > 0)
                {
                    strQuerry += ", ";
                } 

            }

            //strQuerry += "primary key(" + pColumnas[0] + ")
            strQuerry += ");";
            return strQuerry;
        }

        public Boolean ExecuteInsert(Insert insert)
        {
            Boolean result = false;
            string strQuery = insert.ToString();

            MySqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);

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

        public Boolean ExecuteMultipleInsert(List<Insert> listInsert)
        {
            Boolean result = true;
            foreach (Insert insert in listInsert)
            {
                if (!this.ExecuteInsert(insert))
                {
                    result = false;
                }
            }
            return result;
        }

        public List<Insert> GetCurrentRows(Table table)
        {
            List<Insert> result = new List<Insert>();
            Insert oInsert = new Insert();
            string strListColumns = string.Join(",", table.ListColumns);

            string strQuery = "SELECT " + strListColumns + " FROM " + table.StrName;


            MySqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {

                this.OpenConnection();
                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);

                dtrResult = cmdComando.ExecuteReader();

                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    oInsert = new Insert();

                    foreach (Column column in table.ListColumns)
                    {
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
        /// Indicates that a ReplicaLog has been synchronized
        /// </summary>
        /// <param name="pintIdReplicaLog">ID synchronized ReplicaLog</param>
        public void UpdateReplicaLogSynchronized(int pintIdReplicaLog)
        {
            string strQuery = string.Empty;

            try
            {
                this.OpenConnection();

                strQuery = " UPDATE ReplicaLog " +
                           " SET " +
                                " IsSynchronized = 1 " +
                            " WHERE " +
                                " idReplicaLog = " + pintIdReplicaLog.ToString();

                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);
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
