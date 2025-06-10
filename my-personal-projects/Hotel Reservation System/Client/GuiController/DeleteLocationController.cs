using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class DeleteLocationController : SingletonBase<DeleteLocationController>
    {
        private UCDeleteLocation obrisiLocation;
        Location LocationSample = Location.CreateInstance();

        internal UCDeleteLocation UCDeleteLocation()
        {
            obrisiLocation = new UCDeleteLocation();

            IEntityDataGridViewHandler.Refresh<Location>(obrisiLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);

            return obrisiLocation;
        }

        public void DeleteLocation(object sender, EventArgs e)
        {
            if (obrisiLocation.DataGridViewMesta.SelectedRows.Count == 0)
                return;

            Location Location = Location.CreateInstance();
            Location.IdLocation = Convert.ToInt64(obrisiLocation.DataGridViewMesta.SelectedRows[0].Cells["IdLocation"].Value);

            Response response = Communication.Instance.DeleteLocation(Location);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully deleted a location from the system!");

            IEntityDataGridViewHandler.Refresh<Location>(obrisiLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);
        }
    }
}
