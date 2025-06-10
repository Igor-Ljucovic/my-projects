using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class CreateReviewInstitutionController : SingletonBase<CreateReviewInstitutionController>
    {
        private UCCreateReviewInstitution ubaciReviewInstitution;
        private ReviewInstitution ReviewInstitutionSample = ReviewInstitution.CreateInstance();

        internal UCCreateReviewInstitution UCCreateReviewInstitution()
        {
            ubaciReviewInstitution = new UCCreateReviewInstitution();

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(ubaciReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);

            return ubaciReviewInstitution;
        }

        public void CreateReviewInstitution(object sender, EventArgs e)
        {
            if (!Validation.Validate(string.IsNullOrEmpty(ubaciReviewInstitution.TextBoxNaziv.Text), "'Name' cannot be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(ubaciReviewInstitution.TextBoxOpis.Text), "'Description' cannot be empty!"))
                return;

            ReviewInstitution ReviewInstitution = new ReviewInstitution
            {
                Name = ubaciReviewInstitution.TextBoxNaziv.Text,
                Description = ubaciReviewInstitution.TextBoxOpis.Text
            };

            Response response = Communication.Instance.CreateReviewInstitution(ReviewInstitution);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a review institution in the system!");

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(ubaciReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);
        }
    }
}
