using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class DeleteRoomController : SingletonBase<DeleteRoomController>
    {
        private UCDeleteRoom obrisiRoom; 
        private Room RoomSample = Room.CreateInstance();

        internal UCDeleteRoom UCDeleteRoom()
        {
            obrisiRoom = new UCDeleteRoom();

            Room Room = Room.CreateInstance();
            IEntityDataGridViewHandler.Refresh<Room>(obrisiRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);

            return obrisiRoom;
        }

        public void DeleteRoom(object sender, EventArgs e)
        {
            if (obrisiRoom.DataGridViewSobe.SelectedRows.Count == 0)
                return;

            Room Room = Room.CreateInstance();
            Room.IdRoom = Convert.ToInt64(obrisiRoom.DataGridViewSobe.SelectedRows[0].Cells["IdRoom"].Value);
            
            Response response = Communication.Instance.DeleteRoom(Room);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully deleted a room from the system!");

            IEntityDataGridViewHandler.Refresh<Room>(obrisiRoom.DataGridViewSobe, new IEntityAndCommandText { Entity = RoomSample, SQLCommandText = RoomSample.WhereSQLCondition }, Communication.Instance.SearchRoom);
        }
    }
}
