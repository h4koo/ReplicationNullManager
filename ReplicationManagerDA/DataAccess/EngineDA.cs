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
    public class EngineDA : SqlServerDA
    {
        /// <summary>
        /// This is the DA for accessing the Engine table
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        /// <returns>A list of all the Engines Supported, List<Engine></returns>
        public List<Engine> GetAllSupportedEngines() {
            Engine oEngine = new Engine();
            List<Engine> listResult = new List<Engine>();
            string strQuery = string.Empty;
            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "GetAllSupportedEngines";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                dtrResult = cmdComando.ExecuteReader();

                
                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                foreach (DataRow dtrFila in dtResult.Rows)
                {
                    oEngine = new Engine();
                    oEngine.IntIdEngine = Convert.ToInt32(dtrFila["IdEngine"].ToString());
                    oEngine.StrName = dtrFila["Name"].ToString().Trim();
                    listResult.Add(oEngine);
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
    }
}
