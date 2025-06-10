using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class CreateLocationController : SingletonBase<CreateLocationController>
    {
        private UCCreateLocation kreirajLocation;
        private Location LocationSample = Location.CreateInstance();

        internal UCCreateLocation UCCreateLocation()
        {
            kreirajLocation = new UCCreateLocation();

            Location Location = Location.CreateInstance();
            IEntityDataGridViewHandler.Refresh<Location>(kreirajLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);

            return kreirajLocation;
        }

        public void CreateLocation(object sender, EventArgs e)
        {
            if (!Validation.Validate(string.IsNullOrEmpty(kreirajLocation.TextboxAdresa.Text), "'Address' cannot be empty!"))
                return;

            Location Location = new Location
            {
                Address = kreirajLocation.TextboxAdresa.Text
            };

            Response response = Communication.Instance.CreateLocation(Location);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a location in the system!");

            IEntityDataGridViewHandler.Refresh<Location>(kreirajLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);
        }
    }
}
