using System.Data;

namespace Util
{
    class DataSetHelper
    {
        public static bool HasRecords(DataSet ds)
        {
            return
                ds != null
                && ds.Tables.Count > 0
                && ds.Tables[0].Rows.Count > 0;
        }
    }
}
