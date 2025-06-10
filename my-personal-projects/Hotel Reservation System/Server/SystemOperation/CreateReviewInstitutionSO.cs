using Domen;

namespace Server.SystemOperation
{
    internal class CreateReviewInstitutionSO : SystemOperationBase<ReviewInstitution, ReviewInstitution>
    {
        public CreateReviewInstitutionSO(ReviewInstitution institucijaZaRecenzije)
        {
            Entity = institucijaZaRecenzije;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add<ReviewInstitution>(Entity.InsertSQLValues);
            Result = Entity;
        }
    }
}
