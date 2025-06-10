using Domen;

namespace Server.SystemOperation
{
    internal class DeleteReviewInstitutionSO : SystemOperationBase<ReviewInstitution, ReviewInstitution>
    {
        public DeleteReviewInstitutionSO(ReviewInstitution institucijaZaRecenzije)
        {
            Entity = institucijaZaRecenzije;
        }

        protected override void ExecuteConcreteOperation()
        {
            ReviewInstitution institucijaZaRecenzije = (ReviewInstitution)broker.GetOneByConditions<ReviewInstitution>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            broker.Delete<ReviewInstitution>(institucijaZaRecenzije.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
