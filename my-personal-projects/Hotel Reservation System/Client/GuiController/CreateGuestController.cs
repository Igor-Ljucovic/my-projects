using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;

namespace Client.GuiController
{
    internal class CreateGuestController : SingletonBase<CreateGuestController>
    {
        private UCCreateGuest kreirajGost;
        private Guest gostSample = Guest.CreateInstance();

        internal UCCreateGuest UCCreateGuest()
        {
            kreirajGost = new UCCreateGuest();

            IEntityComboBoxHandler.Fill<Location>(kreirajGost.ComboBoxMesta, Communication.Instance.SearchLocation, null, "Location.IdLocation", true);

            Guest gost = Guest.CreateInstance();
            IEntityDataGridViewHandler.Refresh<Guest>(kreirajGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);

            return kreirajGost;
        }

        public void CreateGuest(object sender, EventArgs e)
        {
            if (!Validation.Validate(string.IsNullOrEmpty(kreirajGost.TextboxIme.Text), "'Name' cannot be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(kreirajGost.TextboxPrezime.Text), "'Surname' cannot be empty!") ||
                !Validation.Validate(!kreirajGost.TextboxEmail.Text.Contains("@"), "'Email' must contain at least 1 '@' character") ||
                !Validation.Validate(kreirajGost.CheckBoxBrojTelefona.Checked && kreirajGost.MaskedTextBoxBrojTelefonaHotela.Text.Length != 10 || kreirajGost.MaskedTextBoxBrojTelefonaHotela.Text.Contains(" "), "'Phone number' must contain exactly 10 digits!") ||
                !Validation.Validate(kreirajGost.ComboBoxMesta.SelectedIndex < 0, "'Location' cannot be empty!"))
                return;

            Guest gost = new Guest
            {
                Name = kreirajGost.TextboxIme.Text,
                Surname = kreirajGost.TextboxPrezime.Text,
                Email = kreirajGost.TextboxEmail.Text,
                PhoneNumber = kreirajGost.CheckBoxBrojTelefona.Checked ? null : kreirajGost.MaskedTextBoxBrojTelefonaHotela.Text,
                Location = (Location)kreirajGost.ComboBoxMesta.SelectedItem
            };

            Response response = Communication.Instance.CreateGuest(gost);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully created a guest in the system!");

            IEntityDataGridViewHandler.Refresh<Guest>(kreirajGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);
        }
    }
}
