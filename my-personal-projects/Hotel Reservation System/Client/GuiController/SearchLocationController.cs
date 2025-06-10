using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class SearchLocationController : SingletonBase<SearchLocationController>
    {
        private UCSearchLocation pretraziLocation;
        private Location LocationSample = Location.CreateInstance();

        internal UCSearchLocation UCSearchLocation()
        {
            pretraziLocation = new UCSearchLocation();

            Location Location = Location.CreateInstance();
            IEntityDataGridViewHandler.Refresh<Location>(pretraziLocation.DataGridViewMesta, new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition }, Communication.Instance.SearchLocation);

            return pretraziLocation;
        }

        public void SearchLocation(object sender, EventArgs e)
        {
            Location Location = new Location
            {
                Address = pretraziLocation.TextboxAdresa.Text
            };

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = LocationSample, SQLCommandText = LocationSample.WhereSQLCondition };

            Response response = Communication.Instance.SearchLocation(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the locations!");

            IEntityDataGridViewHandler.Refresh<Location>(pretraziLocation.DataGridViewMesta, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchLocation);
        }
    }
}
