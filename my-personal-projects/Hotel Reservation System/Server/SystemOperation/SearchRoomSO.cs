using Common.Communication;
using Domen;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchRoomSO : SystemOperationBase<IEntityAndCommandText, List<Room>>
    {
        public SearchRoomSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is JsonElement jsonElement)
                Result = broker.GetAllByConditions<Room>(jsonElement.Deserialize<Room>().SelectSQLCondition, Entity.SQLCommandText).OfType<Room>().ToList();
        }
    }
}
