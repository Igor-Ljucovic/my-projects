using Domen;
using System;
using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;

namespace Client.GuiController 
{
    internal class DeleteHotelReviewController : SingletonBase<DeleteHotelReviewController>
    {
        private UCDeleteHotelReview obrisiHotelReview;
        private HotelReview HotelReviewSample = HotelReview.CreateInstance();

        internal UCDeleteHotelReview UCDeleteHotelReview()
        {
            obrisiHotelReview = new UCDeleteHotelReview();

            IEntityDataGridViewHandler.Refresh<HotelReview>(obrisiHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText { Entity = HotelReviewSample, SQLCommandText = HotelReviewSample.WhereSQLCondition }, Communication.Instance.SearchHotelReview);

            return obrisiHotelReview;
        }

        public void DeleteHotelReview(object sender, EventArgs e)
        {
            if (obrisiHotelReview.DataGridViewRecenzijeHotela.SelectedRows.Count == 0)
                return;

            HotelReview HotelReview = HotelReview.CreateInstance();

            HotelReview.Hotel = Hotel.CreateInstance();
            HotelReview.Hotel = new Hotel { IdHotel = Convert.ToInt64(((Hotel) obrisiHotelReview.DataGridViewRecenzijeHotela.SelectedRows[0].Cells["Hotel"].Value).IdHotel) };
            HotelReview.ReviewInstitution = new ReviewInstitution { IdReviewInstitution = Convert.ToInt64(((ReviewInstitution) obrisiHotelReview.DataGridViewRecenzijeHotela.SelectedRows[0].Cells["ReviewInstitution"].Value).IdReviewInstitution) };
            HotelReview.Date = (DateTime)obrisiHotelReview.DataGridViewRecenzijeHotela.SelectedRows[0].Cells["Date"].Value;

            Response response = Communication.Instance.DeleteHotelReview(HotelReview);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully deleted a hotel review from the system!");

            IEntityDataGridViewHandler.Refresh<HotelReview>(obrisiHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText { Entity = HotelReviewSample, SQLCommandText = HotelReviewSample.WhereSQLCondition }, Communication.Instance.SearchHotelReview);
        }
    }
}
