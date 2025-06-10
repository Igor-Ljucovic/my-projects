using Common.Communication;
using Domen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchHotelReviewSO : SystemOperationBase<IEntityAndCommandText, List<HotelReview>>
    {
        public SearchHotelReviewSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is JsonElement jsonElement)
                Result = broker.GetAllByConditions<HotelReview>(jsonElement.Deserialize<HotelReview>().SelectSQLCondition, Entity.SQLCommandText).OfType<HotelReview>().ToList();
        }
    }
}
