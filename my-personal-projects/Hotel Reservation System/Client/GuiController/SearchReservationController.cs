using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class SearchReservationController : SingletonBase<SearchReservationController>
    {
        private UCSearchReservation pretraziReservation;
        private Reservation ReservationSample = Reservation.CreateInstance();

        internal UCSearchReservation UCSearchReservation()
        {
            pretraziReservation = new UCSearchReservation();

            IEntityComboBoxHandler.Fill<Hotel>(pretraziReservation.ComboBoxHoteli, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            IEntityComboBoxHandler.Fill<Guest>(pretraziReservation.ComboBoxGosti, Communication.Instance.SearchGuest, null, "Guest.idGost", true);

            Reservation Reservation = Reservation.CreateInstance();
            IEntityDataGridViewHandler.Refresh<Reservation>(pretraziReservation.DataGridViewRezervacije, new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = ReservationSample.WhereSQLCondition }, Communication.Instance.SearchReservation);

            return pretraziReservation;
        }

        public void SearchReservation(object sender, EventArgs e)
        {
            if (!Validation.Validate(pretraziReservation.CheckBoxHotel.Checked && pretraziReservation.ComboBoxHoteli.SelectedIndex < 0, "'Hotel' cannot be empty!") ||
                !Validation.Validate(pretraziReservation.CheckBoxGost.Checked && pretraziReservation.ComboBoxGosti.SelectedIndex < 0, "'Guest' cannot be empty!") ||
                !Validation.Validate(pretraziReservation.CheckBoxDatum.Checked && pretraziReservation.DateTimePickerNajranijiDatum.Value.Date > pretraziReservation.DateTimePickerNajkasnijiDatum.Value.Date, "'Earliest date' cannot be after Latest date!"))
                return;

            long idHotel = pretraziReservation.CheckBoxHotel.Checked ? ((Hotel)pretraziReservation.ComboBoxHoteli.SelectedItem).IdHotel : 0;
            long idGost = pretraziReservation.CheckBoxGost.Checked ? ((Guest)pretraziReservation.ComboBoxGosti.SelectedItem).IdGuest : 0;

            string SQLCommandText =
                $"('{pretraziReservation.CheckBoxDatum.Checked}' = 'false' OR creationDate BETWEEN '{pretraziReservation.DateTimePickerNajranijiDatum.Value}' AND '{pretraziReservation.DateTimePickerNajkasnijiDatum.Value}') AND " +
                $"('{pretraziReservation.CheckBoxHotel.Checked}' = 'false' OR Reservation.idHotel = {idHotel}) AND " +
                $"('{pretraziReservation.CheckBoxGost.Checked}'  = 'false' OR Reservation.idGost = {idGost})";

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = SQLCommandText };

            Response response = Communication.Instance.SearchReservation(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the reservations!");

            IEntityDataGridViewHandler.Refresh<Reservation>(pretraziReservation.DataGridViewRezervacije, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchReservation);
        }

        public void PretraziReservationItem(object sender, EventArgs e)
        {
            if (!Validation.Validate(pretraziReservation.DataGridViewRezervacije.SelectedRows.Count == 0, "You haven't selected a row in the reservations table!"))
                return;

            DataGridViewRow selectedRow = pretraziReservation.DataGridViewRezervacije.SelectedRows[0];

            Reservation Reservation = new Reservation { IdReservation = (long)selectedRow.Cells["IdReservation"].Value };

            MainCoordinator.Instance.SetupReservationItemForm(Reservation, MainCoordinator.Instance.ShowSearchReservationItemPanel);
        }
    }
}
