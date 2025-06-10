using Domen;

namespace Server.SystemOperation
{
    internal class UpdateHotelSO : SystemOperationBase<Hotel, Hotel>
    {
        public UpdateHotelSO(Hotel hotel)
        {
            Entity = hotel;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update<Hotel>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
