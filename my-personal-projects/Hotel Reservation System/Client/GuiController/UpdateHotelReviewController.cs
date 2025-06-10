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
    internal class UpdateHotelReviewController : SingletonBase<UpdateHotelReviewController>
    {
        private UCUpdateHotelReview promeniHotelReview;
        private HotelReview HotelReviewSample = HotelReview.CreateInstance();

        internal UCUpdateHotelReview UCUpdateHotelReview()
        {
            promeniHotelReview = new UCUpdateHotelReview();

            promeniHotelReview.ComboBoxBrojZvezdica.DataSource = new List<short> { 1, 2, 3, 4, 5 };
            promeniHotelReview.ComboBoxBrojZvezdica.SelectedIndex = -1;
            IEntityComboBoxHandler.Fill<Hotel>(promeniHotelReview.ComboBoxHoteli, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            promeniHotelReview.ComboBoxHoteli.Enabled = false;
            IEntityComboBoxHandler.Fill<ReviewInstitution>(promeniHotelReview.ComboBoxInstitucijeZaRecenzije, Communication.Instance.SearchReviewInstitution, null, "ReviewInstitution.IdReviewInstitution", true);
            promeniHotelReview.ComboBoxInstitucijeZaRecenzije.Enabled = false;

            IEntityDataGridViewHandler.Refresh<HotelReview>(promeniHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText {Entity = HotelReviewSample, SQLCommandText = HotelReviewSample.WhereSQLCondition }, Communication.Instance.SearchHotelReview);

            return promeniHotelReview;
        }

        public void UpdateHotelReview(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniHotelReview.DataGridViewRecenzijeHotela.SelectedRows.Count == 0, "You haven't selected a row in the hotel reviews table!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniHotelReview.RichTextBoxKomentar.Text), "'Comment' can't be empty!") ||
                !Validation.Validate(promeniHotelReview.DateTimePickerDatum.Value.Date > DateTime.Today, "'Date' can't be in the future!") ||
                !Validation.Validate(promeniHotelReview.ComboBoxBrojZvezdica.SelectedIndex == -1, "'Stars' can't be empty!") ||
                !Validation.Validate(promeniHotelReview.ComboBoxHoteli.SelectedIndex == -1, "'Hotel' can't be empty!") ||
                !Validation.Validate(promeniHotelReview.ComboBoxInstitucijeZaRecenzije.SelectedIndex == -1, "'Review institution' can't be empty!"))
                return;

            HotelReview HotelReview = new HotelReview
            {
                Hotel = (Hotel)promeniHotelReview.ComboBoxHoteli.SelectedItem,
                ReviewInstitution = (ReviewInstitution)promeniHotelReview.ComboBoxInstitucijeZaRecenzije.SelectedItem,
                Stars = (short)promeniHotelReview.ComboBoxBrojZvezdica.SelectedValue,
                Date = promeniHotelReview.DateTimePickerDatum.Value,
                Comment = promeniHotelReview.RichTextBoxKomentar.Text
            };

            Response response = Communication.Instance.UpdateHotelReview(HotelReview);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the hotel review!");

            IEntityDataGridViewHandler.Refresh<HotelReview>(promeniHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText { Entity = HotelReview, SQLCommandText = HotelReview.WhereSQLCondition }, Communication.Instance.SearchHotelReview);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniHotelReview.DataGridViewRecenzijeHotela.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniHotelReview.DataGridViewRecenzijeHotela.SelectedRows[0];

            promeniHotelReview.ComboBoxBrojZvezdica.SelectedItem = short.Parse(selectedRow.Cells["Stars"].Value.ToString());
            promeniHotelReview.DateTimePickerDatum.Value = (DateTime)selectedRow.Cells["Date"].Value;
            promeniHotelReview.RichTextBoxKomentar.Text = selectedRow.Cells["Comment"].Value.ToString();
            promeniHotelReview.ComboBoxHoteli.Text = selectedRow.Cells["Hotel"].Value.ToString();
            promeniHotelReview.ComboBoxInstitucijeZaRecenzije.Text = selectedRow.Cells["ReviewInstitution"].Value.ToString();
        }
    }
}
