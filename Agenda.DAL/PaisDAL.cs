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
    public class PaisDAL : IDisposable
    {
        public SqlConnection connection;

        string connString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString; // PATH DEL CONNECTION PROVENIENTE DEL WEB.CONFIG
        public PaisDAL()
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
        public DataSet EjecutarQueryPaisesADataSet(SqlConnection connection)
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = new SqlCommand
                {
                    Connection = connection,
                    CommandType = CommandType.Text,
                    CommandText = "SELECT * FROM Pais"
                };

                DataSet dataSetResultado = new DataSet();

                dataAdapter.Fill(dataSetResultado);

                return dataSetResultado;
            }
        }// SE RECIBE LA TABLE DE PAISES DESDE LA BASE Y SE RETORNA SU CONTENIDO COMO DATASET, PARA LUEGO SER PASADO A UNA LISTA EN EL BLL.
        public void Dispose() //DISPOSE PARA LIBERAR RECURSOS CUANDO YA NO SE NECESITEN.
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
