using Domen;

namespace Server.SystemOperation
{
    internal class CreateRoomSO : SystemOperationBase<Room, Room>
    {
        public CreateRoomSO(Room soba)
        {
            Entity = soba;
        }

        protected override void ExecuteConcreteOperation()
        {
            broker.Add<Room>(Entity.InsertSQLValues);
            Result = Entity;
        }
    }
}
