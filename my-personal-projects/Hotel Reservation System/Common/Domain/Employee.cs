using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Domen
{
    public class Employee : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<Employee>
    {
        public long IdEmployee { set; get; }
        public string Email { set; get; } 
        public string PhoneNumber { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public long IdHotel { set; get; }

        public string SQLTableName => "Employee";
        public string InsertSQLValues => $"'{Email}', '{PhoneNumber}', '{Username}', '{Password}', {IdHotel}";
        public string[] DataGridViewColumnsToIgnore => ["IdEmployee", "Password", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"username='{Username}' and password='{Password}'";
        public string SetSQLCondition => $"Email='{Email}', PhoneNumber='{PhoneNumber}', Username='{Username}', Password={Password}, IdHotel={IdHotel}";
        public string WhereSQLCondition => $"Email LIKE '%{Email}%' AND PhoneNumber LIKE '%{PhoneNumber}%' AND Username LIKE '%{Username}%'";
        public string SelectSQLCondition => $"* FROM {SQLTableName}";

        public static Employee CreateInstance()
        {
            return new Employee();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Employee zaposleni = new Employee();
                zaposleni.IdEmployee = (long)reader["IdEmployee"];
                zaposleni.Email = (string)reader["Email"];
                zaposleni.PhoneNumber = (string)reader["PhoneNumber"];
                zaposleni.Username = (string)reader["Username"];
                zaposleni.Password = (string)reader["Password"];
                zaposleni.IdHotel = (long)reader["IdHotel"];
                entities.Add(zaposleni);
            }
            return entities;
        }

        public List<IEntity> GetUsernameAndPassword(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Employee zaposleni = new Employee();
                zaposleni.Username = (string)reader["Username"];
                zaposleni.Password = (string)reader["Password"];
                entities.Add(zaposleni);
            }
            return entities;
        }
    }
}
