using Common.Communication;
using Domen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchReviewInstitutionSO : SystemOperationBase<IEntityAndCommandText, List<ReviewInstitution>>
    {
        public SearchReviewInstitutionSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is JsonElement jsonElement)
                Result = broker.GetAllByConditions<ReviewInstitution>(jsonElement.Deserialize<ReviewInstitution>().SelectSQLCondition, Entity.SQLCommandText).OfType<ReviewInstitution>().ToList();
        }
    }
}
