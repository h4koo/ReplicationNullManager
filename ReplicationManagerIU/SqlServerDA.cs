using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using System.Reflection;

namespace ReplicationManagerDA
{
    public class SqlServerDA
    {
        public LogErrores _oLogErrors;
        public SqlConnection _oConnection;
        private string ConnectionString; 
        /// <summary>
        /// This is the Base Class for all the DA Method's Inside This Library
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        public SqlServerDA() {
            try
            {
                _oLogErrors = new LogErrores();
                //string conexionBD = ConfigurationManager.AppSettings["CargoDispatcherDB"];

                ConnectionString = "user id=ReplicationManager_su;" +
                                   "password=12345;server=localhost;" +
                                   "Trusted_Connection=yes;" +
                                   "database=ReplicationManager; " +
                                   "connection timeout=30";
                
                //_oConnection = new MySqlConnection(conexionBD);

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        public SqlServerDA(string user, string password, string server, string port, string database="master") {
            try
            {
                _oLogErrors = new LogErrores();
                //string conexionBD = ConfigurationManager.AppSettings["CargoDispatcherDB"];

                ConnectionString = "Data Source=" + server + "," + port + ";Network Library=DBMSSOCN;Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password + ";Integrated Security = SSPI;";

                //ConnectionString = "user id="+user+";" +
                //                   "password="+password+";server="+server+";" +
                //                   "Trusted_Connection=yes;" +
                //                   "database="+database+";" +
                //                   "connection timeout=30";
                //_oConnection = new MySqlConnection(conexionBD);

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This method will Open the Connection Required.
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora     
        /// </summary>
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
        /// <summary>
        /// This method will Close the Connection On Progress
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora     
        /// </summary>
        public void CloseConnection() {
            try{
                _oLogErrors = new LogErrores();
                _oConnection.Close();

            }
            catch (Exception ex)
            {
                _oLogErrors.GuardarLog(IConstantes.TIPOCAPA.ACCESODATOS, this.GetType().ToString(), MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
