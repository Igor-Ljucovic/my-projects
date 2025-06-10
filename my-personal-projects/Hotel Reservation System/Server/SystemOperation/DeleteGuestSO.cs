using Domen;

namespace Server.SystemOperation
{
    internal class DeleteGuestSO : SystemOperationBase<Guest, Guest>
    {
        public DeleteGuestSO(Guest gost)
        {
            Entity = gost;
        }

        protected override void ExecuteConcreteOperation()
        {
            Guest gost = (Guest)broker.GetOneByConditions<Guest>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            broker.Delete<Guest>(gost.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
