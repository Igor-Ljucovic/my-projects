using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Domen
{
    public class ReservationItem : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<ReservationItem>
    {
        public long No { get; set; }
        public Reservation Reservation { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int Nights { get; set; }
        public float ReservationItemPriceInDinars { get; set; }
        public Room Room { get; set; }

        public string SQLTableName => "ReservationItem";
        public string InsertSQLValues => $"{Reservation.IdReservation}, '{StartingDate}', '{EndingDate}', {Nights}, {ReservationItemPriceInDinars}, {Room.IdRoom}";
        public string[] DataGridViewColumnsToIgnore => ["No", "SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"IdReservation={Reservation.IdReservation} AND No={No}";
        public string SetSQLCondition => $"IdReservation={Reservation.IdReservation}, StartingDate='{StartingDate}', EndingDate='{EndingDate}', Nights={Nights}, ReservationItemPriceInDinars={ReservationItemPriceInDinars}, IdRoom={Room.IdRoom}";
        public string WhereSQLCondition => $"1=1";
        public string SelectSQLCondition =>
            $"ReservationItem.idRReservation as ReservationItemIdReservation, " +
            $"no, " +
            $"startingDate, " +
            $"endingDate, " +
            $"nights, " +
            $"reservationItemPriceInDinars, " +
            $"ReservationItem.idRoom as ReservationItemIdRoom, " +
            $"Room.idRoom as RoomIdRoom, " +
            $"roomNumber, " +
            $"roomType, " +
            $"nightPriceInDinars, " +
            $"surfaceInm2, " +
            $"Room.idHotel as RoomIdHotel, " +
            $"Hotel.idHotel as HotelIdHotel, " +
            $"Hotel.name as HotelName, " +
            $"Hotel.email as HotelEmail, " +
            $"Hotel.phoneNumber as HotelPhoneNumber, " +
            $"Hotel.address as HotelAddress, " +
            $"website, " +
            $"creationDate, " +
            $"{SQLTableName}.idGuest as {SQLTableName}IdGuest, " +
            $"{SQLTableName}.idHotel as {SQLTableName}IdHotel, " +
            $"{SQLTableName}.idReservation as {SQLTableName}IdReservation, " +
            $"totalPriceInDinars, " +
            $"Guest.idGuest as GuestIdGuest, " +
            $"Guest.email as GuestEmail, " +
            $"Guest.phoneNumber as GuestPhoneNumber, " +
            $"Guest.name as GuestName, " +
            $"surname, " +
            $"Guest.idLocation as GuestIdLocation, " +
            $"Location.idLocation as LocationIdLocation, " +
            $"Location.adresa as LocationAdresa " +
        $"from ReservationItem " +
        $"join room on ReservationItem.idRoom=Room.idRoom " + 
        $"join hotel on Room.idHotel=Hotel.idHotel " + 
        $"join {SQLTableName} on ReservationItem.idReservation={SQLTableName}.idReservation " +
        $"join Guest on Reservation.idGuest=Guest.idGuest " +
        $"join Location on Guest.idLocation=Location.idLocation";

        public static ReservationItem CreateInstance()
        {
            return new ReservationItem
            {
                Reservation = Reservation.CreateInstance(),
                Room = Room.CreateInstance()
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                ReservationItem reservationItem = new ReservationItem();
                Reservation reservation = new Reservation();
                Guest guest = new Guest();
                Location location = new Location();
                Room room = new Room();
                Hotel hotel = new Hotel();

                hotel.IdHotel = (long)reader["HotelIdHotel"];
                hotel.Name = (string)reader["HotelName"];
                hotel.Email = (string)reader["HotelEmail"];
                hotel.PhoneNumber = (string)reader["HotelPhoneNumber"];
                hotel.Address = (string)reader["HotelAddress"];
                hotel.Website = (string)reader["Website"];

                room.IdRoom = (long)reader["RoomIdRoom"];
                room.RoomNumber = (string)reader["RoomNumber"];
                room.RoomType = Enum.Parse<RoomType>(reader["RoomType"].ToString());
                room.NightPriceInDinars = (float)reader["NightPriceInDinars"];
                room.SurfaceInm2 = (int)reader["SurfaceInm2"];
                room.Hotel = hotel;

                location.IdLocation = (long)reader["LocationIdLocation"];
                location.Address = (string)reader["LocationAdresa"];

                guest.IdGuest = (long)reader["GuestIdGuest"];
                guest.Name = (string)reader["GuestName"];
                guest.Surname = (string)reader["Surname"];
                guest.Email = (string)reader["GuestEmail"];
                guest.PhoneNumber = reader["GuestPhoneNumber"] is DBNull ? null : (string)reader["GostPhoneNumber"];
                guest.Location = location;

                reservation.IdReservation = (long)reader["ReservationIdReservation"];
                reservation.TotalPriceInDinars = (float)reader["TotalPriceInDinars"];
                reservation.CreationDate = (DateTime)reader["CreationDate"];
                reservation.Hotel = hotel;
                reservation.Guest = guest;

                reservationItem.Reservation = reservation;
                reservationItem.No = (long)reader["No"];
                reservationItem.StartingDate = (DateTime)reader["StartingDate"];
                reservationItem.EndingDate = (DateTime)reader["EndingDate"];
                reservationItem.Nights = (int)reader["Nights"];
                reservationItem.ReservationItemPriceInDinars = (float)reader["ReservationItemPriceInDinars"];
                reservationItem.Room = room;

                entities.Add(reservationItem);
            }
            return entities;
        }

        public override string ToString() => $"{Reservation.Guest}, {Room}, {StartingDate}-{EndingDate}, {ReservationItemPriceInDinars} dinars";
    }
}
