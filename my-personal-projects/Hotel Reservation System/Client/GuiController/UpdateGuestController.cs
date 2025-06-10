using Client.UserControls;
using Client.Util;
using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Windows.Forms;

namespace Client.GuiController
{
    internal class UpdateGuestController : SingletonBase<UpdateGuestController>
    {
        private UCUpdateGuest promeniGost; 
        private Guest gostSample = Guest.CreateInstance();

        internal UCUpdateGuest UCUpdateGuest()
        {
            promeniGost = new UCUpdateGuest();

            IEntityComboBoxHandler.Fill<Location>(promeniGost.ComboBoxMesta, Communication.Instance.SearchLocation, null, "Location.IdLocation", true);
            
            IEntityDataGridViewHandler.Refresh<Guest>(promeniGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);

            return promeniGost;
        }

        public void UpdateGuest(object sender, EventArgs e)
        {
            if (!Validation.Validate(promeniGost.DataGridViewGosti.SelectedRows.Count == 0, "You haven't selected a row in the guests table!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniGost.TextboxIme.Text), "'Name' can't be empty!") ||
                !Validation.Validate(string.IsNullOrEmpty(promeniGost.TextboxPrezime.Text), "'Surname' can't be empty!") ||
                !Validation.Validate(!promeniGost.TextboxEmail.Text.Contains("@"), "'Email' must contain at least 1 '@' character!") ||
                !Validation.Validate(promeniGost.CheckBoxBrojTelefona.Checked && (promeniGost.MaskedTextBoxBrojTelefonaHotela.Text.Length != 10 || promeniGost.MaskedTextBoxBrojTelefonaHotela.Text.Contains(" ")), "'Phone number' must contain exactly 10 digits!") ||
                !Validation.Validate(promeniGost.ComboBoxMesta.SelectedIndex < 0, "'Location' can't be empty!"))
                return;

            DataGridViewRow selectedRow = promeniGost.DataGridViewGosti.SelectedRows[0];

            Guest gost = new Guest
            {
                IdGuest = Convert.ToInt64(selectedRow.Cells["IdGuest"].Value),
                Name = promeniGost.TextboxIme.Text,
                Surname = promeniGost.TextboxPrezime.Text,
                Email = promeniGost.TextboxEmail.Text,
                PhoneNumber = promeniGost.CheckBoxBrojTelefona.Checked ? promeniGost.MaskedTextBoxBrojTelefonaHotela.Text : null,
                Location = promeniGost.ComboBoxMesta.SelectedItem as Location
            };

            Response response = Communication.Instance.UpdateGuest(gost);

            FormMessageBoxHandler.ShowSystemOperationResultMessage(response, "Successfully updated the guest!");

            IEntityDataGridViewHandler.Refresh<Guest>(promeniGost.DataGridViewGosti, new IEntityAndCommandText { Entity = gostSample, SQLCommandText = gostSample.WhereSQLCondition }, Communication.Instance.SearchGuest);
        }

        public void FillFormWithSelectedDataGridViewRow(object sender, EventArgs e)
        {
            if (promeniGost.DataGridViewGosti.SelectedRows.Count == 0)
                return;

            DataGridViewRow selectedRow = promeniGost.DataGridViewGosti.SelectedRows[0];

            promeniGost.TextboxIme.Text = selectedRow.Cells["Name"].Value.ToString();
            promeniGost.TextboxPrezime.Text = selectedRow.Cells["Surname"].Value.ToString();
            promeniGost.TextboxEmail.Text = selectedRow.Cells["Email"].Value.ToString();
            promeniGost.MaskedTextBoxBrojTelefonaHotela.Text = selectedRow.Cells["PhoneNumber"].Value.ToString();
            promeniGost.ComboBoxMesta.Text = selectedRow.Cells["Location"].Value.ToString();
        }
    }
}
