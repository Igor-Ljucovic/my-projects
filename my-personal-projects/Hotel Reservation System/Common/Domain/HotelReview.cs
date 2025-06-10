using Common.Domain;
using Common.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Domen
{
    public class HotelReview : IEntity, ICreate, ISearch, IUpdate, ISelect, IObjectFactory<HotelReview>
    {
        public Hotel Hotel { get; set; }
        public ReviewInstitution ReviewInstitution { get; set; }
        public short Stars { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }

        public string SQLTableName => "HotelReview";
        public string InsertSQLValues => $"{Hotel.IdHotel}, {ReviewInstitution.IdReviewInstitution}, {Stars}, '{Date}', '{Comment}'";
        public string[] DataGridViewColumnsToIgnore => ["SQLTableName", "InsertSQLValues", "PrimaryKeySQLCondition", "SetSQLCondition", "WhereSQLCondition", "SelectSQLCondition"];
        public string PrimaryKeySQLCondition => $"{SQLTableName}.IdHotel={Hotel.IdHotel} AND {SQLTableName}.IdReviewInstitution={ReviewInstitution.IdReviewInstitution} AND Date='{Date}'";
        public string SetSQLCondition => $"Stars={Stars}, Date='{Date}', Comment='{Comment}'";
        public string WhereSQLCondition => $"1=1";
        public string SelectSQLCondition => 
               $"{SQLTableName}.idHotel AS IdHotelReviewHotelID, " +
               $"{SQLTableName}.idReviewInstitution AS IdHotelReviewReviewInstitutionID, " +
               $"{SQLTableName}.stars, " +
               $"{SQLTableName}.date, " +
               $"{SQLTableName}.comment, " +
               $"" +
               $"{Hotel.SQLTableName}.idHotel AS IdHotel, " +
               $"{Hotel.SQLTableName}.name AS HotelName, " +
               $"{Hotel.SQLTableName}.address, " +
               $"{Hotel.SQLTableName}.email, " +
               $"{Hotel.SQLTableName}.phoneNumber, " +
               $"{Hotel.SQLTableName}.website, " +
               $"" +
               $"{ReviewInstitution.SQLTableName}.idReviewInstitution AS IdReviewInstitution," +
               $"{ReviewInstitution.SQLTableName}.name AS ReviewInstitutionName, " +
               $"{ReviewInstitution.SQLTableName}.description " +
               $"" +
           $"FROM {SQLTableName} " +
           $"INNER JOIN {Hotel.SQLTableName} ON {SQLTableName}.idHotel = {Hotel.SQLTableName}.idHotel " +
           $"INNER JOIN {ReviewInstitution.SQLTableName} ON {SQLTableName}.idReviewInstitution = {ReviewInstitution.SQLTableName}.idReviewInstitution";

        public static HotelReview CreateInstance()
        {
            return new HotelReview
            {
                Hotel = Hotel.CreateInstance(),
                ReviewInstitution = ReviewInstitution.CreateInstance()
            };
        }

        public List<IEntity> GetReaderList(SqlDataReader reader)
        {
            List<IEntity> entities = new List<IEntity>();
            while (reader.Read())
            {
                HotelReview hotelReview = new HotelReview();
                Hotel hotel = new Hotel();
                ReviewInstitution reviewInstitution = new ReviewInstitution();

                hotel.IdHotel = (long)reader["IdHotel"];
                hotel.Name = (string)reader["HotelName"];
                hotel.Email = (string)reader["Email"];
                hotel.PhoneNumber = (string)reader["PhoneNumber"];
                hotel.Address = (string)reader["Address"];
                hotel.Website = (string)reader["Website"];

                reviewInstitution.IdReviewInstitution = (long)reader["IdReviewInstitution"];
                reviewInstitution.Name = (string)reader["ReviewInstitutionName"];
                reviewInstitution.Description = reader["Description"] is DBNull ? null : (string)reader["Description"];

                hotelReview.Hotel = hotel;
                hotelReview.ReviewInstitution = reviewInstitution;
                hotelReview.Stars = (short)reader["Stars"];
                hotelReview.Date = (DateTime)reader["Date"];
                hotelReview.Comment = (string)reader["Comment"];
                
                entities.Add(hotelReview);
            }
            return entities;
        }

        public override string ToString() => Hotel.Name + "-" + ReviewInstitution.Name;
    }
}
