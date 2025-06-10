using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class CreateHotelController : SingletonBase<CreateHotelController>
    {
        private UCCreateHotel kreirajHotel;
        private Hotel hotelSample = Hotel.CreateInstance();

        internal UCCreateHotel UCCreateHotel()
        {
            kreirajHotel = new UCCreateHotel();

            IEntityDataGridViewHandler.Refresh<Hotel>(kreirajHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);

            return kreirajHotel;
        }

        public void CreateHotel(object sender, EventArgs e)
        {
            if (!Validation.Validate(string.IsNullOrEmpty(kreirajHotel.TextboxNaziv.Text), "'Name' cannot be empty!") ||
                !Validation.Validate(!kreirajHotel.TextboxEmail.Text.Contains("@"), "'Email' must contain at least 1 '@' character") ||
                !Validation.Validate(kreirajHotel.MaskedTextBoxBrojTelefonaHotela.Text.Length != 10 || kreirajHotel.MaskedTextBoxBrojTelefonaHotela.Text.Contains(" "), "'Phone number' must contain exactly 10 digits!") ||
                !Validation.Validate(string.IsNullOrEmpty(kreirajHotel.TextboxAdresa.Text), "'Address' cannot be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(kreirajHotel.TextboxWebsite.Text), "'Website' cannot be empty!"))
                return;

            Hotel hotel = new Hotel
            {
                Name = kreirajHotel.TextboxNaziv.Text,
                Email = kreirajHotel.TextboxEmail.Text,
                PhoneNumber = kreirajHotel.MaskedTextBoxBrojTelefonaHotela.Text,
                Address = kreirajHotel.TextboxAdresa.Text,
                Website = kreirajHotel.TextboxWebsite.Text
            };
            
            Response response = Communication.Instance.CreateHotel(hotel);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a hotel in the system!");

            IEntityDataGridViewHandler.Refresh<Hotel>(kreirajHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);
        }
    }
}
