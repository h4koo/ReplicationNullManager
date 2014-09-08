using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;

namespace ReplicationManagerAD.Clases
{
    class Conector
    {

        #region Variables
            private MySqlConnection mscConexion;
            private string strServidor;
            private string strPuerto;
            private string strNombreBase;
            private string strUsuario;
            private string strPassword;
        #endregion

        #region Variables de Prueba
            private string strConectado =    "Conectado";
            private string strDesconectado =    "Desconectado";
            private string strError   =    "Error";
        #endregion

        public Conector(string pServidor, string pPuerto, string pNombreBase, string pAdministrador, string pPassword)
        {
            mscConexion     =   new MySqlConnection();
            strServidor     =   pServidor;
            strPuerto       =   pPuerto;
            strNombreBase   =   pNombreBase;
            strUsuario      =   pAdministrador;
            strPassword     =   pPassword;
        }//END CONSTRUCTOR

        /// <summary>
        /// Inserta una persona a la tabla persona
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pNombre"></param>
        /// <returns></returns>
        private int agregar(int pID, string pNombre, string pNombreTabla)
        {
            try
            {
                int retorno = 0;
                abrirConexionBase();
                String inicioQuerry = "Insert into " + pNombreTabla + "(ID,Nombre) values ('{0}','{1}')";
                MySqlCommand comando = new MySqlCommand(string.Format(inicioQuerry, pID, pNombre), mscConexion);
                retorno = comando.ExecuteNonQuery();
                cerrarConexionBase();
                return retorno;
            }
            catch (Exception)
            {                
                return -2;
            }
        }//END AGREGAR

        /// <summary>
        /// DESCRIPCION: Hace mscConexion con la base de datos. Mediante los datos ingresados como parametro
        /// WEB : http://dejensever.com/2012/12/17/mysql-desde-c-en-visual-studio-2012/
        /// </summary>
        /// <param name="pServidor"></param>
        /// <param name="pPuerto"></param>
        /// <param name="pNombreBase"></param>
        /// <param name="pAdministrador"></param>
        /// <param name="pPassword"></param>
        public string abrirConexionBase()
        {
            try
            {
                string querryConexion = "Server=" + strServidor + ";Port=" + strPuerto + ";Database=" + strNombreBase + ";Uid=" + strUsuario + ";Pwd=" + strPassword;
                mscConexion.ConnectionString = querryConexion;
                mscConexion.Open();
                if (mscConexion.State == ConnectionState.Open)  //Verifiva que la mscConexion a la base de datos este abierta
                {
                    return strConectado;
                }
                else
                {
                    return strDesconectado;
                }
            }
            catch (Exception)
            {
                return strError;
            }
        }//END CARGAR BASE

        /// <summary>
        /// Cierra conexion a la Base Datos
        /// </summary>
        public string cerrarConexionBase()
        {
            try
            {
                mscConexion.Close();
                return strDesconectado;
            }
            catch (Exception)
            {
                return strError;
            }
        }//END CERRAR BASE

        /// <summary>
        /// Consulta al sistema el nombre de las bases de datos del sistema
        /// </summary>
        /// <returns>Una lista con el nombre de las bases de datos existentes en el computador</returns>
        public List<string> buscarBases() {
            List<string> resultado = new List<string>();
            try {
                MySqlCommand comando = new MySqlCommand(String.Format("mostrarBases"), mscConexion);
              
                comando.CommandType = CommandType.StoredProcedure;

                abrirConexionBase();
                MySqlDataReader lector = comando.ExecuteReader();
                
                 while(lector.Read()){
                     resultado.Add(lector.GetString(0));
                 }
                 cerrarConexionBase();
                return resultado;
            }
            catch (Exception error) {
                resultado.Add(error.Message);
                cerrarConexionBase();
                return resultado;
            }
        }//END BUSCAR BASE

        /// <summary>
        /// Busca en la base de datos la lista de tablas en la base de datos ingresada en la variable de clase
        /// </summary>
        /// <param name="pNombreBase"></param>
        /// <returns> lista de nombres de las tablas de la base ingresada como parametro</returns>
        public List<string> buscarTablas() {
            
            List<string> resultado = new List<string>();
            //string querry = "use " + strNombreBase + "; show tables";            

            try {

                MySqlCommand comando = new MySqlCommand(String.Format("mostrarTablas"), mscConexion);
                comando.CommandType = CommandType.StoredProcedure;

                abrirConexionBase();
                MySqlDataReader lector = comando.ExecuteReader();

                while (lector.Read()) {
                    resultado.Add(lector.GetString(0));
                }
                cerrarConexionBase();
                return resultado;
            }
            catch (Exception error) {
                resultado.Add(error.Message);
                cerrarConexionBase();
                return resultado;
            }
        }//END BUSCAR TABLAS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLista"></param>
        /// <returns></returns>
        private string formarQuerryAtributos(List<string> pLista, bool pValores) {
            string resultado = "(";
            char[] caracter_A_eliminar = { ',', ' '};
            
            for (int indice = 0; indice < pLista.Count; indice++) {
              
                if (pValores)
                {
                    string parametroLista = pLista[indice];
                    long numero = 0;
                    bool canConvert = long.TryParse(parametroLista, out numero);

                    if (canConvert)
                    {
                        resultado += numero + ", ";
                    }
                    else
                    {
                        resultado += "'" + parametroLista + "', ";
                    }
                }
                else {

                    resultado += pLista[indice] + ", ";
                }

            }
             resultado = resultado.TrimEnd(caracter_A_eliminar)+")";  // Elimina la basura del string
            return resultado;            
        }//END FORMAR QUERRY ATRIBUTOS
        
        /// <summary>
        /// Inserta valores a cualquier tabla de la base de datos mediante el ingreso de nombre de 
        /// la tabla y mediante la lista de valores ingresados.
        /// </summary>
        /// <param name="pNombreTabla"></param>
        /// <param name="pValores"></param>
        /// <returns></returns>
        public string insertarDatoTabla(string pNombreTabla, List<string> pValores) {
            string columnas = formarQuerryAtributos(obtenerNombreColumnas(pNombreTabla),false);
            string valores  = formarQuerryAtributos(pValores,true);
            string querry = "insert into " + pNombreTabla + " " + columnas + " values " + valores;
            
            try
            {
                string conecto = abrirConexionBase();
                MySqlCommand comando = new MySqlCommand(string.Format(querry), mscConexion);
                comando.ExecuteNonQuery();
                cerrarConexionBase();
                return "Exitosa";
            }
            catch (Exception error) {
                return error.Message;
            }
            
        }//END INSERTAR DATO TABLA
            
        /// <summary>
        /// Obtiene el nombre de las columnas de una tabla
        /// </summary>
        /// <param name="pNombreTabla"></param>
        /// <returns></returns>
        public List<string> obtenerNombreColumnas(string pNombreTabla) {
            List<string> resultado = new List<string>();
            try {
                string querry = "use "+strNombreBase+"; describe "+pNombreTabla;

                MySqlCommand comando = new MySqlCommand(String.Format(querry), mscConexion);
                MySqlDataReader lector = comando.ExecuteReader();

                while (lector.Read()) {
                    resultado.Add(lector.GetString(0));
                }
                return resultado;
            }
            catch (Exception) {
                return resultado;
            }
            
        }//END OBTENER NOMBRE COLUMNAS

        /// <summary>
        /// Crea una tabla a la base de datos.
        /// </summary>
        /// <param name="pNombre"></param>
        /// <param name="pColumnas"></param>
        /// <param name="pTipo"></param>
        /// <returns></returns>
        public string crearTabla(string pNombre, List<string> pColumnas, List<string> pTipo)
        {

            string strQuerry = "create table " + pNombre + " (";
            for (int indice = 0; indice < pColumnas.Count; indice++)
            {
                strQuerry += pColumnas[indice] + " " + pTipo[indice] + " NOT NULL,";
            }
            strQuerry += "primary key(" + pColumnas[0] + "));";
            try
            {
                abrirConexionBase();
                MySqlCommand comando = new MySqlCommand(string.Format(strQuerry), mscConexion);
                comando.ExecuteNonQuery();
                cerrarConexionBase();

                return "Exitosa";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        #region Getter and Setters
            
            public string getNombreBase(){
                return strNombreBase;
            }

            public void setNombreBase(string pNombreBase){
                strNombreBase = pNombreBase;
            }

        #endregion

    }//END CLASE
}