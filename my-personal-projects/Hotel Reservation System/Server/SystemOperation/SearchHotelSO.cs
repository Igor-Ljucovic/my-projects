using Common.Communication;
using Domen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchHotelSO : SystemOperationBase<IEntityAndCommandText, List<Hotel>>
    {
        public SearchHotelSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }
        
        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is JsonElement jsonElement)
                Result = broker.GetAllByConditions<Hotel>(jsonElement.Deserialize<Hotel>().SelectSQLCondition, Entity.SQLCommandText).OfType<Hotel>().ToList();
        }
    }
}
