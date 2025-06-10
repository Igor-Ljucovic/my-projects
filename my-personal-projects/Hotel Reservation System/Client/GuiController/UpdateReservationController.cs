using Client.GuiController;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UpdateReservationController : SingletonBase<UpdateReservationController>
    {
        private UCUpdateReservation promeniReservation;
        private Reservation ReservationSample = Reservation.CreateInstance();
        private ReservationItem ReservationItemSample = ReservationItem.CreateInstance();

        internal UCUpdateReservation UCUpdateReservation()
        {
            promeniReservation = new UCUpdateReservation();

            IEntityComboBoxHandler.Fill<Hotel>(promeniReservation.ComboBoxHoteli, Communication.Instance.SearchHotel, null, "IdHotel",  true);
            IEntityComboBoxHandler.Fill<Guest>(promeniReservation.ComboBoxGosti, Communication.Instance.SearchGuest, null, "IdGuest",  true);

            IEntityDataGridViewHandler.Refresh<Reservation>(promeniReservation.DataGridViewRezervacije, new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = ReservationSample.WhereSQLCondition }, Communication.Instance.SearchReservation);

            return promeniReservation;
        }

        public void UpdateReservation(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniReservation.DataGridViewRezervacije.SelectedRows.Count == 0, "You haven't selected a row in the reservations table!") ||
                !Validation.Validate(promeniReservation.ComboBoxHoteli.SelectedIndex < 0, "'Hotel' can't be empty!") ||
                !Validation.Validate(promeniReservation.ComboBoxGosti.SelectedIndex < 0, "'Guest' can't be empty!"))
                return;

            float temp = 1.234567f;

            string SQLCommandText = $"Reservation.idReservation = {promeniReservation.DataGridViewRezervacije.SelectedRows[0].Cells["IdReservation"].Value}";

            DataGridViewRow selectedRow = promeniReservation.DataGridViewRezervacije.SelectedRows[0];

            Reservation Reservation = new Reservation
            {
                IdReservation = Convert.ToInt64(selectedRow.Cells["IdReservation"].Value),
                Hotel = promeniReservation.ComboBoxHoteli.SelectedItem as Hotel,
                Guest = promeniReservation.ComboBoxGosti.SelectedItem as Guest,
                ReservationItems = (List<ReservationItem>)Communication.Instance.SearchReservationItem(new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = SQLCommandText }).Result,
                CreationDate = promeniReservation.DateTimeDatum.Value.Date,
                TotalPriceInDinars = temp
            };

            Reservation.TotalPriceInDinars = 0;
            foreach (ReservationItem stavka in Reservation.ReservationItems)
                Reservation.TotalPriceInDinars += stavka.ReservationItemPriceInDinars;

            Response response = Communication.Instance.UpdateReservation(Reservation);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated a reservation!");

            IEntityDataGridViewHandler.Refresh<Reservation>(promeniReservation.DataGridViewRezervacije, new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = ReservationSample.WhereSQLCondition }, Communication.Instance.SearchReservation);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniReservation.DataGridViewRezervacije.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniReservation.DataGridViewRezervacije.SelectedRows[0];

            promeniReservation.ComboBoxHoteli.Text = selectedRow.Cells["Hotel"].Value.ToString();
            promeniReservation.ComboBoxGosti.Text = selectedRow.Cells["Guest"].Value.ToString();
            promeniReservation.DateTimeDatum.Value = (DateTime)selectedRow.Cells["CreationDate"].Value;
        }

        public void UpdateReservationItem(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniReservation.DataGridViewRezervacije.SelectedRows.Count == 0, "You haven't selected a row in the reservations table!"))
                return;

            DataGridViewRow selectedRow = promeniReservation.DataGridViewRezervacije.SelectedRows[0];
            long idReservation = Convert.ToInt64(selectedRow.Cells["IdReservation"].Value);

            Reservation Reservation = new Reservation
            {
                IdReservation = idReservation,
                Hotel = promeniReservation.ComboBoxHoteli.SelectedItem as Hotel,
                Guest = promeniReservation.ComboBoxGosti.SelectedItem as Guest,
                ReservationItems = (List<ReservationItem>)Communication.Instance.SearchReservationItem(new IEntityAndCommandText { Entity = ReservationItemSample, SQLCommandText = $"Reservation.idReservation = {idReservation}" }).Result,
                CreationDate = (DateTime)selectedRow.Cells["CreationDate"].Value,
                TotalPriceInDinars = (float)selectedRow.Cells["TotalPriceInDinars"].Value
            };

            MainCoordinator.Instance.SetupReservationItemForm(Reservation, MainCoordinator.Instance.ShowUpdateReservationItemPanel);
        }
    }
}
