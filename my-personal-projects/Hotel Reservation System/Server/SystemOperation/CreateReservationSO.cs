using Common.Domain;
using Domen;
using System;
using System.Diagnostics;

namespace Server.SystemOperation
{
    internal class CreateReservationSO : SystemOperationBase<Reservation, Reservation>
    {
        public CreateReservationSO(Reservation reservation)
        {
            Entity = reservation;
        }

        protected override void ExecuteConcreteOperation()
        {
            Entity.IdReservation = broker.AddAndGetID<Reservation>(Entity.InsertSQLValues, "idReservation");
            Result = Entity;

            foreach (ReservationItem item in Entity.ReservationItems)
            {
                item.Reservation = Entity;
                Debug.WriteLine(item);
                broker.Add<ReservationItem>(item.InsertSQLValues);
            }
        }
    }
}