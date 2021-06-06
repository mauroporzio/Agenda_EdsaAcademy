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
    public class AreaDropDownList : IDisposable
    {
        public List<String> getListaAreas()
        {
            try
            {
                using (AreaDAL dal = new AreaDAL())
                {
                    var connection = dal.AbrirConexion();
                    DataSet ds = dal.EjecutarQueryAreasADataSet(connection);
                    return DataSetAListaAreas(ds);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Message: { e.Message }");
                //AGREGAR LOGGER.
                return null;
            }
        }
        public List<String> DataSetAListaAreas(DataSet ds)
        {
            List<String> listaPaises = new List<string>();

            if (DataSetHelper.HasRecords(ds))
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    listaPaises.Add(DataRowAArea(row));
                }
                return listaPaises;
            }
            else
            {
                return null;
            }
        }
        public String DataRowAArea(DataRow row)
        {
            return row["NombreArea"].ToString();
        }
        public void Dispose()
        {

        }
    }
}
