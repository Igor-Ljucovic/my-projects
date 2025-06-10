using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class UpdateRoomController : SingletonBase<UpdateRoomController>
    {
        private UCUpdateRoom promeniRoom; 
        private Room RoomSample = Room.CreateInstance();

        internal UCUpdateRoom UCUpdateRoom()
        {
            promeniRoom = new UCUpdateRoom();

            IEntityComboBoxHandler.Fill<Hotel>(promeniRoom.ComboBoxHotel, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            promeniRoom.ComboBoxTipSobe.DataSource = Enum.GetValues(typeof(RoomType));
            promeniRoom.ComboBoxTipSobe.SelectedIndex = -1;

            Room Room = Room.CreateInstance();
            IEntityDataGridViewHandler.Refresh<Room>(promeniRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);

            return promeniRoom;
        }

        public void UpdateRoom(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniRoom.DataGridViewSobe.SelectedRows.Count == 0, "You haven't selected a row in the room table!") ||
                !Validation.Validate(promeniRoom.TextboxPovrsinaUm2.Text.Contains(',') || promeniRoom.TextBoxCenaPoNociDin.Text.Contains(','), "Non-integer numbers should use '.' instead of ',' for decimals!") ||
                !Validation.TryParse(promeniRoom.TextBoxCenaPoNociDin.Text, out float cenaPoNociDinMin, "'Night price' must be a number (it CAN have a decimal)!") ||
                !Validation.TryParse(promeniRoom.TextboxPovrsinaUm2.Text, out int povrsinaUm2Min, "'Surface' cannot be a negative number (it CANNOT have a decimal)!") ||
                !Validation.Validate(float.Parse(promeniRoom.TextBoxCenaPoNociDin.Text) < 0, "'Night price' cannot be a negative number (it CAN have a decimal)!") ||
                !Validation.Validate(int.Parse(promeniRoom.TextboxPovrsinaUm2.Text) < 0, "'Surface' cannot be a negative number (it CANNOT have a decimal)!") ||
                !Validation.Validate(promeniRoom.ComboBoxTipSobe.SelectedIndex < 0, "'Room type' cannot be empty!") ||
                !Validation.Validate(promeniRoom.ComboBoxHotel.SelectedIndex < 0, "'Hotel' cannot be empty!"))
                return;

            DataGridViewRow selectedRow = promeniRoom.DataGridViewSobe.SelectedRows[0];

            Room Room = new Room
            {
                IdRoom = Convert.ToInt64(selectedRow.Cells["IdRoom"].Value),
                RoomNumber = promeniRoom.TextBoxBrojSobe.Text,
                SurfaceInm2 = int.Parse(promeniRoom.TextboxPovrsinaUm2.Text),
                NightPriceInDinars = int.Parse(promeniRoom.TextBoxCenaPoNociDin.Text),
                RoomType = (RoomType)promeniRoom.ComboBoxTipSobe.SelectedItem,
                Hotel = promeniRoom.ComboBoxHotel.SelectedItem as Hotel
            };

            Response response = Communication.Instance.UpdateRoom(Room);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the room!");

            IEntityDataGridViewHandler.Refresh<Room>(promeniRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniRoom.DataGridViewSobe.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniRoom.DataGridViewSobe.SelectedRows[0];

            promeniRoom.TextBoxBrojSobe.Text = selectedRow.Cells["RoomNumber"].Value.ToString();
            promeniRoom.TextBoxCenaPoNociDin.Text = selectedRow.Cells["NightPriceInDinars"].Value.ToString();
            promeniRoom.TextboxPovrsinaUm2.Text = selectedRow.Cells["SurfaceInm2"].Value.ToString();
            promeniRoom.ComboBoxTipSobe.Text = selectedRow.Cells["RoomType"].Value.ToString();
            promeniRoom.ComboBoxHotel.Text = selectedRow.Cells["Hotel"].Value.ToString();
        }
    }
}
