using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Collections.Generic;

namespace Client.GuiController
{
    internal class CreateHotelReviewController : SingletonBase<CreateHotelReviewController>
    {
        private UCCreateHotelReview kreirajHotelReview;
        private HotelReview HotelReviewSample = HotelReview.CreateInstance();

        internal UCCreateHotelReview UCCreateHotelReview()
        {
            kreirajHotelReview = new UCCreateHotelReview();

            kreirajHotelReview.ComboBoxBrojZvezdica.DataSource = new List<short> { 1, 2, 3, 4, 5 };
            kreirajHotelReview.ComboBoxBrojZvezdica.SelectedIndex = -1;

            IEntityComboBoxHandler.Fill<Hotel>(kreirajHotelReview.ComboBoxImenaHotela, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            IEntityComboBoxHandler.Fill<ReviewInstitution>(kreirajHotelReview.ComboBoxImenaInstitucijaZaRecenzije, Communication.Instance.SearchReviewInstitution, null, "ReviewInstitution.IdReviewInstitution", true);

            IEntityDataGridViewHandler.Refresh<HotelReview>(kreirajHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText { Entity = HotelReviewSample, SQLCommandText = HotelReviewSample.WhereSQLCondition }, Communication.Instance.SearchHotelReview);

            return kreirajHotelReview;
        }

        public void CreateHotelReview(object sender, EventArgs e)
        {
            if (!Validation.Validate(string.IsNullOrEmpty(kreirajHotelReview.RichTextBoxKomentar.Text), "'Comment' cannot be empty!") ||
                !Validation.Validate(kreirajHotelReview.DateTimePickerDatum.Value.Date > DateTime.Today, "'Date' cannot be in the future!") ||
                !Validation.Validate(kreirajHotelReview.ComboBoxBrojZvezdica.SelectedIndex == -1, "'Stars' cannot be empty!") ||
                !Validation.Validate(kreirajHotelReview.ComboBoxImenaHotela.SelectedIndex == -1, "'Name' cannot be empty!") ||
                !Validation.Validate(kreirajHotelReview.ComboBoxImenaInstitucijaZaRecenzije.SelectedIndex == -1, "'Review institution' cannot be empty!"))
                return;

            HotelReview HotelReview = new HotelReview
            {
                Hotel = new Hotel { IdHotel = (long)kreirajHotelReview.ComboBoxImenaHotela.SelectedValue},
                ReviewInstitution = new ReviewInstitution { IdReviewInstitution = (long)kreirajHotelReview.ComboBoxImenaInstitucijaZaRecenzije.SelectedValue },
                Stars = (short)kreirajHotelReview.ComboBoxBrojZvezdica.SelectedValue,
                Date = kreirajHotelReview.DateTimePickerDatum.Value,
                Comment = kreirajHotelReview.RichTextBoxKomentar.Text
            };

            Response response = Communication.Instance.CreateHotelReview(HotelReview);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a hotel review in the system!");

            IEntityDataGridViewHandler.Refresh<HotelReview>(kreirajHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText { Entity = HotelReviewSample, SQLCommandText = HotelReviewSample.WhereSQLCondition }, Communication.Instance.SearchHotelReview);
        }
    }
}
