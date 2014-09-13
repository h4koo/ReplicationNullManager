using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using MySql.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using System.Data;

namespace ProyectoX.DataAccess
{
    class ProyectoXDA
    {

        public LogErrores _oLogErrors;

        public MySqlConnection _oConnection;
        private string ConnectionString;


        public ProyectoXDA()
        {
            try
            {
                _oLogErrors = new LogErrores();
                //string conexionBD = ConfigurationManager.AppSettings["CargoDispatcherDB"];

                ConnectionString = "user id=root;" +
                                   "password=123456;server=localhost;" +
                                   "Trusted_Connection=yes;" +
                                   "database=world; " +
                                   "connection timeout=30";

                //_oConnection = new MySqlConnection(conexionBD);

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        public ProyectoXDA(string user, string password, string server, string port, string database = "test")
        {
            try
            {
                _oLogErrors = new LogErrores();
                //string conexionBD = ConfigurationManager.AppSettings["CargoDispatcherDB"];

                ConnectionString = "server=" + server + ";user=" + user + ";database=" + database + ";port=" + port + ";password=" + password + ";";
                
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
                this._oConnection = new MySqlConnection(this.ConnectionString);
                this._oConnection.Open();
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
            MySqlDataReader dtrResult = null;
            DataTable dtResult = new DataTable();

            try
            {
                this.OpenConnection();

                strQuery = "SELECT * FROM COUNTRY;";
                MySqlCommand cmdComando = new MySqlCommand(strQuery, this._oConnection);

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
