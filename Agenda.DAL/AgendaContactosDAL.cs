using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Agenda.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Util;

namespace Agenda.DAL
{
    public class AgendaContactosDAL : IDisposable
    {
        public SqlConnection connection;
        string connString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString; //LEGA EL PATH DE CONEXION DEL WEB.CONFIG. SERA UTILIZADO SOLO PARA CONSULTAS, NO PARA OPERACIONES QUE CAMBIEN LA BASE DE DATOS.
        public AgendaContactosDAL()
        {
            connection = new SqlConnection(connString); // ASIGNO EL PATH.
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
        public int EjecutarExecuteNonQuery(SqlConnection connection, string nonNonQwerySentence) // RECIBO UN NONQUERY PARA EJECUTAR.
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = nonNonQwerySentence
            };
            int registrosAfectados = cmd.ExecuteNonQuery();

            return registrosAfectados; // RETORNO EL NUMERO DE REGISTROS AFECTADOS, PUEDE GUARDARSE EN UNA VARIABLE SI SE DESEA.
        }
        public int EjecutarExecuteNonQueryConTransaccion(SqlTransaction transaction, SqlConnection connection, string nonNonQwerySentence) // RECIBO UN NONQUERY PERO ESTE SE PRESENTA EN UNA TRANSACCION. 
        {                                                                                                                                  // SERA UTILIZADO PARA OPERACIONES CON LA BASE QUE REFLEJEN CAMBIOS EN ELLA.
            SqlCommand sqlCommnad = new SqlCommand
            {
                Connection = transaction != null ? transaction.Connection : connection,
                Transaction = transaction,
                CommandType = CommandType.Text,
                CommandText = nonNonQwerySentence
            };
            int registrosAfectados = sqlCommnad.ExecuteNonQuery();

            return registrosAfectados; // RETORNO EL NUMERO DE REGISTROS AFECTADOS. NO ES NECESARIO GUARDARLO.
        }
        public DataSet EjecutarQueryConsultarContactoAdataSet(SqlConnection connection, List<FiltroContacto> listaFiltroContactos) // RECIBO LA CONNECTION Y UNA LISTA DE FILTROS QUE SERAN IMPLEMENTADOS PARA EL FILTRADO EN LA BASE. 
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = crearCommandConsultarContactos(connection, listaFiltroContactos); // CREO EL SQLCOMMNAD EN OTRO METODO, QUE RECIBIENDO LA LISTA, RETORNA EL COMANDO ARMADO.

                DataSet dataSetResultado = new DataSet();

                dataAdapter.Fill(dataSetResultado); // LLENO EL DATA SET CON LOS RESULTADOS.

                return dataSetResultado; // RETORNO EL DATA SET. PARA LUEGO SER VOLCADO A UNA LISTA DE CONTACTOS EN LA CAPA BLL.
            }
        }
        private SqlCommand crearCommandConsultarContactos(SqlConnection connection, List<FiltroContacto> listaFiltroContactos) // CREA EL SQLCOMMAND Y LO RETORNA EN BASE A LA LISTA DE FILTROS RECIBIDA.
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

            sqlCommand.Parameters.AddRange(listaDeFiltros.ToArray()); // SE AGREGA EL ARRAY DE PARAMETROS AL SQL COMMAND.

            return sqlCommand; // SE RETORNA EL COMANDO SQL.
        }
        public DataSet EjecutarQueryDevolverContactPorId(SqlConnection connection, int idBuscar) // RECIBO EL ID A BUSCAR PARA LUEGO GENERAR EL SQL COMMAND.
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
            {
                dataAdapter.SelectCommand = crearCommandDevolverContactPorId(connection, idBuscar); // LLAMO A LA FUNCION CON LA CONNECTION Y EL ID QUE LUEGO ME RETORNARA EL SQLCOMMAND ARAMDO.

                DataSet dataSetResultado = new DataSet();

                dataAdapter.Fill(dataSetResultado); // LLENO EL DATASET CON EL RESULTADO

                return dataSetResultado; // LO RETORNO.
            }
        }
        private SqlCommand crearCommandDevolverContactPorId(SqlConnection connection, int idBuscar) // RECIBO EL ID Y LA CONNECTION PARA DEVOLVER EL SQL COMMAND ARMADO.
        {
            SqlCommand sqlCommand = new SqlCommand
            {
                CommandText = "DevolverContactoPorId",
                CommandType = CommandType.StoredProcedure,
                Connection = connection
            };

            sqlCommand.Parameters.Add(new SqlParameter() {ParameterName = "@Id", Value = idBuscar, SqlDbType = SqlDbType.Int }); // AGREGO EL ID COMO PARAM.

            return sqlCommand;// RETORNO EL SQLCOMMAND.
        }
        public void Dispose() // DISPOSE DE LA CONNECTION PARA UNA VEZ QUE SE UTILIZE SE LIBEREN LOS RECURSOS.
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
