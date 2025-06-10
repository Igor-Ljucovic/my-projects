using Domen;

namespace Server.SystemOperation
{
    internal class CreateGuestSO : SystemOperationBase<Guest, Guest>
    {
        public CreateGuestSO(Guest gost)
        {
            Entity = gost;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add<Guest>(Entity.InsertSQLValues);
            Result = Entity;
        }
    }
}
