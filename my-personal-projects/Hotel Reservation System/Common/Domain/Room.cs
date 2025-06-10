using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Domen
{
    public class Room : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<Room>
    {
        public long IdRoom { get; set; }
        public string RoomNumber { get; set; }
        public RoomType RoomType { get; set; }
        public float NightPriceInDinars { get; set; }
        public int SurfaceInm2 { get; set; }
        public Hotel Hotel { get; set; }

        public string SQLTableName => "Room";
        public string InsertSQLValues => $"'{RoomNumber}', '{RoomType}', {NightPriceInDinars}, {SurfaceInm2}, {Hotel.IdHotel}";
        public string[] DataGridViewColumnsToIgnore => ["IdRoom", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdRoom={IdRoom}";
        public string SetSQLCondition => $"RoomNumber='{RoomNumber}', RoomType='{RoomType}', NightPriceInDinars={NightPriceInDinars}, SurfaceInm2={SurfaceInm2}, IdHotel={Hotel.IdHotel}";
        public string WhereSQLCondition => $"1=1";
        public string SelectSQLCondition =>
            $"idRoom, " +
            $"roomNumber, " +
            $"roomType, " +
            $"nightPriceInDinars, " +
            $"surfaceInm2, " +
            $"{SQLTableName}.idHotel as {SQLTableName}IdHotel, " +
            $"{Hotel.SQLTableName}.idHotel as {Hotel.SQLTableName}IdHotel, " +
            $"name, " +
            $"email, " +
            $"phoneNumber, " +
            $"address, " +
            $"website " +
        $"from {SQLTableName} " +
        $"inner join {Hotel.SQLTableName} on {SQLTableName}.idHotel = {Hotel.SQLTableName}.idHotel";

        public static Room CreateInstance()
        {
            return new Room
            {
                Hotel = Hotel.CreateInstance()
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Room room = new Room();
                Hotel hotel = new Hotel();

                hotel.IdHotel = (long)reader["HotelIdHotel"];
                hotel.Name = (string)reader["Name"];
                hotel.Email = (string)reader["Email"];
                hotel.PhoneNumber = (string)reader["PhoneNumber"];
                hotel.Address = (string)reader["Address"];
                hotel.Website = (string)reader["Website"];

                room.IdRoom = (long)reader["IdRoom"];
                room.RoomNumber = (string)reader["RoomNumber"];
                room.RoomType = Enum.Parse<RoomType>(reader["RoomType"].ToString());
                room.NightPriceInDinars = Convert.ToSingle(reader["NightPriceInDinars"]);
                room.SurfaceInm2 = (int)reader["SurfaceInm2"];
                room.Hotel = hotel;

                entities.Add(room);
            }
            return entities;
        }

        public override string ToString() => RoomNumber;
    }
}
