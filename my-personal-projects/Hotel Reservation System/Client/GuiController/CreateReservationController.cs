using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Collections.Generic;

namespace Client.GuiController
{
    internal class CreateReservationController : SingletonBase<CreateReservationController>
    {
        private UCCreateReservation kreirajReservation;
        private Reservation ReservationSample = Reservation.CreateInstance();

        internal UCCreateReservation UCCreateReservation()
        {
            kreirajReservation = new UCCreateReservation();

            IEntityComboBoxHandler.Fill<Hotel>(kreirajReservation.ComboBoxHoteli, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            IEntityComboBoxHandler.Fill<Guest>(kreirajReservation.ComboBoxGosti, Communication.Instance.SearchGuest, null, "Guest.IdGuest", true);

            IEntityDataGridViewHandler.Refresh<Reservation>(kreirajReservation.DataGridViewRezervacije, new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = ReservationSample.WhereSQLCondition }, Communication.Instance.SearchReservation);

            return kreirajReservation;
        }

        public void CreateReservation(object sender, EventArgs e)
        {
            if (!Validation.Validate(kreirajReservation.ComboBoxHoteli.SelectedIndex < 0, "'Hotel' cannot be empty!") ||
                !Validation.Validate(kreirajReservation.ComboBoxGosti.SelectedIndex < 0, "'Guest' cannot be empty!") ||
                !Validation.Validate(kreirajReservation.DateTimeDatum.Value.Date < DateTime.Today, "'Date' cannot be in the future!"))
                return;

            // temporary value because the database doesn't allow zero or negative values
            float temp = 0.01f;

            Reservation Reservation = new Reservation
            {
                Hotel = kreirajReservation.ComboBoxHoteli.SelectedItem as Hotel,
                Guest = kreirajReservation.ComboBoxGosti.SelectedItem as Guest,
                ReservationItems = new List<ReservationItem>(),
                CreationDate = kreirajReservation.DateTimeDatum.Value.Date,
                TotalPriceInDinars = temp
            };

            Response response = Communication.Instance.CreateReservation(Reservation);

            Reservation.IdReservation = ((Reservation)response.Result).IdReservation;

            MainCoordinator.Instance.SetupReservationItemForm(Reservation, MainCoordinator.Instance.ShowCreateReservationPanel);

            Reservation.ReservationItems = MainCoordinator.Instance.ReservationItems();

            Reservation.TotalPriceInDinars = 0;
            foreach (ReservationItem stavka in Reservation.ReservationItems)
                Reservation.TotalPriceInDinars += stavka.ReservationItemPriceInDinars;

            Communication.Instance.UpdateReservation(Reservation); 

            foreach (ReservationItem ReservationItem in MainCoordinator.Instance.frmReservationItem.ReservationItems)
                Communication.Instance.CreateReservationItem(ReservationItem);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a reservation in the system!");

            IEntityDataGridViewHandler.Refresh<Reservation>(kreirajReservation.DataGridViewRezervacije, new IEntityAndCommandText { Entity = ReservationSample, SQLCommandText = ReservationSample.WhereSQLCondition }, Communication.Instance.SearchReservation);
        }
    }
}
