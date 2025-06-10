using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class DeleteReviewInstitutionController : SingletonBase<DeleteReviewInstitutionController>
    {
        private UCDeleteReviewInstitution obrisiReviewInstitution;
        private ReviewInstitution ReviewInstitutionSample = ReviewInstitution.CreateInstance();

        internal UCDeleteReviewInstitution UCDeleteReviewInstitution()
        {
            obrisiReviewInstitution = new UCDeleteReviewInstitution();

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(obrisiReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);

            return obrisiReviewInstitution;
        }

        public void DeleteReviewInstitution(object sender, EventArgs e)
        {
            if (obrisiReviewInstitution.DataGridViewInstitucijeZaRecenzije.SelectedRows.Count == 0)
                return;

            ReviewInstitution ReviewInstitution = ReviewInstitution.CreateInstance();
            ReviewInstitution.IdReviewInstitution = Convert.ToInt64(obrisiReviewInstitution.DataGridViewInstitucijeZaRecenzije.SelectedRows[0].Cells["IdReviewInstitution"].Value);
            
            Response response = Communication.Instance.DeleteReviewInstitution(ReviewInstitution);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully deleted a review institution from the system!");

            IEntityDataGridViewHandler.Refresh<ReviewInstitution>(obrisiReviewInstitution.DataGridViewInstitucijeZaRecenzije, new IEntityAndCommandText { Entity = ReviewInstitutionSample, SQLCommandText = ReviewInstitutionSample.WhereSQLCondition }, Communication.Instance.SearchReviewInstitution);
        }
    }
}
