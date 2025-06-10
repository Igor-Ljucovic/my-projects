using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class SearchReservationItemController : SingletonBase<SearchReservationItemController>
    {
        private UCSearchReservationItem pretraziReservationItem;
        private ReservationItem ReservationItemSample = ReservationItem.CreateInstance();

        internal UCSearchReservationItem UCSearchReservationItem()
        {
            pretraziReservationItem = new UCSearchReservationItem();

            IEntityComboBoxHandler.Fill<Room>(pretraziReservationItem.ComboBoxSobe, Communication.Instance.SearchRoom, null, "Room.IdRoom", true);

            long ReservationId = MainCoordinator.Instance.frmReservationItem.Reservation.IdReservation;
            IEntityDataGridViewHandler.Refresh<ReservationItem>(pretraziReservationItem.DataGridViewStavkeRezervacije, new IEntityAndCommandText { Entity = ReservationItemSample, SQLCommandText = $"Reservation.idReservation = {ReservationId}"}, Communication.Instance.SearchReservationItem);

            return pretraziReservationItem;
        }

        public void SearchReservationItem(object sender, EventArgs e)
        {
            if (!Validation.Validate(pretraziReservationItem.CheckBoxDatumPocetka.Checked && pretraziReservationItem.DateTimePickerNajranijiDatumPocetka.Value.Date > pretraziReservationItem.DateTimePickerNajkasnijiDatumPocetka.Value.Date, "'Latest date' cannot be before the earliest date!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxDatumPocetka.Checked && pretraziReservationItem.DateTimePickerNajranijiDatumKraja.Value.Date > pretraziReservationItem.DateTimePickerNajkasnijiDatumKraja.Value.Date, "'Earliest date' cannot be after the latest date!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxSoba.Checked && pretraziReservationItem.ComboBoxSobe.SelectedIndex < 0, "'Hotel' cannot be empty!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxCena.Checked && (!Validation.TryParse(pretraziReservationItem.TextBoxNajmanjaCena.Text, out float minimalnaCena, "'Min price' must be a number (it CAN have a decimal)!") || !Validation.TryParse(pretraziReservationItem.TextBoxNajvecaCena.Text, out float maksimalnaCena, "'Max price' must be a number (it CAN have a decimal)!")), null) ||
                !Validation.Validate(pretraziReservationItem.CheckBoxBrojNocenja.Checked && (!Validation.TryParse(pretraziReservationItem.TextboxNajmanjiBrojNocenja.Text, out int najmanjiBrojNocenja, "'Min nights' must be a number (it CANNOT have a decimal)!") || !Validation.TryParse(pretraziReservationItem.TextboxNajveciBrojNocenja.Text, out int najveciBrojNocenja, "'Max nights' must be a number (it CANNOT have a decimal)!")), null) ||
                !Validation.Validate(pretraziReservationItem.CheckBoxCena.Checked && float.Parse(pretraziReservationItem.TextBoxNajmanjaCena.Text) < 0, "'Min price' cannot be a negative number (it CAN have a decimal)!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxCena.Checked && float.Parse(pretraziReservationItem.TextBoxNajvecaCena.Text) < 0, "'Max price' cannot be a negative number (it CAN have a decimal)!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxCena.Checked && float.Parse(pretraziReservationItem.TextBoxNajvecaCena.Text) < float.Parse(pretraziReservationItem.TextBoxNajmanjaCena.Text), "'Max price' must be greater then or equal to 'Min price'!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxCena.Checked && (pretraziReservationItem.TextBoxNajmanjaCena.Text.Contains(',') || pretraziReservationItem.TextBoxNajmanjaCena.Text.Contains(',')), "Non-integer numbers must have '.' instead of ',' for a decimal place!") ||
                !Validation.Validate(pretraziReservationItem.CheckBoxBrojNocenja.Checked && (pretraziReservationItem.TextboxNajmanjiBrojNocenja.Text.Contains(',') || pretraziReservationItem.TextboxNajveciBrojNocenja.Text.Contains(',')), "Non-integer numbers must have '.' instead of ',' for a decimal place!"))
                return;

            minimalnaCena = pretraziReservationItem.CheckBoxCena.Checked ? float.Parse(pretraziReservationItem.TextBoxNajmanjaCena.Text) : 0;
            maksimalnaCena = pretraziReservationItem.CheckBoxCena.Checked ? float.Parse(pretraziReservationItem.TextBoxNajvecaCena.Text) : 0;
            najmanjiBrojNocenja = pretraziReservationItem.CheckBoxBrojNocenja.Checked ? int.Parse(pretraziReservationItem.TextboxNajmanjiBrojNocenja.Text) : 0;
            najveciBrojNocenja = pretraziReservationItem.CheckBoxBrojNocenja.Checked ? int.Parse(pretraziReservationItem.TextboxNajveciBrojNocenja.Text) : 0;

            long idRoom = pretraziReservationItem.CheckBoxSoba.Checked ? ((Room)pretraziReservationItem.ComboBoxSobe.SelectedItem).IdRoom : 0;
            long ReservationId = MainCoordinator.Instance.frmReservationItem.Reservation.IdReservation;

            string SQLCommandText =
                $"Reservation.idReservation = {ReservationId} AND " +
                $"('{pretraziReservationItem.CheckBoxDatumPocetka.Checked}' = 'false' OR startingDate BETWEEN '{pretraziReservationItem.DateTimePickerNajranijiDatumPocetka.Value}' AND '{pretraziReservationItem.DateTimePickerNajkasnijiDatumPocetka.Value}') AND " +
                $"('{pretraziReservationItem.CheckBoxDatumKraja.Checked}' = 'false' OR endingDate BETWEEN '{pretraziReservationItem.DateTimePickerNajranijiDatumKraja.Value}' AND '{pretraziReservationItem.DateTimePickerNajkasnijiDatumKraja.Value}') AND " +
                $"('{pretraziReservationItem.CheckBoxSoba.Checked}' =  'false' OR Room.idRoom = {idRoom}) AND " +
                $"('{pretraziReservationItem.CheckBoxCena.Checked}' =  'false' OR reservationItemPriceInDinars between {minimalnaCena} AND {maksimalnaCena}) AND " +
                $"('{pretraziReservationItem.CheckBoxBrojNocenja.Checked}' =  'false' OR nights between {najmanjiBrojNocenja} AND {najveciBrojNocenja})";


            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = ReservationItemSample, SQLCommandText = SQLCommandText };

            Response response = Communication.Instance.SearchReservationItem(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the reservation items!");

            IEntityDataGridViewHandler.Refresh<ReservationItem>(pretraziReservationItem.DataGridViewStavkeRezervacije, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchReservationItem);
        }
    }
}
