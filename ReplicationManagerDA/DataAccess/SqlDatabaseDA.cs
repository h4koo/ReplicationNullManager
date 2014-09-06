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
        public List<Table> GetAllTables(string Database) {
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
    }
}
