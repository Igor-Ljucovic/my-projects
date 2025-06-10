using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class DeleteHotelController : SingletonBase<DeleteHotelController>
    {
        private UCDeleteHotel obrisiHotel;
        private Hotel hotelSample = Hotel.CreateInstance();

        internal UCDeleteHotel UCDeleteHotel()
        {
            obrisiHotel = new UCDeleteHotel();

            IEntityDataGridViewHandler.Refresh<Hotel>(obrisiHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);

            return obrisiHotel;
        }

        public void DeleteHotel(object sender, EventArgs e)
        {
            if (obrisiHotel.DataGridViewHoteli.SelectedRows.Count == 0)
                return;

            Hotel hotel = Hotel.CreateInstance();
            hotel.IdHotel = Convert.ToInt64(obrisiHotel.DataGridViewHoteli.SelectedRows[0].Cells["IdHotel"].Value);
            
            Response response = Communication.Instance.DeleteHotel(hotel);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully deleted a hotel from the system!");

            IEntityDataGridViewHandler.Refresh<Hotel>(obrisiHotel.DataGridViewHoteli, new IEntityAndCommandText { Entity = hotelSample, SQLCommandText = hotelSample.WhereSQLCondition }, Communication.Instance.SearchHotel);
        }
    }
}
