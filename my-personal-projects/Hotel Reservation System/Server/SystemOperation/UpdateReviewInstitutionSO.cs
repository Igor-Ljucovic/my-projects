using Domen;

namespace Server.SystemOperation
{
    internal class UpdateReviewInstitutionSO : SystemOperationBase<ReviewInstitution, ReviewInstitution>
    {
        public UpdateReviewInstitutionSO(ReviewInstitution institucijaZaRecenzije)
        {
            Entity = institucijaZaRecenzije;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update<ReviewInstitution>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
