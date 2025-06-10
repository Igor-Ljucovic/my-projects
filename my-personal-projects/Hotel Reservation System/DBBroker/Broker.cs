
using Common.Domain;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;


namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }

        public void OpenConnection() => connection.OpenConnection();
        public void CloseConnection() => connection.CloseConnection();

        public void BeginTransaction() => connection.BeginTransaction();

        public void Commit() => connection.Commit();
        public void Rollback() => connection.Rollback();


        public void Add<EntityType>(string values)
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.SQLTableName} VALUES({values})";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public long AddAndGetID<EntityType>(string values, string idColumnName)
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.SQLTableName} OUTPUT INSERTED.{idColumnName} VALUES({values})";
            long id = (long)cmd.ExecuteScalar();
            cmd.Dispose();
            return id;
        }

        public List<IEntity> GetAll<EntityType>()
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM {entity.SQLTableName}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public List<IEntity> CompleteSQLQuery<EntityType>(string completeSQLQuery)
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = completeSQLQuery;
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public List<IEntity> GetAllByConditions<EntityType>(string selectCondition, string whereConditions)
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT {selectCondition} WHERE {whereConditions}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();
            return list;
        }

        public IEntity GetOneByConditions<EntityType>(string selectConditions, string primaryKeyWhereConditions)
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT {selectConditions} WHERE {primaryKeyWhereConditions}";
            using SqlDataReader reader = command.ExecuteReader();
            List<IEntity> list = entity.GetReaderList(reader);
            command.Dispose();

            if (list.Count == 0)
                throw new Exception("No elements were found with the given conditions.");
            else if (list.Count > 1)
                throw new Exception("More than one element was found with the given conditions.");

            return list[0];
        }

        public void Update<EntityType>(string columnsToUpdate, string whereConditions)
            where EntityType : IEntity, new()
        {
            EntityType entity = new EntityType();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE {entity.SQLTableName} SET {columnsToUpdate} WHERE {whereConditions}";
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void Delete<EntityType>(string deleteConditions)
            where EntityType : IEntity, new()
        {
            try
            {
                EntityType entity = new EntityType();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {entity.SQLTableName} WHERE {deleteConditions}";
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                    throw new Exception("You cannot delete this object because other objects in the system depend on it.");
            }
        }
    }
}
