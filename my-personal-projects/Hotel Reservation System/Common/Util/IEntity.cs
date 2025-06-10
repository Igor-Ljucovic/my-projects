using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Common.Domain
{
    public interface IEntity
    {
        public string SQLTableName { get; }
        public string[] DataGridViewColumnsToIgnore { get;}
        public string PrimaryKeySQLCondition { get; }

        public List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
