using Domen;

namespace Server.SystemOperation
{
    internal class DeleteHotelSO : SystemOperationBase<Hotel, Hotel>
    {
        public DeleteHotelSO(Hotel hotel)
        {
            Entity = hotel;
        }

        protected override void ExecuteConcreteOperation()
        {
            Hotel hotel = (Hotel)broker.GetOneByConditions<Hotel>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            broker.Delete<Hotel>(hotel.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
