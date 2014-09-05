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
        
        public SqlServerDA() {
            try
            {
                _oLogErrors = new LogErrores();
                //string conexionBD = ConfigurationManager.AppSettings["CargoDispatcherDB"];
                ConnectionString = "user id=jariasm1;" +
                                       "password=Fr33d0m!;server=localhost;" +
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
