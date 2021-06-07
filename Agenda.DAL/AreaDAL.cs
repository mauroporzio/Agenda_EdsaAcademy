using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Agenda.DAL
{
    public class AreaDAL : IDisposable
    {
        public SqlConnection connection;

        string connString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString; // SE RECIBE EL PATH DE LA CONNECTION.
        public  AreaDAL()
        {
            connection = new SqlConnection(connString); // SE ASIGNA EL PATH.
        }
        public SqlConnection AbrirConexion()
        {
            try
            {
                connection.Open();
                Debug.WriteLine("Se creo la conexión exitosamente");
                return connection;
            }
            catch (Exception e)
            {
                using (LogHelper logger = new LogHelper())
                {
                    logger.log(e.Message);
                }
                return null;
            }
        }
        public DataSet EjecutarQueryAreasADataSet(SqlConnection connection) // SE RECIBE LA TABLA DE AREA PARA PASARLA A UN DATA SET, EL CUAL LUEGO SE CONVERTIRA EN UNA LISTA EN EL BLL.
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM Area" // SE ASIGNA EL SQLCOMMAND
                };

                DataSet dataSetResultado = new DataSet();

                dataAdapter.Fill(dataSetResultado);  // SE LLENA EL DATASET

                return dataSetResultado;// SE RETORNA.
            }
        }
        public void Dispose() // DISPOSE PARA LIBERAR LOS RECURSOS CUANDO YA NO SEAN REQUERIDOS.
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
