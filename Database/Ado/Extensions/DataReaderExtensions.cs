using System.Data.Common;

namespace DormAPI.Database.Ado.Extensions
{
    public static class DataReaderExtensions
    {
        public static bool HasColumn(this DbDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName) >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
