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

        string connString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;
        public  AreaDAL()
        {
            connection = new SqlConnection(connString);
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
        public DataSet EjecutarQueryAreasADataSet(SqlConnection connection)
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM Area"
                };

                DataSet dataSetResultado = new DataSet();

                dataAdapter.Fill(dataSetResultado);

                return dataSetResultado;
            }
        }
        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
