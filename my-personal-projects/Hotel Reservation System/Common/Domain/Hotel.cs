using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Domen
{
    public class Hotel : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<Hotel>
    {
        public long IdHotel { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }

        public string SQLTableName => "Hotel";
        public string InsertSQLValues => $"'{Name}', '{Email}', '{PhoneNumber}', '{Address}', '{Website}'";
        public string[] DataGridViewColumnsToIgnore => ["IdHotel", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdHotel={IdHotel}";
        public string SetSQLCondition => $"Name='{Name}', Email='{Email}', PhoneNumber='{PhoneNumber}', Address='{Address}', Website='{Website}'";
        public string WhereSQLCondition => $"Name LIKE '%{Name}%' AND Email LIKE '%{Email}%' AND PhoneNumber LIKE '%{PhoneNumber}%' AND Address LIKE '%{Address}%' AND Website LIKE '%{Website}%'";
        public string SelectSQLCondition => $"* FROM {SQLTableName}";

        public static Hotel CreateInstance()
        {
            return new Hotel();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Hotel hotel = new Hotel();
                hotel.IdHotel = (long)reader["IdHotel"];
                hotel.Name = (string)reader["Name"];
                hotel.Email = (string)reader["Email"];
                hotel.PhoneNumber = (string)reader["PhoneNumber"];
                hotel.Address = (string)reader["Address"];
                hotel.Website = (string)reader["Website"];
                entities.Add(hotel);
            }
            return entities;
        }

        public override string ToString() => Name;
    }
}
