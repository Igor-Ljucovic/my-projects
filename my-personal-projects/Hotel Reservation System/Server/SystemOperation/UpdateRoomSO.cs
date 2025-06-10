using Domen;

namespace Server.SystemOperation
{
    internal class UpdateRoomSO : SystemOperationBase<Room, Room>
    {
        public UpdateRoomSO(Room soba)
        {
            Entity = soba;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Update<Room>(Entity.SetSQLCondition, Entity.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
