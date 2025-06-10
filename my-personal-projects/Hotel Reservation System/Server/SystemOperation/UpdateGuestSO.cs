using Domen;

namespace Server.SystemOperation
{
    internal class UpdateGuestSO : SystemOperationBase<Guest, Guest>
    {
        public UpdateGuestSO(Guest gost)
        {
            Entity = gost;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update<Guest>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
