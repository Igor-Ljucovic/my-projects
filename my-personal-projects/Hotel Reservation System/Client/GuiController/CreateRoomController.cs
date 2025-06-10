using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class CreateRoomController : SingletonBase<CreateRoomController>
    {
        private UCCreateRoom kreirajRoom;
        private Room RoomSample = Room.CreateInstance();

        internal UCCreateRoom UCCreateRoom()
        {
            kreirajRoom = new UCCreateRoom();

            IEntityComboBoxHandler.Fill<Hotel>(kreirajRoom.ComboBoxHotel, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            kreirajRoom.ComboBoxTipSobe.DataSource = Enum.GetValues(typeof(RoomType));
            kreirajRoom.ComboBoxTipSobe.SelectedIndex = -1;

            IEntityDataGridViewHandler.Refresh<Room>(kreirajRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);

            return kreirajRoom;
        }

        public void CreateRoom(object sender, EventArgs e)
        {
            if (!Validation.Validate(string.IsNullOrEmpty(kreirajRoom.TextBoxBrojSobe.Text), "'Room number' cannot be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(kreirajRoom.TextBoxCenaPoNociDin.Text), "'Night price' cannot be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(kreirajRoom.TextboxPovrsinaUm2.Text), "'Surface' cannot be empty!") ||
                !Validation.Validate(kreirajRoom.ComboBoxTipSobe.SelectedIndex < 0, "'Room type' cannot be empty!") ||
                !Validation.Validate(kreirajRoom.ComboBoxHotel.SelectedIndex < 0, "'Hotel' cannot be empty!") ||
                !Validation.Validate(kreirajRoom.TextBoxCenaPoNociDin.Text.Contains(','), "'Night price' should contain '.' instead of ',' for decimal points!") ||
                !Validation.TryParse(kreirajRoom.TextBoxCenaPoNociDin.Text, out float cenaPoNoci, "'Night price' must be a number (it CAN have a decimal)!") ||
                !Validation.TryParse(kreirajRoom.TextboxPovrsinaUm2.Text, out int povrsina, "'Surface' must be a number (it CANNOT have a decimal)!"))
                return;

            Room Room = new Room
            {
                RoomNumber = kreirajRoom.TextBoxBrojSobe.Text,
                NightPriceInDinars = float.Parse(kreirajRoom.TextBoxCenaPoNociDin.Text),
                SurfaceInm2 = int.Parse(kreirajRoom.TextboxPovrsinaUm2.Text),
                RoomType = (RoomType)kreirajRoom.ComboBoxTipSobe.SelectedItem,
                Hotel = (Hotel)kreirajRoom.ComboBoxHotel.SelectedItem
            };

            Response response = Communication.Instance.CreateRoom(Room);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a Room in the system!");

            IEntityDataGridViewHandler.Refresh<Room>(kreirajRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);
        }
    }
}
