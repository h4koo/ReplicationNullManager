using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Reflection;
using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using System.Data;

namespace ProyectoZ.DataAccess
{
    public class ProyectoZDA
    {
        public LogErrores _oLogErrors;
        public SqlConnection _oConnection;
        private string ConnectionString;


        public ProyectoZDA(string user, string password, string server, string port, string database = "master")
        {
            try
            {
                _oLogErrors = new LogErrores();
                //string conexionBD = ConfigurationManager.AppSettings["CargoDispatcherDB"];

                ConnectionString = "Data Source=" + server + "," + port + ";Network Library=DBMSSOCN;Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password + ";Integrated Security = SSPI;";

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void OpenConnection()
        {
            try
            {
                _oLogErrors = new LogErrores();
                _oConnection = new SqlConnection(this.ConnectionString);
                _oConnection.Open();
                //_oConnection = new MySqlConnection(ConfigurationManager.AppSettings["CargoDispatcherDB"]);

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        public void CloseConnection()
        {
            try
            {

                _oLogErrors = new LogErrores();
                _oConnection.Close();

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public DataSet getAllCountry()
        {
            DataSet countrys = new DataSet();
            string strQuery = string.Empty;
            SqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "SELECT * FROM COUNTRY;";
                SqlCommand cmdComando = new SqlCommand(strQuery, this._oConnection);

                dtrResult = cmdComando.ExecuteReader();

                //Load the Results on the DataTable
                dtResult.Load(dtrResult);

                countrys.Tables.Add(dtResult);


            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }


            return countrys;
        }
    }
}
