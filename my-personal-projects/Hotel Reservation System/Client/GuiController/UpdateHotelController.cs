using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class UpdateHotelController : SingletonBase<UpdateHotelController>
    {
        private UCUpdateHotel promeniHotel;
        private Hotel hotelSample = Hotel.CreateInstance();

        internal UCUpdateHotel UCUpdateHotel()
        {
            promeniHotel = new UCUpdateHotel();

            IEntityDataGridViewHandler.Refresh<Hotel>(promeniHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);

            return promeniHotel;
        }

        public void UpdateHotel(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniHotel.DataGridViewHoteli.SelectedRows.Count == 0, "You haven't selected a row in the hotels table!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniHotel.TextboxNaziv.Text), "'Name' can't be empty!") ||
                !Validation.Validate(!promeniHotel.TextboxEmail.Text.Contains("@"), "'Email' must contain at least 1 '@' character") ||
                !Validation.Validate(promeniHotel.MaskedTextBoxBrojTelefonaHotela.Text.Length != 10 || promeniHotel.MaskedTextBoxBrojTelefonaHotela.Text.Contains(" "), "'Phone number' must contain exactly 10 digits!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniHotel.TextboxAdresa.Text), "'Address' can't be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniHotel.TextboxWebsite.Text), "'Website' can't be empty!"))
                return;

            DataGridViewRow selectedRow = promeniHotel.DataGridViewHoteli.SelectedRows[0];

            Hotel hotel = new Hotel
            {
                IdHotel = Convert.ToInt64(selectedRow.Cells["IdHotel"].Value),
                Name = promeniHotel.TextboxNaziv.Text,
                Email = promeniHotel.TextboxEmail.Text,
                PhoneNumber = promeniHotel.MaskedTextBoxBrojTelefonaHotela.Text,
                Address = promeniHotel.TextboxAdresa.Text,
                Website = promeniHotel.TextboxWebsite.Text
            };

            Response response = Communication.Instance.UpdateHotel(hotel);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the hotel!");

            IEntityDataGridViewHandler.Refresh<Hotel>(promeniHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniHotel.DataGridViewHoteli.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniHotel.DataGridViewHoteli.SelectedRows[0];

            promeniHotel.TextboxNaziv.Text = selectedRow.Cells["Name"].Value.ToString();
            promeniHotel.TextboxEmail.Text = selectedRow.Cells["Email"].Value.ToString();
            promeniHotel.MaskedTextBoxBrojTelefonaHotela.Text = selectedRow.Cells["PhoneNumber"].Value.ToString();
            promeniHotel.TextboxAdresa.Text = selectedRow.Cells["Address"].Value.ToString();
            promeniHotel.TextboxWebsite.Text = selectedRow.Cells["Website"].Value.ToString();
        }
    }
}
