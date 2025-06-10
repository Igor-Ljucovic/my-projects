using Domen;

namespace Server.SystemOperation
{
    internal class CreateLocationSO : SystemOperationBase<Location, Location>
    {
        public CreateLocationSO(Location mesto)
        {
            Entity = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add<Location>(Entity.InsertSQLValues);
            Result = Entity;
        }
    }
}
