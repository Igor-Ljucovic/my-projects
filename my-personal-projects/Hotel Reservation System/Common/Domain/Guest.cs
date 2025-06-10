using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Domen
{
    public class Guest : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<Guest>
    {
        public long IdGuest { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Location Location { get; set; }

        public string SQLTableName => "Guest";
        public string InsertSQLValues => $"'{Name}', '{Surname}', '{Email}', {(string.IsNullOrEmpty(PhoneNumber) ? $"'{PhoneNumber}'" : "NULL")}, {Location.IdLocation}";
        public string[] DataGridViewColumnsToIgnore => ["IdGuest", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdGuest={IdGuest}";
        public string SetSQLCondition => $"Name='{Name}', Surname='{Surname}', Email='{Email}'" + (string.IsNullOrEmpty(PhoneNumber) ? "" : $", PhoneNumber='{PhoneNumber}'") + $", IdLocation={Location.IdLocation}";
        public string WhereSQLCondition => $"Name LIKE '%{Name}%' AND Surname LIKE '%{Surname}%' AND Email LIKE '%{Email}%' AND PhoneNumber LIKE '%{PhoneNumber}%'" + (Location == null || Location.IdLocation == 0 ? "" : $" AND guest.IdLocation={Location.IdLocation}");
        public string SelectSQLCondition => 
            $"idGuest, " +
            $"name, " +
            $"surname, " +
            $"email, " +
            $"phoneNumber, " +
            $"{SQLTableName}.idLocation as {SQLTableName}IdLocation, " +
            $"{Location.SQLTableName}.idLocation as {Location.SQLTableName}IdLocation, " +
            $"address " +
        $"from {SQLTableName} " +
        $"inner join {Location.SQLTableName} on {SQLTableName}.idLocation = {Location.SQLTableName}.idLocation";

        static public Guest CreateInstance()
        {
            return new Guest
            {
                Location = Location.CreateInstance()
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Guest guest = new Guest();
                Location location = new Location();

                location.IdLocation = (long)reader["GuestIdLocation"];
                location.Address = (string)reader["Address"];

                guest.IdGuest = (long)reader["IdGuest"];
                guest.Name = (string)reader["Name"];
                guest.Surname = (string)reader["Surname"];
                guest.Email = (string)reader["Email"];
                guest.PhoneNumber = reader["PhoneNumber"] is DBNull ? null : (string)reader["PhoneNumber"];
                guest.Location = location;

                entities.Add(guest);
            }
            return entities;
        }

        public override string ToString() => $"{Name} {Surname} ({Email})";
    }
}
