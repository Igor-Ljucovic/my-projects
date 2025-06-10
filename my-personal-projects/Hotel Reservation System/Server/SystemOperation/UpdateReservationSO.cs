using Common.Domain;
using Domen;
using System;

namespace Server.SystemOperation
{
    internal class UpdateReservationSO<T> : SystemOperationBase<T, T> where T : IEntity, IUpdate
    {
        public UpdateReservationSO(T entity)
        {
            Entity = entity;
        }

        protected override void ExecuteConcreteOperation()
        {
            if (Entity is Reservation)
            {
                broker.Update<Reservation>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
                Result = Entity;
            }
            else if (Entity is ReservationItem)
            {
                broker.Update<ReservationItem>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
                Result = Entity;
            }
            else
                throw new Exception("Uneti tip podataka u parametrima nije validan");
        }
    }
}