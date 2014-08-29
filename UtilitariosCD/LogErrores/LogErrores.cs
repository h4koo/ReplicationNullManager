using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosCD.Constantes;
using System.IO;
using System.Configuration;
using System.Configuration;

namespace UtilitariosCD.LogErrores
{
    public class LogErrores
    {
        /*
         * Constructor 
         */
        public LogErrores()
        {
        }

        #region Métodos Públicos        


        /*******************************************************************
         * Fecha: 03/08/2014
         * Responsable: José Hernández Moya
         * Descripción: Este método escribe el un archivo para el día actual
         * en nombre de la clase y el método donde ocurrió el error junto con
         * la descripción del mismo.
         ******************************************************************/
        public void GuardarLog(IConstantes.TIPOCAPA pintTipoCapa, string pstrNombClase, string pstrNombMetodo, string pstrMensaje)
        {
            string strRutaLog = string.Empty;
            string strMsjLog = string.Empty;            

            try
            {                
                //Armamos la ruta donde se guardará el log con la fecha actual
                strRutaLog += ConfigurationManager.AppSettings["RutaLogErrores"];
                strRutaLog += "LogErrores_" + ObtenerNombreCapa(pintTipoCapa) + " ";
                strRutaLog += DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";

                //Construimos el mensaje de error
                strMsjLog += " ********************************************************************" + Environment.NewLine;
                strMsjLog += " * Fecha y hora: " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + Environment.NewLine;
                strMsjLog += " * Nombre de la clase: " + pstrNombClase + Environment.NewLine;
                strMsjLog += " * Nombre del método: " + pstrNombMetodo + Environment.NewLine;
                strMsjLog += " * Error: " + pstrMensaje + Environment.NewLine;
                strMsjLog += " ********************************************************************" + Environment.NewLine;


                //Guardamos el archivo
                System.IO.File.AppendAllText(@strRutaLog, strMsjLog);

            }
            catch (Exception ex)
            {
                //Solo ataja el error para que la aplicación no se caiga.
            }
            finally
            {
                //Limpiamos las variables para ayudar al "Garbage Collection"
                strRutaLog = null;
                strMsjLog = null;
            }

        }


        /*******************************************************************
         * Fecha: 03/08/2014
         * Responsable: José Hernández Moya
         * Descripción: Este método escribe el un archivo para el día actual
         * en nombre de la clase y el método donde ocurrió el error junto con
         * la descripción del mismo y el query a ejecutar.
         ******************************************************************/
        public void GuardarLog(IConstantes.TIPOCAPA pintTipoCapa, string pstrNombClase, string pstrNombMetodo, string pstrMensaje, string pstrQuery)
        {
            string strRutaLog = string.Empty;
            string strMsjLog = string.Empty;

            try
            {
                //Armamos la ruta donde se guardará el log con la fecha actual
                strRutaLog = ConfigurationManager.AppSettings["RutaLogErrores"];
                strRutaLog += "LogErrores_" + ObtenerNombreCapa(pintTipoCapa) + " ";
                strRutaLog += DateTime.Now.ToString("dd-MMM-yyyy") + ".txt";

                //Construimos el mensaje de error
                strMsjLog += " ********************************************************************" + Environment.NewLine;
                strMsjLog += " * Fecha y hora: " + DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + Environment.NewLine;
                strMsjLog += " * Nombre de la clase: " + pstrNombClase + Environment.NewLine;
                strMsjLog += " * Nombre del método: " + pstrNombMetodo + Environment.NewLine;
                strMsjLog += " * Query: " + pstrQuery + Environment.NewLine;
                strMsjLog += " * Error: " + pstrMensaje + Environment.NewLine;
                strMsjLog += " ********************************************************************" + Environment.NewLine;


                //Guardamos el archivo
                System.IO.File.AppendAllText(@strRutaLog, strMsjLog);

            }
            catch
            {
                //Solo ataja el error para que la aplicación no se caiga.
            }
            finally
            {
                //Limpiamos las variables para ayudar al "Garbage Collection"
                strRutaLog = null;
                strMsjLog = null;
            }

        }

        #endregion


        #region Métodos Privados


        /*******************************************************************
         * Fecha: 03/08/2014
         * Responsable: José Hernández Moya
         * Descripción: Este método devuelve el nombre de la capa según el
         * tipo de la misma.
         ******************************************************************/
        private string ObtenerNombreCapa(IConstantes.TIPOCAPA pintTipoCapa)
        {
            string strNombreCapa = string.Empty;

            try
            {
                switch (pintTipoCapa)
                {
                    case IConstantes.TIPOCAPA.WEB:
                        strNombreCapa = "CargoDispatcherWeb";
                        break;
                    case IConstantes.TIPOCAPA.MOVIL:
                        strNombreCapa = "CargoDispatcherMovil";
                        break;
                    case IConstantes.TIPOCAPA.ACCESODATOS:
                        strNombreCapa = "CargoDispatcherAD";
                        break;
                    case IConstantes.TIPOCAPA.LOGICANEGOCIOS:
                        strNombreCapa = "CargoDispatcherLN";
                        break;
                    case IConstantes.TIPOCAPA.ACCESOSERVICIO:
                        strNombreCapa = "CargoDispatcherAS";
                        break;
                }                    
            }
            catch
            {
                //Solo ataja el error para que la aplicación no se caiga.
            }

            return strNombreCapa;
        }

        #endregion

    }
}
