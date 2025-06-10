using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Domen
{
    public class Reservation : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<Reservation>
    {
        public List<ReservationItem> ReservationItems { get; set; }
        public long IdReservation { get; set; }
        public float TotalPriceInDinars { get; set; }
        public DateTime CreationDate { get; set; }
        public Hotel Hotel { get; set; }
        public Guest Guest { get; set; }
        

        public string SQLTableName => "Reservation";
        public string InsertSQLValues => $"{TotalPriceInDinars}, '{CreationDate}', {Hotel.IdHotel}, {Guest.IdGuest}";
        public string[] DataGridViewColumnsToIgnore => ["IdReservation", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdReservation={IdReservation}";
        public string SetSQLCondition => $"TotalPriceInDinars={TotalPriceInDinars}, CreationDate='{CreationDate}', IdHotel={Hotel.IdHotel}, IdGuest={Guest.IdGuest}";
        public string WhereSQLCondition => $"1=1";
        public string SelectSQLCondition =>
                $"idReservation, " +
                $"totalPriceInDinars, " +
                $"creationDate, " +
                $"{Guest.SQLTableName}.idGuest as {Guest.SQLTableName}IdGuest, " +
                $"{Hotel.SQLTableName}.idHotel as {Hotel.SQLTableName}IdHotel, " +
                $"{Guest.Location.SQLTableName}.idLocation as {Guest.Location.SQLTableName}IdLocation, " +
                $"{Hotel.SQLTableName}.name as {Hotel.SQLTableName}Name, " +
                $"{Hotel.SQLTableName}.email as {Hotel.SQLTableName}Email, " +
                $"{Hotel.SQLTableName}.phoneNumber as {Hotel.SQLTableName}PhoneNumber, " +
                $"{Hotel.SQLTableName}.address as {Hotel.SQLTableName}Address, " +
                $"website, " +
                $"{Guest.SQLTableName}.name as {Guest.SQLTableName}Name, " +
                $"surname, " +
                $"{Guest.SQLTableName}.email as {Guest.SQLTableName}Email, " +
                $"{Guest.SQLTableName}.phoneNumber as {Guest.SQLTableName}PhoneNumber, " +
                $"{Guest.Location.SQLTableName}.address as {Guest.Location.SQLTableName}Address " +
            $"from {SQLTableName} " +
            $"join {Hotel.SQLTableName} on {Hotel.SQLTableName}.idHotel={SQLTableName}.idHotel " +
            $"join {Guest.SQLTableName} on {Guest.SQLTableName}.idGuest=  {SQLTableName}.idGuest " +
            $"join {Guest.Location.SQLTableName} on {Guest.SQLTableName}.idLocation = {Guest.Location.SQLTableName}.idLocation";

        public static Reservation CreateInstance()
        {
            return new Reservation
            {
                Hotel = Hotel.CreateInstance(),
                Guest = Guest.CreateInstance()
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                Reservation reservation = new Reservation();
                Hotel hotel = new Hotel();
                Location location = new Location();
                Guest guest = new Guest();

                location.IdLocation = (long)reader["LocationIdLocation"];
                location.Address = (string)reader["LocationAddress"];

                hotel.IdHotel = (long)reader["HotelIdHotel"];
                hotel.Name = (string)reader["HotelName"];
                hotel.Email = (string)reader["HotelEmail"];
                hotel.PhoneNumber = (string)reader["HotelPhoneNumber"];
                hotel.Address = (string)reader["HotelAddress"];
                hotel.Website = (string)reader["Website"];

                guest.IdGuest = (long)reader["GuestIdGuest"];
                guest.Name = (string)reader["GuestName"];
                guest.Surname = (string)reader["Surname"];
                guest.Email = (string)reader["GuestEmail"];
                guest.PhoneNumber = reader["GuestPhoneNumber"] is DBNull ? null : (string)reader["GuestPhoneNumber"];
                guest.Location = location;

                reservation.IdReservation = (long)reader["IdReservation"];
                reservation.TotalPriceInDinars = (float)reader["TotalPriceInDinars"];
                reservation.CreationDate = (DateTime)reader["CreationDate"];
                reservation.Hotel = hotel;
                reservation.Guest = guest;
                entities.Add(reservation);
            }
            return entities;
        }

        public override string ToString() => $"{Guest}, {Hotel}, {CreationDate}, {TotalPriceInDinars} dinars";
    }
}
