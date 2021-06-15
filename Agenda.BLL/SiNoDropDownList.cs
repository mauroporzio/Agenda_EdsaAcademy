using System;
using System.Collections.Generic;
using Agenda.DAL;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using System.Data;

namespace Agenda.BLL
{
    public class SiNoDropDownList : IDisposable
    {
        public List<String> getListaPaises()
        {
            try
            {
                using (SiNoDAL dal = new SiNoDAL())
                {
                    var connection = dal.AbrirConexion();
                    DataSet ds = dal.EjecutarQuerySiNoADataSet(connection);
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
                    listaPaises.Add(DataRowASiNo(row));
                }
                return listaPaises;
            }
            else
            {
                return null;
            }
        }
        public String DataRowASiNo(DataRow row)
        {
            return row["Valor"].ToString();
        }
        public void Dispose()
        {

        }
    }
}
