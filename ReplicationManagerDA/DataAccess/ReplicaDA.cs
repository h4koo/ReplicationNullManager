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
    public class ReplicaDA : SqlServerDA
    {
        /// <summary>
        /// This is the DA for accessing the Replica table
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        /// <returns>A list of all the Replicas on the table, List<Replica></returns>
        public List<Replica> GetAllReplicas() {
            Replica oReplica = new Replica();
            List<Replica> listResult = new List<Replica>();
            string strQuery = string.Empty;
            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "GetAllReplicas";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();

                
                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    oReplica = new Replica();
                    oReplica.IntIdReplica = Convert.ToInt32(dtrFila["idReplica"].ToString());
                    oReplica.StrSourceEngine = dtrFila["SourceEngine"].ToString();
                    oReplica.IntIdSourceEngine = Convert.ToInt32(dtrFila["IdSourceEngine"].ToString());
                    oReplica.StrTerminalEngine =  dtrFila["TerminalEngine"].ToString();
                    oReplica.IntIdTerminalEngine = Convert.ToInt32(dtrFila["IdTerminalEngine"].ToString());
                    oReplica.StrSourceIPAddress = dtrFila["SourceIPAddress"].ToString();
                    oReplica.IntSourcePort = Convert.ToInt32(dtrFila["SourcePort"].ToString());
                    oReplica.StrSourceUser = dtrFila["SourceUser"].ToString();
                    oReplica.StrSourcePassword = dtrFila["SourcePassword"].ToString();
                    oReplica.StrSourceDatabase = dtrFila["SourceDatabase"].ToString();
                    oReplica.StrSourceTable = dtrFila["SourceTable"].ToString();
                    oReplica.StrTerminalIPAddress = dtrFila["TerminalIPAddress"].ToString();
                    oReplica.IntTerminalPort = Convert.ToInt32(dtrFila["TerminalPort"].ToString());
                    oReplica.StrTerminalUser =  dtrFila["TerminalUser"].ToString();
                    oReplica.StrTerminalPassword = dtrFila["TerminalPassword"].ToString();
                    oReplica.StrTerminalDatabase = dtrFila["TerminalDatabase"].ToString();
                    oReplica.BoolEnable = Convert.ToBoolean(dtrFila["Enable"].ToString());
                    oReplica.StrCreated = dtrFila["Created"].ToString();
                    
                    object value = dtrFila["LastCheckOnSource"];
                    if (value != DBNull.Value)
                    {
                        oReplica.StrLastCheckOnSource = dtrFila["LastCheckOnSource"].ToString();
                    }

                    value = dtrFila["LastCheckOnTerminal"];
                    if (value != DBNull.Value)
                    {
                        oReplica.StrLastCheckOnSource = dtrFila["LastCheckOnTerminal"].ToString();
                    }



                    listResult.Add(oReplica);
                }
            }
            catch (Exception ex)
            {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally{
                this.CloseConnection();
            }
            return listResult;
        }

        public void Enable(int intIdReplica) {
            
            string strQuery = string.Empty;

            try
            {
                this.OpenConnection();

                strQuery = "EnableReplica";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.Add(new SqlParameter("intIdReplica", intIdReplica));
                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

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
        public void Disable(int intIdReplica)
        {

            string strQuery = string.Empty;

            try
            {
                this.OpenConnection();

                strQuery = "DisableReplica";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.Add(new SqlParameter("intIdReplica", intIdReplica));
                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

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
        public Boolean Insert(Replica newReplica) {
            string strQuery = string.Empty;
            Boolean result = false;

            try
            {
                this.OpenConnection();

                strQuery = "InsertReplica";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.AddWithValue("@intIdSourceEngine", newReplica.IntIdSourceEngine);
                cmdComando.Parameters.AddWithValue("@strSourceIPAddress", newReplica.StrSourceIPAddress);
                cmdComando.Parameters.AddWithValue("@intSourcePort", newReplica.IntSourcePort);
                cmdComando.Parameters.AddWithValue("@strSourceUser", newReplica.StrSourceUser);
                cmdComando.Parameters.AddWithValue("@strSourcePassword", newReplica.StrSourcePassword);
                cmdComando.Parameters.AddWithValue("@strSourceDatabase", newReplica.StrSourceDatabase);
                cmdComando.Parameters.AddWithValue("@strSourceTable", newReplica.StrSourceTable);
                cmdComando.Parameters.AddWithValue("@intIdTerminalEngine", newReplica.IntIdTerminalEngine);
                cmdComando.Parameters.AddWithValue("@strTerminalIPAddress", newReplica.StrTerminalIPAddress);
                cmdComando.Parameters.AddWithValue("@intTerminalPort", newReplica.IntTerminalPort);               
                cmdComando.Parameters.AddWithValue("@strTerminalUser", newReplica.StrTerminalUser);
                cmdComando.Parameters.AddWithValue("@strTerminalPassword", newReplica.StrTerminalPassword);
                cmdComando.Parameters.AddWithValue("@strTerminalDatabase", newReplica.StrTerminalDatabase);
                
                		
		
		

                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;                

                cmdComando.ExecuteScalar();

                int intResultado = Int32.Parse(cmdComando.Parameters["@intResult"].Value.ToString());

                if (intResultado == 0)
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

        public Boolean Delete(int IdReplica) {
            string strQuery = string.Empty;
            Boolean result = false;
            try {
                this.OpenConnection();

                strQuery = "DeleteReplica";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.AddWithValue("@intIdReplica", IdReplica);

                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmdComando.ExecuteScalar();

                int intResultado = Int32.Parse(cmdComando.Parameters["@intResult"].Value.ToString());

                if (intResultado == 0)
                    result = true;
            }
            catch (Exception ex) {
                this._oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message, strQuery);
            }
            finally {
                this.CloseConnection();
            }
            return result;
        }
    }
}
