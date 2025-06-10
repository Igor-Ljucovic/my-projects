using Domen;

namespace Server.SystemOperation
{
    internal class DeleteLocationSO : SystemOperationBase<Location, Location>
    {
        public DeleteLocationSO(Location mesto)
        {
            Entity = mesto;
        }

        protected override void ExecuteConcreteOperation()
        {
            Location mesto = (Location)broker.GetOneByConditions<Location>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            broker.Delete<Location>(mesto.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
