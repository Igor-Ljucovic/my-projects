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
    internal class CreateReservationItemController : SingletonBase<CreateReservationItemController>
    {
        private UCCreateReservationItem kreirajReservationItem;
        private ReservationItem ReservationItemSample = ReservationItem.CreateInstance();
        private long ReservationId = MainCoordinator.Instance.frmReservationItem.Reservation.IdReservation;
        private List<ReservationItem> stavkeRezervacije = new List<ReservationItem>();

        internal UCCreateReservationItem UCCreateReservationItem()
        {
            kreirajReservationItem = new UCCreateReservationItem();

            IEntityComboBoxHandler.Fill<Room>(kreirajReservationItem.ComboBoxSobe, Communication.Instance.SearchRoom, null, "Room.IdRoom", true);
            kreirajReservationItem.LabelCenaStavkeDin.Text = "0";

            return kreirajReservationItem;
        }

        public void UCCreateReservationItem(object sender, EventArgs e)
        {
            if (!Validation.Validate(kreirajReservationItem.DateTimePickerPocetak.Value.Date < DateTime.Today, "'Starting date' cannot be empty!") ||
                !Validation.Validate(kreirajReservationItem.DateTimePickerKraj.Value.Date < DateTime.Today, "'Ending date' cannot be in the future!") ||
                !Validation.Validate(kreirajReservationItem.DateTimePickerKraj.Value.Date < kreirajReservationItem.DateTimePickerPocetak.Value.Date, "'Date kraja' must be after Starting date!") ||
                !Validation.Validate(kreirajReservationItem.ComboBoxSobe.SelectedIndex < 0, "'Room' cannot be empty!"))
                return;

            ReservationItem ReservationItem = new ReservationItem
            {
                Reservation = MainCoordinator.Instance.frmReservationItem.Reservation,
                Nights = (kreirajReservationItem.DateTimePickerKraj.Value - kreirajReservationItem.DateTimePickerPocetak.Value).Days + 1,
                ReservationItemPriceInDinars = CalculateItemPrice(),
                StartingDate = kreirajReservationItem.DateTimePickerPocetak.Value,
                EndingDate = kreirajReservationItem.DateTimePickerKraj.Value,
                Room = kreirajReservationItem.ComboBoxSobe.SelectedItem as Room
            };

            MainCoordinator.Instance.frmReservationItem.ReservationItems.Add(ReservationItem);

            DialogResult result = MessageBox.Show("Do you want to add more reservation items?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
                MainCoordinator.Instance.frmReservationItem.Close();

            stavkeRezervacije.Add(ReservationItem);
            kreirajReservationItem.DataGridViewStavkeRezervacije.DataSource = null;
            DataGridViewHandler.Fill<ReservationItem>(kreirajReservationItem.DataGridViewStavkeRezervacije, stavkeRezervacije);
        }

        public void ShowItemPrice(object sender, EventArgs e)
        {
            if (kreirajReservationItem.ComboBoxSobe.SelectedIndex < 0 || kreirajReservationItem.DateTimePickerPocetak.Value.Date == null || kreirajReservationItem.DateTimePickerKraj.Value.Date == null)
                return;

            kreirajReservationItem.LabelCenaStavkeDin.Text = Math.Abs(CalculateItemPrice()).ToString();
        }

        public float CalculateItemPrice()
        {
            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = Room.CreateInstance(), SQLCommandText = $"idRoom = {((Room)kreirajReservationItem.ComboBoxSobe.SelectedItem).IdRoom}" };

            List<Room> sobe = Communication.Instance.SearchRoom(iEntityAndCommandTextZaPretrazivanje).Result as List<Room>;

            float cenaPoNociDin = sobe[0].NightPriceInDinars;
            long brojDana = (kreirajReservationItem.DateTimePickerKraj.Value - kreirajReservationItem.DateTimePickerPocetak.Value).Days + 1;

            if (sobe.Count == 1)
                return cenaPoNociDin * brojDana;
            else
                // this should never happen
                throw new Exception("Price not calculated because there's multiple rooms with the same ID");
        }
    }
}
