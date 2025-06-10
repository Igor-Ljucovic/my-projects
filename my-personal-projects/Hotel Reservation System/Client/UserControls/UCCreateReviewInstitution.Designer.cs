using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateReviewInstitution
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        private DataGridView dataGridViewInstitucijeZaRecenzije;
        private Button buttonUbaci;
        private Label labelOpisInstitucijeZaRecenzije;
        private Label labelNazivInstitucijeZaRecenzije;
        private TextBox textBoxOpis;
        private TextBox textBoxNaziv;

        public DataGridView DataGridViewInstitucijeZaRecenzije { get => dataGridViewInstitucijeZaRecenzije; set => dataGridViewInstitucijeZaRecenzije = value; }
        public Button ButtonUbaci { get => buttonUbaci; set => buttonUbaci = value; }
        public Label LabelOpisInstitucijeZaRecenzije { get => labelOpisInstitucijeZaRecenzije; set => labelOpisInstitucijeZaRecenzije = value; }
        public Label LabelNazivInstitucijeZaRecenzije { get => labelNazivInstitucijeZaRecenzije; set => labelNazivInstitucijeZaRecenzije = value; }
        public TextBox TextBoxOpis { get => textBoxOpis; set => textBoxOpis = value; }
        public TextBox TextBoxNaziv { get => textBoxNaziv; set => textBoxNaziv = value; }
    }
}
