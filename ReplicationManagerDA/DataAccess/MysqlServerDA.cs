using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.LogErrores;
using UtilitariosCD.Constantes;
using System.Reflection;
using MySql.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using ReplicationManagerDA.Observer_Design_Pattern;
namespace ReplicationManagerDA.DataAccess
{
    public class MysqlServerDA : Observable
    {
        public LogErrores _oLogErrors;
        
        public MySqlConnection _oConnection;
        private string ConnectionString; 
        /// <summary>
        /// This is the Base Class for all the DA Method's Inside This Library
        /// Date: 9/4/2014
        /// Created By: Juan Pablo Arias Mora
        /// </summary>
        public MysqlServerDA() {
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

        public MysqlServerDA(string user, string password, string server, string port, string database="test") {
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
                this._oConnection = new MySqlConnection(this.ConnectionString);
                this._oConnection.Open();
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
