using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Domen
{
    public class ReviewInstitution : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<ReviewInstitution>
    {
        public long IdReviewInstitution { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string SQLTableName => "ReviewInstitution";
        public string InsertSQLValues => $"'{Name}', '{Description}'";
        public string[] DataGridViewColumnsToIgnore => ["IdReviewInstitution", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdReviewInstitution={IdReviewInstitution}";
        public string SetSQLCondition => $"Name='{Name}', Description='{Description}'";
        public string WhereSQLCondition => $"Name LIKE '%{Name}%' AND Description LIKE '%{Description}%'";
        public string SelectSQLCondition => $"* FROM {SQLTableName}";

        public static ReviewInstitution CreateInstance()
        {
            return new ReviewInstitution();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                ReviewInstitution reviewInstitution = new ReviewInstitution();
                reviewInstitution.IdReviewInstitution = (long)reader["IdReviewInstitution"];
                reviewInstitution.Name = (string)reader["Name"];
                reviewInstitution.Description = reader["Description"] is DBNull ? null : (string)reader["Description"];
                entities.Add(reviewInstitution);
            }
            return entities;
        }

        public override string ToString() => Name;
    }
}
