using Common.Communication;
using Common.Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Server.SystemOperation
{
    internal class SearchReservationSO<T> : SystemOperationBase<IEntityAndCommandText, List<T>> where T : IEntity, ICreate
    {
        public SearchReservationSO(IEntityAndCommandText iEntityAndCommandText)
        {
            Entity = iEntityAndCommandText;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity.Entity is not JsonElement jsonElement)
                throw new Exception("Uneti tip podataka u parametrima nije validan");

            if (typeof(T) == typeof(Reservation))
            {
                var rezervacija = jsonElement.Deserialize<Reservation>();
                Result = broker.GetAllByConditions<Reservation>(rezervacija.SelectSQLCondition, Entity.SQLCommandText).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(ReservationItem))
            {
                var stavka = jsonElement.Deserialize<ReservationItem>();
                Result = broker.GetAllByConditions<ReservationItem>(stavka.SelectSQLCondition, Entity.SQLCommandText).Cast<T>().ToList();
            }
            else
                throw new Exception("Nepodržan tip entiteta za pretragu.");
        }
    }
}
