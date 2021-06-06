using Agenda.DAL;
using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Util;

namespace Agenda.BLL
{
    public class AgendaContactos : IAgendaContactos
    {
        public Contacto getContactoById(Contacto contactoBuscar)
        {
            try
            {
                using (AgendaContactosDAL dal = new AgendaContactosDAL())
                {
                    var connection = dal.AbrirConexion();
                    DataSet ds = dal.EjecutarQueryDevolverContactPorId(connection, contactoBuscar.id);
                    return DataSetAListaContacto(ds).First();
                }
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
        public List<Contacto> getlistaContactosPorFiltro(List<FiltroContacto> listaFiltros) // SI LE PASAS LISTA VACIA RETORNA TODOS LOS CONTACTOS.
        {
            try
            { 
                using (AgendaContactosDAL dal = new AgendaContactosDAL())
                {
                    var connection = dal.AbrirConexion();
                    DataSet ds = dal.EjecutarQueryConsultarContactoAdataSet(connection, listaFiltros);
                    return DataSetAListaContacto(ds);
                }
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
        public void insertarContacto(Contacto contactoInsertar)
        {
            using (AgendaContactosDAL dal = new AgendaContactosDAL())
            {
                var connection = dal.AbrirConexion();
                SqlTransaction transaccion = connection.BeginTransaction();

                try
                {
                    StringBuilder nonNonQwerySentence = new StringBuilder();

                    nonNonQwerySentence.Append("DECLARE @Id INT ");
                    nonNonQwerySentence.Append("EXEC InsertarContacto ");
                    nonNonQwerySentence.Append( "@Id OUTPUT" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.apellidoYnombre + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.genero + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.pais + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.localidad + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.contactoInterno + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.organizacion + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.area + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.activo + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.direccion + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.telefonoFijoInterno + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.telefonoCelular + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.eMail + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoInsertar.cuentaSkype + "'" + ",");
                    nonNonQwerySentence.Append("'" + "insertarContacto()" + "'");

                    dal.EjecutarExecuteNonQueryConTransaccion(transaccion, connection, nonNonQwerySentence.ToString());

                    transaccion.Commit();
                }
                catch (Exception e)
                {
                    transaccion.Rollback();
                    using (LogHelper logger = new LogHelper())
                    {
                        logger.log(e.Message);
                    }
                }
                finally
                {
                    transaccion.Dispose();
                }
            }
        }
        public void modificarContacto(Contacto contactoModificar) //LLEGA EL CONTACTO YA MODIFICADO PERO MANTIENE EL ID
        {
            using (AgendaContactosDAL dal = new AgendaContactosDAL())
            {
                var connection = dal.AbrirConexion();
                SqlTransaction transaccion = connection.BeginTransaction();

                try
                {
                    StringBuilder nonNonQwerySentence = new StringBuilder();

                    nonNonQwerySentence.Append("EXEC EditarContacto ");
                    nonNonQwerySentence.Append(contactoModificar.id + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.apellidoYnombre + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.genero + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.pais + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.localidad + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.contactoInterno + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.organizacion + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.area + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.activo + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.direccion + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.telefonoFijoInterno + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.telefonoCelular + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.eMail + "'" + ",");
                    nonNonQwerySentence.Append("'" + contactoModificar.cuentaSkype + "'" + ",");
                    nonNonQwerySentence.Append("'" + "modificarContacto()" + "'");

                    dal.EjecutarExecuteNonQueryConTransaccion(transaccion, connection, nonNonQwerySentence.ToString());

                    transaccion.Commit();
                }
                catch (Exception e)
                {
                    transaccion.Rollback();
                    using (LogHelper logger = new LogHelper())
                    {
                        logger.log(e.Message);
                    }
                }
                finally
                {
                    transaccion.Dispose();
                }
            }
        }
        public void eliminarContacto(Contacto contactoEliminar)
        {
            using (AgendaContactosDAL dal = new AgendaContactosDAL())
            {
                var connection = dal.AbrirConexion();
                SqlTransaction transaccion = connection.BeginTransaction();

                try
                {
                    string nonNonQwerySentence = "EXEC BorrarContacto " + contactoEliminar.id;

                    dal.EjecutarExecuteNonQueryConTransaccion(transaccion, connection, nonNonQwerySentence);

                    transaccion.Commit();
                }
                catch (Exception e)
                {
                    transaccion.Rollback();
                    using (LogHelper logger = new LogHelper())
                    {
                        logger.log(e.Message);
                    }
                }
                finally
                {
                    transaccion.Dispose();
                }
            }
        }
        
        private List<Contacto> DataSetAListaContacto(DataSet dataSet) // retorna una lista de contactos provenientes del data set pasado por param.
        {
            List<Contacto> listaContacto = new List<Contacto>();

            if (DataSetHelper.HasRecords(dataSet))
            {
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    listaContacto.Add(DataRowAContacto(row));
                }
                return listaContacto;
            }
            else
            {
                return null;
            }
        }
        private Contacto DataRowAContacto (DataRow row) // mapea la fila dada en un contacto y lo retorna.
        {
            return new Contacto()
            {
                id = Convert.ToInt32(row["Id"]),
                apellidoYnombre = Convert.ToString(row["ApellidoYNombre"]),
                genero = Convert.ToString(row["Genero"]),
                pais = Convert.ToString(row["Pais"]),
                localidad = Convert.IsDBNull(row["Localidad"]) ? null : Convert.ToString(row["Localidad"]),
                contactoInterno = Convert.ToString(row["ContactoInterno"]),
                organizacion = Convert.IsDBNull(row["Organizacion"]) ? null : Convert.ToString(row["Organizacion"]),
                area = Convert.IsDBNull(row["Area"]) ? null : Convert.ToString(row["Area"]),
                activo = Convert.ToString(row["Activo"]),
                direccion = Convert.IsDBNull(row["Direccion"]) ? null : Convert.ToString(row["Direccion"]),
                telefonoFijoInterno = Convert.IsDBNull(row["TelefonoFijoInterno"]) ? null : Convert.ToString(row["TelefonoFijoInterno"]),
                telefonoCelular = Convert.IsDBNull(row["TelefonoCelular"]) ? null : Convert.ToString(row["TelefonoCelular"]),
                eMail = Convert.ToString(row["Email"]),
                cuentaSkype = Convert.IsDBNull(row["CuentaSkype"]) ? null : Convert.ToString(row["CuentaSkype"]),
                fechaIngreso = Convert.ToDateTime(row["FechaAltaReg"])
            };
        }

        public void Dispose()
        {
            
        }
    }
}
