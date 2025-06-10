using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class SearchReviewInstitutionController : SingletonBase<SearchReviewInstitutionController>
    {
        private UCSearchReviewInstitution pretraziReviewInstitution;
        private ReviewInstitution ReviewInstitutionSample = ReviewInstitution.CreateInstance();

        internal UCSearchReviewInstitution UCSearchReviewInstitution()
        {
            pretraziReviewInstitution = new UCSearchReviewInstitution();

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(pretraziReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);

            return pretraziReviewInstitution;
        }

        public void SearchReviewInstitution(object sender, EventArgs e)
        {
            ReviewInstitution ReviewInstitution = new ReviewInstitution
            {
                Name = pretraziReviewInstitution.TextboxNaziv.Text,
                Description = pretraziReviewInstitution.TextboxOpis.Text
            };

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = ReviewInstitution, SQLCommandText = ReviewInstitution.WhereSQLCondition };

            Response response = Communication.Instance.SearchReviewInstitution(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the review institutions!");

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(pretraziReviewInstitution.DataGridViewInstitucijeZaRecenzije, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchReviewInstitution);
        }
    }
}
