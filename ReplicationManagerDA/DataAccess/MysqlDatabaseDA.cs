﻿using System;
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
       
    }
}
