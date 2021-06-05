using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Agenda.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL
{
    class AgendaContactosDAL : IDisposable
    {
        public SqlConnection connection;
        public AgendaContactosDAL()
        {
            connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.AppSettings["connectionDB"]
            };
        }
        public SqlConnection AbrirConexion()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Se creo la conexión exitosamente");
                return connection;
            }
            catch (Exception e)
            {
                //agregar LOGGER
                return null;
            }
        }
        public int EjecutarExecuteNonQueryConTransaccion(SqlTransaction transaction, SqlConnection connection, string nonNonQwerySentence)
        {
            SqlCommand sqlCommnad = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.Text,
                CommandText = nonNonQwerySentence
            };
            int registrosAfectados = sqlCommnad.ExecuteNonQuery();

            return registrosAfectados;
        }

        public DataSet EjecutarQueryConsultarContactoAdataSet(SqlConnection connection, List<FiltroContacto> listaFiltroContactos)
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = crearCommandConsultarContactos(connection, listaFiltroContactos);

                DataSet dataSetResultado = new DataSet();

                dataAdapter.Fill(dataSetResultado);

                return dataSetResultado;
            }
        }
        private SqlCommand crearCommandConsultarContactos(SqlConnection connection, List<FiltroContacto> listaFiltroContactos)
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "ConsultarContacto",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            List<SqlParameter> listaDeFiltros = new List<SqlParameter>();

            foreach (FiltroContacto filtro in listaFiltroContactos)
            {
                switch (filtro.idFiltro)
                {
                    case (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@ApellidoYNombre", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;

                    case (int)OPCIONES_FILTRO.LOCALIDAD:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@Localidad", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;

                    case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@fechaDeIngresoDesde", Value = filtro.valorFiltroDate, SqlDbType = SqlDbType.DateTime });
                        break;

                    case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@fechaDeIngresoHasta", Value = filtro.valorFiltroDate, SqlDbType = SqlDbType.DateTime });
                        break;

                    case (int)OPCIONES_FILTRO.CONTACTO_INTERNO:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@ContactoInterno", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;

                    case (int)OPCIONES_FILTRO.ORGANIZACION:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@Organizacion", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;

                    case (int)OPCIONES_FILTRO.AREA:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@Area", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;

                    case (int)OPCIONES_FILTRO.ACTIVO:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@Activo", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;
                    case (int)OPCIONES_FILTRO.PAIS:
                        listaDeFiltros.Add(new SqlParameter { ParameterName = "@Pais", Value = filtro.valorFiltro, SqlDbType = SqlDbType.VarChar });
                        break;
                    default:
                        break;
                }
            }

            sqlCommand.Parameters.AddRange(listaDeFiltros.ToArray());

            return sqlCommand;
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
