using Agenda.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using Util;

namespace Agenda.BLL
{
    public class GeneroDropDownList : IDisposable
    {
        public List<String> getListaGenero()
        {
            try
            {
                using (GeneroDAL dal = new GeneroDAL())
                {
                    var connection = dal.AbrirConexion();
                    DataSet ds = dal.EjecutarQueryGeneroADataSet(connection);
                    return DataSetAListaGenero(ds);
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
        public List<String> DataSetAListaGenero(DataSet ds)
        {
            List<String> listaPaises = new List<string>();

            if (DataSetHelper.HasRecords(ds))
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    listaPaises.Add(DataRowAGenero(row));
                }
                return listaPaises;
            }
            else
            {
                return null;
            }
        }
        public String DataRowAGenero(DataRow row)
        {
            return row["Valor"].ToString();
        }
        public void Dispose()
        {

        }
    }
}
