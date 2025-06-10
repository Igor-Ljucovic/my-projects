using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class UpdateLocationController: SingletonBase<UpdateLocationController>
    {
        private UCUpdateLocation promeniLocation;
        private Location LocationSample = Location.CreateInstance();

        internal UCUpdateLocation UCUpdateLocation()
        {
            promeniLocation = new UCUpdateLocation();

            IEntityDataGridViewHandler.Refresh<Location>(promeniLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);

            return promeniLocation;
        }

        public void UpdateLocation(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniLocation.DataGridViewMesta.SelectedRows.Count == 0, "You haven't selected a row in the locations table!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniLocation.TextboxAdresa.Text), "'Address' can't be empty!"))
                return;

            DataGridViewRow selectedRow = promeniLocation.DataGridViewMesta.SelectedRows[0];

            Location Location = new Location
            {
                IdLocation = Convert.ToInt64(selectedRow.Cells["IdLocation"].Value),
                Address = promeniLocation.TextboxAdresa.Text,
            };

            Response response = Communication.Instance.UpdateLocation(Location);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the location!");

            IEntityDataGridViewHandler.Refresh<Location>(promeniLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniLocation.DataGridViewMesta.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniLocation.DataGridViewMesta.SelectedRows[0];

            promeniLocation.TextboxAdresa.Text = selectedRow.Cells["Address"].Value.ToString();
        }
    }
}
