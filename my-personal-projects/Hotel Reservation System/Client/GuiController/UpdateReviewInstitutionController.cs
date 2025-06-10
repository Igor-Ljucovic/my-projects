using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class UpdateReviewInstitutionController : SingletonBase<UpdateReviewInstitutionController>
    {
        private UCUpdateReviewInstitution promeniReviewInstitution;
        private ReviewInstitution ReviewInstitutionSample = ReviewInstitution.CreateInstance();

        internal UCUpdateReviewInstitution UCUpdateReviewInstitution()
        {
            promeniReviewInstitution = new UCUpdateReviewInstitution();

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(promeniReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);

            return promeniReviewInstitution;
        }

        public void UpdateReviewInstitution(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniReviewInstitution.DataGridViewInstitucijeZaRecenzije.SelectedRows.Count == 0, "You haven't selected a row in the review institution table!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniReviewInstitution.TextboxNaziv.Text), "'Name' can't be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniReviewInstitution.TextboxNaziv.Text), "'Description' can't be empty!"))
                return;

            DataGridViewRow selectedRow = promeniReviewInstitution.DataGridViewInstitucijeZaRecenzije.SelectedRows[0];

            ReviewInstitution ReviewInstitution = new ReviewInstitution
            {
                IdReviewInstitution = Convert.ToInt64(selectedRow.Cells["IdReviewInstitution"].Value),
                Name = promeniReviewInstitution.TextboxNaziv.Text,
                Description = promeniReviewInstitution.TextboxOpis.Text
            };

            Response response = Communication.Instance.UpdateReviewInstitution(ReviewInstitution);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the review institution!");

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(promeniReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniReviewInstitution.DataGridViewInstitucijeZaRecenzije.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniReviewInstitution.DataGridViewInstitucijeZaRecenzije.SelectedRows[0];

            promeniReviewInstitution.TextboxNaziv.Text = selectedRow.Cells["Name"].Value.ToString();
            promeniReviewInstitution.TextboxOpis.Text = selectedRow.Cells["Description"].Value.ToString();
        }
    }
}
