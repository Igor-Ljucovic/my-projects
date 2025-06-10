using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class SearchRoomController : SingletonBase<SearchRoomController>
    {
        private UCSearchRoom pretraziRoom;
        private Room RoomSample = Room.CreateInstance();

        internal UCSearchRoom UCSearchRoom()
        {
            pretraziRoom = new UCSearchRoom();

            IEntityComboBoxHandler.Fill<Hotel>(pretraziRoom.ComboBoxHotel, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            pretraziRoom.ComboBoxTipSobe.DataSource = Enum.GetValues(typeof(RoomType));
            pretraziRoom.ComboBoxTipSobe.SelectedIndex = -1;

            IEntityDataGridViewHandler.Refresh<Room>(pretraziRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);

            return pretraziRoom;
        }

        public void SearchRoom(object sender, EventArgs e)
        {
            if (!Validation.Validate(pretraziRoom.CheckBoxCenaPoNociDin.Checked && (pretraziRoom.TextBoxCenaPoNociDinMinimum.Text.Contains(',') || pretraziRoom.TextBoxCenaPoNociDinMaximum.Text.Contains(',')), "Non-integer numbers should use '.' instead of ',' for decimals!") ||
                !Validation.Validate(pretraziRoom.CheckBoxPovrsinaUm2.Checked && (pretraziRoom.TextboxPovrsinaUm2Minimum.Text.Contains(',') || pretraziRoom.TextboxPovrsinaUm2Maximum.Text.Contains(',')), "Non-integer numbers should use '.' instead of ',' for decimals!") ||
                !Validation.Validate(pretraziRoom.CheckBoxCenaPoNociDin.Checked && (!Validation.TryParse(pretraziRoom.TextBoxCenaPoNociDinMinimum.Text, out float cenaPoNociDinMin, "'Min night price' must be a number (it CAN have a decimal)!") || !Validation.TryParse(pretraziRoom.TextBoxCenaPoNociDinMaximum.Text, out float cenaPoNociDinMax, "'Max night price' must be a number (it CAN have a decimal)!")), null) ||
                !Validation.Validate(pretraziRoom.CheckBoxPovrsinaUm2.Checked && (!Validation.TryParse(pretraziRoom.TextboxPovrsinaUm2Minimum.Text, out int povrsinaUm2Min, "'Min surface' must be a number (it CANNOT have a decimal)!") || !Validation.TryParse(pretraziRoom.TextboxPovrsinaUm2Maximum.Text, out int povrsinaUm2Max, "'Max surface' must be a number (it CANNOT have a decimal)!")), null) ||
                !Validation.Validate(pretraziRoom.CheckBoxCenaPoNociDin.Checked && float.Parse(pretraziRoom.TextBoxCenaPoNociDinMinimum.Text) < 0, "'Min night price' cannot be a negative number (it CAN have a decimal)!") ||
                !Validation.Validate(pretraziRoom.CheckBoxCenaPoNociDin.Checked && float.Parse(pretraziRoom.TextBoxCenaPoNociDinMaximum.Text) < 0, "'Max night price' cannot be a negative number (it CAN have a decimal)!") ||
                !Validation.Validate(pretraziRoom.CheckBoxCenaPoNociDin.Checked && float.Parse(pretraziRoom.TextBoxCenaPoNociDinMaximum.Text) < float.Parse(pretraziRoom.TextBoxCenaPoNociDinMinimum.Text), "'Max surface' must be greater or equal to 'Min surface'!") ||
                !Validation.Validate(pretraziRoom.CheckBoxPovrsinaUm2.Checked && int.Parse(pretraziRoom.TextboxPovrsinaUm2Minimum.Text) < 0, "'Min surface' cannot be a negative number (it CANNOT have a decimal)!") ||
                !Validation.Validate(pretraziRoom.CheckBoxPovrsinaUm2.Checked && int.Parse(pretraziRoom.TextboxPovrsinaUm2Maximum.Text) < 0, "'Max surface' cannot be a negative number (it CANNOT have a decimal)!") ||
                !Validation.Validate(pretraziRoom.CheckBoxPovrsinaUm2.Checked && int.Parse(pretraziRoom.TextboxPovrsinaUm2Maximum.Text) < int.Parse(pretraziRoom.TextboxPovrsinaUm2Minimum.Text), "'Max night price' must be greater or equal to 'Min night price'!") ||
                !Validation.Validate(pretraziRoom.CheckBoxTipSobe.Checked && pretraziRoom.ComboBoxTipSobe.SelectedIndex < 0, "'Room type' cannot be empty!") ||
                !Validation.Validate(pretraziRoom.CheckBoxNazivHotela.Checked && pretraziRoom.ComboBoxHotel.SelectedIndex < 0, "'Hotel' cannot be empty!"))
                return;

            float minimalnaCenaPoNociDin = pretraziRoom.CheckBoxCenaPoNociDin.Checked ? float.Parse(pretraziRoom.TextBoxCenaPoNociDinMinimum.Text) : 0;
            float maximalnaCenaPoNociDin = pretraziRoom.CheckBoxCenaPoNociDin.Checked ? float.Parse(pretraziRoom.TextBoxCenaPoNociDinMaximum.Text) : 0;
            int minimalnaPovrsinaUm2 = pretraziRoom.CheckBoxPovrsinaUm2.Checked ? int.Parse(pretraziRoom.TextboxPovrsinaUm2Minimum.Text) : 0;
            int maximalnaPovrsinaUm2 = pretraziRoom.CheckBoxPovrsinaUm2.Checked ? int.Parse(pretraziRoom.TextboxPovrsinaUm2Maximum.Text) : 0;
            long idHotel = pretraziRoom.CheckBoxNazivHotela.Checked ? ((Hotel)pretraziRoom.ComboBoxHotel.SelectedItem).IdHotel : 0;
            string RoomType = pretraziRoom.CheckBoxTipSobe.Checked ? pretraziRoom.ComboBoxTipSobe.SelectedItem.ToString() : "";

            string SQLCommandText =
                $"('{pretraziRoom.CheckBoxBrojSobe.Checked}'      = 'false' OR roomNumber LIKE '%{pretraziRoom.TextBoxBrojSobe.Text}%') AND " +
                $"('{pretraziRoom.CheckBoxTipSobe.Checked}'       = 'false' OR roomType = '{RoomType}') AND " +
                $"('{pretraziRoom.CheckBoxNazivHotela.Checked}'   = 'false' OR Room.idHotel ={idHotel}) AND " +
                $"('{pretraziRoom.CheckBoxCenaPoNociDin.Checked}' = 'false' OR nightPriceInDinars between {minimalnaCenaPoNociDin} AND {maximalnaCenaPoNociDin}) AND " +
                $"('{pretraziRoom.CheckBoxPovrsinaUm2.Checked}'   = 'false' OR surfaceInm2 between {minimalnaPovrsinaUm2} AND {maximalnaPovrsinaUm2})";

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = SQLCommandText };

            Response response = Communication.Instance.SearchRoom(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the rooms!");

            IEntityDataGridViewHandler.Refresh<Room>(pretraziRoom.DataGridViewSobe, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchRoom);
        }
    }
}
