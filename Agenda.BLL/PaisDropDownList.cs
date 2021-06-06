using Agenda.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Agenda.BLL
{
    public class PaisDropDownList : IDisposable
    {
        public List<String> getListaPaises()
        {
            try
            {
                using (PaisDAL dal = new PaisDAL())
                {
                    var connection = dal.AbrirConexion();
                    DataSet ds = dal.EjecutarQueryPaisesADataSet(connection);
                    return DataSetAListaPaises(ds);
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
        public List<String> DataSetAListaPaises(DataSet ds)
        {
            List<String> listaPaises = new List<string>();

            if (DataSetHelper.HasRecords(ds))
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    listaPaises.Add(DataRowAPais(row));
                }
                return listaPaises;
            }
            else
            {
                return null;
            }
        }
        public String DataRowAPais(DataRow row)
        {
            return row["NombrePais"].ToString();
        }
        public void Dispose()
        {
           
        }
    }
}
