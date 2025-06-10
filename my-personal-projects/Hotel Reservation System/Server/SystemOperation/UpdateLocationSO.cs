using Domen;

namespace Server.SystemOperation
{
    internal class UpdateLocationSO : SystemOperationBase<Location,Location>
    {
        public UpdateLocationSO(Location mesto)
        {
            Entity = mesto;
            
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update<Location>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
