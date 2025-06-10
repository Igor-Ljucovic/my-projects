using Common.Communication;
using Domen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchLocationSO : SystemOperationBase<IEntityAndCommandText, List<Location>>
    {
        public SearchLocationSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is JsonElement jsonElement)
                Result = broker.GetAllByConditions<Location>(jsonElement.Deserialize<Location>().SelectSQLCondition, Entity.SQLCommandText).OfType<Location>().ToList();
        }
    }
}
