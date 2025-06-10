using Common.Domain;
using Domen;
using System;

namespace Server.SystemOperation
{
    internal class CreateReservationSO<T> : SystemOperationBase<T, T> where T : IEntity, ICreate
    {
        public CreateReservationSO(T entity)
        {
            Entity = entity;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity is Reservation rezervacija)
            {
                rezervacija.IdReservation = broker.AddAndGetID<Reservation>(rezervacija.InsertSQLValues, "idRezervacija");
                Result = (T)(IEntity)rezervacija;
            }
            else if (Entity is ReservationItem stavkaRezervacije)
            {
                broker.Add<ReservationItem>(stavkaRezervacije.InsertSQLValues);
                Result = (T)(IEntity)stavkaRezervacije;
            }
            else
                throw new Exception("Uneti tip podataka u parametrima nije validan");
            
        }
    }
}