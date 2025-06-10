using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class DeleteGuestController : SingletonBase<DeleteGuestController>
    {
        private UCDeleteGuest obrisiGost; 
        private Guest gostSample = Guest.CreateInstance();

        internal UCDeleteGuest UCDeleteGuest()
        {
            obrisiGost = new UCDeleteGuest();

            IEntityDataGridViewHandler.Refresh<Guest>(obrisiGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);

            return obrisiGost;
        }

        public void DeleteGuest(object sender, EventArgs e)
        {
            if (obrisiGost.DataGridViewGosti.SelectedRows.Count == 0)
                return;

            Guest gost = Guest.CreateInstance();
            gost.IdGuest = Convert.ToInt64(obrisiGost.DataGridViewGosti.SelectedRows[0].Cells["IdGuest"].Value);

            Response response = Communication.Instance.DeleteGuest(gost);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully deleted a guest from the system!");

            IEntityDataGridViewHandler.Refresh<Guest>(obrisiGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);
        }
    }
}
