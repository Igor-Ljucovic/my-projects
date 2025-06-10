using Common.Communication;
using Domen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchGuestSO : SystemOperationBase<IEntityAndCommandText, List<Guest>>
    {
        public SearchGuestSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is JsonElement jsonElement)
                Result = broker.GetAllByConditions<Guest>(jsonElement.Deserialize<Guest>().SelectSQLCondition, Entity.SQLCommandText).OfType<Guest>().ToList();
        }
    }
}
