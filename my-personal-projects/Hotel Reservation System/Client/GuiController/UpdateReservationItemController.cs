using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class UpdateReservationItemController : SingletonBase<UpdateReservationItemController>
    {
        private UCUpdateReservationItem promeniReservationItem;
        private ReservationItem ReservationItemSample = ReservationItem.CreateInstance();

        internal UCUpdateReservationItem UCUpdateReservationItem()
        {
            promeniReservationItem = new UCUpdateReservationItem();

            IEntityComboBoxHandler.Fill<Room>(promeniReservationItem.ComboBoxSobe, Communication.Instance.SearchRoom, null, "Room.IdRoom", true);

            long ReservationId = MainCoordinator.Instance.frmReservationItem.Reservation.IdReservation;
            IEntityDataGridViewHandler.Refresh<ReservationItem>(promeniReservationItem.DataGridViewStavkeRezervacije, new IEntityAndCommandText { Entity = ReservationItemSample, SQLCommandText = $"Reservation.idReservation = {ReservationId}" }, Communication.Instance.SearchReservationItem);
            promeniReservationItem.LabelCenaStavkeDin.Text = "0";

            return promeniReservationItem;
        }

        public void UpdateReservationItem(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniReservationItem.DataGridViewStavkeRezervacije.SelectedRows.Count == 0, "You haven't selected a row in the reservations table!") ||
                !Validation.Validate(promeniReservationItem.DateTimePickerKraj.Value.Date < promeniReservationItem.DateTimePickerPocetak.Value.Date, "'Ending date' must be after Starting date!") ||
                !Validation.Validate(promeniReservationItem.ComboBoxSobe.SelectedIndex < 0, "'Room' can't be empty!"))
                return;

            ReservationItem ReservationItem = new ReservationItem
            {
                Reservation = MainCoordinator.Instance.frmReservationItem.Reservation,
                No = Convert.ToInt64(promeniReservationItem.DataGridViewStavkeRezervacije.SelectedRows[0].Cells["No"].Value),
                Nights = (promeniReservationItem.DateTimePickerKraj.Value - promeniReservationItem.DateTimePickerPocetak.Value).Days + 1,
                ReservationItemPriceInDinars = CalculateReservationItemPrice(),
                StartingDate = promeniReservationItem.DateTimePickerPocetak.Value,
                EndingDate = promeniReservationItem.DateTimePickerKraj.Value,
                Room = promeniReservationItem.ComboBoxSobe.SelectedItem as Room
            };

            Response response = Communication.Instance.UpdateReservationItem(ReservationItem);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the reservation item!");

            long ReservationId = MainCoordinator.Instance.frmReservationItem.Reservation.IdReservation;

            IEntityDataGridViewHandler.Refresh<ReservationItem>(promeniReservationItem.DataGridViewStavkeRezervacije, new IEntityAndCommandText { Entity = ReservationItemSample, SQLCommandText = $"Reservation.idReservation = {ReservationId}" }, Communication.Instance.SearchReservationItem);
        }

        public void ShowReservationItemPrice(object sender, EventArgs e)
        {
            if (promeniReservationItem.ComboBoxSobe.SelectedIndex < 0 || promeniReservationItem.DateTimePickerPocetak.Value.Date == null || promeniReservationItem.DateTimePickerKraj.Value.Date == null)
                return;

            promeniReservationItem.LabelCenaStavkeDin.Text = CalculateReservationItemPrice().ToString();
        }

        public float CalculateReservationItemPrice()
        {
            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = Room.CreateInstance(), SQLCommandText = $"idRoom = {((Room)promeniReservationItem.ComboBoxSobe.SelectedItem).IdRoom}" };

            List<Room> sobe = Communication.Instance.SearchRoom(iEntityAndCommandTextZaPretrazivanje).Result as List<Room>;

            float cenaPoNociDin = sobe[0].NightPriceInDinars;
            long brojDana = (promeniReservationItem.DateTimePickerKraj.Value - promeniReservationItem.DateTimePickerPocetak.Value).Days + 1;

            if (sobe.Count == 1)
                return cenaPoNociDin * brojDana;
            else
                // this should never happen
                throw new Exception("Price not calculated properly because there are multiple rooms with the same ID");
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniReservationItem.DataGridViewStavkeRezervacije.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniReservationItem.DataGridViewStavkeRezervacije.SelectedRows[0];

            promeniReservationItem.DateTimePickerPocetak.Value = (DateTime)selectedRow.Cells["startingDate"].Value;
            promeniReservationItem.DateTimePickerKraj.Value = (DateTime)selectedRow.Cells["endingDate"].Value;
            promeniReservationItem.ComboBoxSobe.Text = selectedRow.Cells["Room"].Value.ToString();
            ShowReservationItemPrice(sender, e);
        }
    }
}
