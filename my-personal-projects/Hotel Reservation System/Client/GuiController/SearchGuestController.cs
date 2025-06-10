using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class SearchGuestController : SingletonBase<SearchGuestController>
    {
        private UCSearchGuest pretraziGost;
        private Guest gostSample = Guest.CreateInstance();

        internal UCSearchGuest UCSearchGuest()
        {
            pretraziGost = new UCSearchGuest();

            IEntityComboBoxHandler.Fill<Location>(pretraziGost.ComboBoxMesta, Communication.Instance.SearchLocation, null, "Location.IdLocation", true);
            
            IEntityDataGridViewHandler.Refresh<Guest>(pretraziGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);

            return pretraziGost;
        }

        public void SearchGuest(object sender, EventArgs e)
        {
            Guest gost = new Guest
            {
                Name = pretraziGost.TextboxIme.Text,
                Surname = pretraziGost.TextboxPrezime.Text,
                Email = pretraziGost.TextboxEmail.Text,
                PhoneNumber = pretraziGost.CheckBoxBrojTelefona.Checked ? pretraziGost.MaskedTextBoxBrojTelefonaHotela.Text : null,
                Location = pretraziGost.ComboBoxMesta.SelectedIndex >= 0 ? new Location { IdLocation = (pretraziGost.ComboBoxMesta.SelectedItem as Location).IdLocation } : null
            };

            IEntityAndCommandText iEntityAndCommandTextZaPretrazivanje = new IEntityAndCommandText { Entity = gost, SQLCommandText = gost.WhereSQLCondition };

            Response response = Communication.Instance.SearchGuest(iEntityAndCommandTextZaPretrazivanje);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully searched the guests!");

            IEntityDataGridViewHandler.Refresh<Guest>(pretraziGost.DataGridViewGosti, iEntityAndCommandTextZaPretrazivanje, Communication.Instance.SearchGuest);
        }
    }
}
