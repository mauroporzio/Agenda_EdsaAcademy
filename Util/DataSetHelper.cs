using System.Data;

namespace Util
{
    public static class DataSetHelper
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
