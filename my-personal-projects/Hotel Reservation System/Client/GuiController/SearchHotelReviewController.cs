using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Collections.Generic;

namespace Client.GuiController
{
    internal class SearchHotelReviewController : SingletonBase<SearchHotelReviewController>
    {
        private UCSearchHotelReview pretraziHotelReview;
        private HotelReview HotelReviewSample = HotelReview.CreateInstance();

        internal UCSearchHotelReview UCSearchHotelReview()
        {
            pretraziHotelReview = new UCSearchHotelReview();

            pretraziHotelReview.ComboBoxMinimalanBrojZvezdica.DataSource = new List<short> { 1, 2, 3, 4, 5 };
            pretraziHotelReview.ComboBoxMinimalanBrojZvezdica.SelectedIndex = -1;
            IEntityComboBoxHandler.Fill<Hotel>(pretraziHotelReview.ComboBoxHoteli, Communication.Instance.SearchHotel, null, "Hotel.IdHotel", true);
            IEntityComboBoxHandler.Fill<ReviewInstitution>(pretraziHotelReview.ComboBoxImenaInstitucijaZaRecenzije, Communication.Instance.SearchReviewInstitution, null, "ReviewInstitution.IdReviewInstitution", true);

            IEntityDataGridViewHandler.Refresh<HotelReview>(pretraziHotelReview.DataGridViewRecenzijeHotela, new IEntityAndCommandText { Entity = HotelReviewSample, SQLCommandText = HotelReviewSample.WhereSQLCondition }, Communication.Instance.SearchHotelReview);

            return pretraziHotelReview;
        }

        public void SearchHotelReview(object sender, EventArgs e)
        {
            if (!Validation.Validate(pretraziHotelReview.CheckBoxBrojZvezdica.Checked && (pretraziHotelReview.ComboBoxMinimalanBrojZvezdica.SelectedIndex < 0 || pretraziHotelReview.ComboBoxMaksimalanBrojZvezdica.SelectedIndex < 0), "'Stars' cannot be empty if you checked it in the criteria!") ||
                !Validation.Validate(pretraziHotelReview.CheckBoxNazivHotela.Checked && pretraziHotelReview.ComboBoxHoteli.SelectedIndex < 0, "'Hotel' cannot be empty if you checked it in the criteria!") ||
                !Validation.Validate(pretraziHotelReview.CheckBoxNazivInstitucijeZaRecenzije.Checked && pretraziHotelReview.ComboBoxImenaInstitucijaZaRecenzije.SelectedIndex < 0, "'Review institution' cannot be empty if you checked it in the criteria!"))
                return;

            short minimalanBrojZvezdica = pretraziHotelReview.CheckBoxBrojZvezdica.Checked ? short.Parse(pretraziHotelReview.ComboBoxMinimalanBrojZvezdica.SelectedItem.ToString()) : (short)0;
            short maksimalanBrojZvezdica = pretraziHotelReview.CheckBoxBrojZvezdica.Checked ? short.Parse(pretraziHotelReview.ComboBoxMaksimalanBrojZvezdica.SelectedItem.ToString()) : (short)0;
            long idHotel = pretraziHotelReview.CheckBoxNazivHotela.Checked ? ((Hotel)pretraziHotelReview.ComboBoxHoteli.SelectedItem).IdHotel : 0;
            long idReviewInstitution = pretraziHotelReview.CheckBoxNazivInstitucijeZaRecenzije.Checked ? ((ReviewInstitution)pretraziHotelReview.ComboBoxImenaInstitucijaZaRecenzije.SelectedItem).IdReviewInstitution : 0;

            string SQLCommandText =
                $"    ('{pretraziHotelReview.CheckBoxDatum.Checked}' = 'false'                       OR date BETWEEN '{pretraziHotelReview.DateTimePickerNajranijiDatum.Value}' AND '{pretraziHotelReview.DateTimePickerNajkasnijiDatum.Value}') " +
                $"AND ('{pretraziHotelReview.CheckBoxBrojZvezdica.Checked}' = 'false'                OR stars BETWEEN {minimalanBrojZvezdica} AND {maksimalanBrojZvezdica}) " +
                $"AND ('{pretraziHotelReview.CheckBoxKomentar.Checked}' = 'false'                    OR comment LIKE '%{pretraziHotelReview.RichTextBoxKomentar.Text}%') " +
                $"AND ('{pretraziHotelReview.CheckBoxNazivHotela.Checked}' = 'false'                 OR HotelReview.idHotel = {idHotel}) " +
                $"AND ('{pretraziHotelReview.CheckBoxNazivInstitucijeZaRecenzije.Checked}' = 'false' OR HotelReview.idReviewInstitution = {idReviewInstitution})";

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = HotelReviewSample, SQLCommandText = SQLCommandText };

            Response response = Communication.Instance.SearchHotelReview(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the hotel reviews!");

            IEntityDataGridViewHandler.Refresh<HotelReview>(pretraziHotelReview.DataGridViewRecenzijeHotela, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchHotelReview);
        }
    }
}
