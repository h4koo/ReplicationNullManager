using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Entidades;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using System.Reflection;

namespace ReplicationManagerDA
{
    public class EngineDA : SqlServerDA
    {
        public List<Engine> GetAllSupportedEngines() {
            Engine oEngine = new Engine();
            List<Engine> listResult = new List<Engine>();
            string strQuery = string.Empty;
            SqlDataReader dtrResultado = null;
            DataTable dtResultado = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "GetAllSupportedEngines";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                cmdComando.Parameters.Add("@intResult", SqlDbType.Int).Direction = ParameterDirection.Output;

                //Ejecutamos la consulta
                dtrResultado = cmdComando.ExecuteReader();

                //Cargamos la información del cliente en un datatable
                //para recorrerla de mejor manera.
                dtResultado.Load(dtrResultado);

                //Solo se debe de recorrer una vez ya que se está buscando por las credenciales
                foreach (DataRow dtrFila in dtResultado.Rows)
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
