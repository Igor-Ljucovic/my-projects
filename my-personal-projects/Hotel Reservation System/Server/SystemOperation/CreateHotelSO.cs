using Domen;

namespace Server.SystemOperation
{
    internal class CreateHotelSO : SystemOperationBase<Hotel, Hotel>
    {
        public CreateHotelSO(Hotel hotel)
        {
            Entity = hotel;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add<Hotel>(Entity.InsertSQLValues);
            Result = Entity;
        }
    }
}
