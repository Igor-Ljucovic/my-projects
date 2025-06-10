using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Domen
{
    public class Location : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<Location>
    {
        public long IdLocation { get; set; }
        public string Address { get; set; }

        public string SQLTableName => "Location";
        public string InsertSQLValues => $"'{Address}'";
        public string[] DataGridViewColumnsToIgnore => ["IdLocation", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdLocation={IdLocation}";
        public string SetSQLCondition => $"Address='{Address}'";
        public string WhereSQLCondition => $"Address LIKE '%{Address}%'";
        public string SelectSQLCondition => $"* FROM {SQLTableName}";

        public static Location CreateInstance()
        {
            return new Location();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Location location = new Location();
                location.IdLocation = (long)reader["IdLocation"];
                location.Address = (string)reader["Address"];
                entities.Add(location);
            }
            return entities;
        }

        public override string ToString() => Address;
    }
}
