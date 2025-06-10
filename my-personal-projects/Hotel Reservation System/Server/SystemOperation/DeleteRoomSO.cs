using Domen;

namespace Server.SystemOperation
{
    internal class DeleteRoomSO : SystemOperationBase<Room, Room>
    {
        public DeleteRoomSO(Room soba)
        {
            Entity = soba;
        }

        protected override void ExecuteConcreteOperation()
        {
            Room soba = (Room)broker.GetOneByConditions<Room>(Entity.SelectSQLCondition, Entity.PrimaryKeySQLCondition);
            broker.Delete<Room>(soba.PrimaryKeySQLCondition);
            Result = Entity;
        }
    }
}
