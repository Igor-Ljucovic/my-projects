using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class SearchHotelController : SingletonBase<SearchHotelController>
    {
        private UCSearchHotel pretraziHotel;
        private Hotel hotelSample = Hotel.CreateInstance();

        internal UCSearchHotel UCSearchHotel()
        {
            pretraziHotel = new UCSearchHotel();

            IEntityDataGridViewHandler.Refresh<Hotel>(pretraziHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);

            return pretraziHotel;
        }
        
        public void SearchHotel(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel
            {
                Name = pretraziHotel.TextboxNaziv.Text,
                Email = pretraziHotel.TextboxEmail.Text,
                PhoneNumber = pretraziHotel.MaskedTextBoxBrojTelefonaHotela.Text,
                Address = pretraziHotel.TextboxAdresa.Text,
                Website = pretraziHotel.TextboxWebsite.Text,
            };

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = hotel, SQLCommandText = hotel.WhereSQLCondition };

            Response response = Communication.Instance.SearchHotel(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the hotels!");

            IEntityDataGridViewHandler.Refresh<Hotel>(pretraziHotel.DataGridViewHoteli, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchHotel);
        }
    }
}
