using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCSearchHotel
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
        private void InitializeComponent()
        {
            dataGridViewHoteli = new DataGridView();
            maskedTextBoxBrojTelefonaHotela = new MaskedTextBox();
            textboxWebsite = new TextBox();
            textboxAdresa = new TextBox();
            labelWebsiteHotela = new Label();
            textboxEmail = new TextBox();
            labelAdresaHotela = new Label();
            labelBrojTelefonaHotela = new Label();
            labelEmailHotela = new Label();
            labelNazivHotela = new Label();
            textboxNaziv = new TextBox();
            buttonPretrazi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHoteli
            // 
            dataGridViewHoteli.AllowUserToAddRows = false;
            dataGridViewHoteli.AllowUserToDeleteRows = false;
            dataGridViewHoteli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHoteli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoteli.Location = new System.Drawing.Point(261, 49);
            dataGridViewHoteli.Name = "dataGridViewHoteli";
            dataGridViewHoteli.ReadOnly = true;
            dataGridViewHoteli.Size = new System.Drawing.Size(240, 236);
            dataGridViewHoteli.TabIndex = 40;
            // 
            // maskedTextBoxBrojTelefonaHotela
            // 
            maskedTextBoxBrojTelefonaHotela.Location = new System.Drawing.Point(132, 122);
            maskedTextBoxBrojTelefonaHotela.Mask = "\\0110000000";
            maskedTextBoxBrojTelefonaHotela.Name = "maskedTextBoxBrojTelefonaHotela";
            maskedTextBoxBrojTelefonaHotela.PromptChar = ' ';
            maskedTextBoxBrojTelefonaHotela.Size = new System.Drawing.Size(112, 23);
            maskedTextBoxBrojTelefonaHotela.TabIndex = 39;
            // 
            // textboxWebsite
            // 
            textboxWebsite.Location = new System.Drawing.Point(132, 194);
            textboxWebsite.Name = "textboxWebsite";
            textboxWebsite.Size = new System.Drawing.Size(112, 23);
            textboxWebsite.TabIndex = 38;
            // 
            // textboxAdresa
            // 
            textboxAdresa.Location = new System.Drawing.Point(132, 158);
            textboxAdresa.Name = "textboxAdresa";
            textboxAdresa.Size = new System.Drawing.Size(112, 23);
            textboxAdresa.TabIndex = 37;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(70, 202);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(52, 15);
            labelWebsiteHotela.TabIndex = 36;
            labelWebsiteHotela.Text = "Website:";
            // 
            // textboxEmail
            // 
            textboxEmail.Location = new System.Drawing.Point(132, 85);
            textboxEmail.Name = "textboxEmail";
            textboxEmail.Size = new System.Drawing.Size(112, 23);
            textboxEmail.TabIndex = 35;
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(70, 166);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(52, 15);
            labelAdresaHotela.TabIndex = 34;
            labelAdresaHotela.Text = "Address:";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(37, 130);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(89, 15);
            labelBrojTelefonaHotela.TabIndex = 33;
            labelBrojTelefonaHotela.Text = "Phone number:";
            // 
            // labelEmailHotela
            // 
            labelEmailHotela.AutoSize = true;
            labelEmailHotela.Location = new System.Drawing.Point(83, 93);
            labelEmailHotela.Name = "labelEmailHotela";
            labelEmailHotela.Size = new System.Drawing.Size(39, 15);
            labelEmailHotela.TabIndex = 32;
            labelEmailHotela.Text = "Email:";
            // 
            // labelNazivHotela
            // 
            labelNazivHotela.AutoSize = true;
            labelNazivHotela.Location = new System.Drawing.Point(80, 52);
            labelNazivHotela.Name = "labelNazivHotela";
            labelNazivHotela.Size = new System.Drawing.Size(42, 15);
            labelNazivHotela.TabIndex = 31;
            labelNazivHotela.Text = "Name:";
            // 
            // textboxNaziv
            // 
            textboxNaziv.Location = new System.Drawing.Point(132, 49);
            textboxNaziv.Name = "textboxNaziv";
            textboxNaziv.Size = new System.Drawing.Size(112, 23);
            textboxNaziv.TabIndex = 30;
            // 
            // buttonPretrazi
            // 
            buttonPretrazi.Location = new System.Drawing.Point(83, 248);
            buttonPretrazi.Name = "buttonPretrazi";
            buttonPretrazi.Size = new System.Drawing.Size(94, 37);
            buttonPretrazi.TabIndex = 29;
            buttonPretrazi.Text = "Search";
            buttonPretrazi.UseVisualStyleBackColor = true;
            // 
            // UCSearchHotel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewHoteli);
            Controls.Add(maskedTextBoxBrojTelefonaHotela);
            Controls.Add(textboxWebsite);
            Controls.Add(textboxAdresa);
            Controls.Add(labelWebsiteHotela);
            Controls.Add(textboxEmail);
            Controls.Add(labelAdresaHotela);
            Controls.Add(labelBrojTelefonaHotela);
            Controls.Add(labelEmailHotela);
            Controls.Add(labelNazivHotela);
            Controls.Add(textboxNaziv);
            Controls.Add(buttonPretrazi);
            Name = "UCSearchHotel";
            Size = new System.Drawing.Size(553, 335);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private DataGridView dataGridViewHoteli;
        private MaskedTextBox maskedTextBoxBrojTelefonaHotela;
        private TextBox textboxWebsite;
        private TextBox textboxAdresa;
        private Label labelWebsiteHotela;
        private TextBox textboxEmail;
        private Label labelAdresaHotela;
        private Label labelBrojTelefonaHotela;
        private Label labelEmailHotela;
        private Label labelNazivHotela;
        private TextBox textboxNaziv;
        private Button buttonPretrazi;

        public DataGridView DataGridViewHoteli { get => dataGridViewHoteli; set => dataGridViewHoteli = value; }
        public MaskedTextBox MaskedTextBoxBrojTelefonaHotela { get => maskedTextBoxBrojTelefonaHotela; set => maskedTextBoxBrojTelefonaHotela = value; }
        public TextBox TextboxWebsite { get => textboxWebsite; set => textboxWebsite = value; }
        public TextBox TextboxAdresa { get => textboxAdresa; set => textboxAdresa = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public TextBox TextboxEmail { get => textboxEmail; set => textboxEmail = value; }
        public Label LabelAdresaHotela { get => labelAdresaHotela; set => labelAdresaHotela = value; }
        public Label LabelBrojTelefonaHotela { get => labelBrojTelefonaHotela; set => labelBrojTelefonaHotela = value; }
        public Label LabelEmailHotela { get => labelEmailHotela; set => labelEmailHotela = value; }
        public Label LabelNazivHotela { get => labelNazivHotela; set => labelNazivHotela = value; }
        public TextBox TextboxNaziv { get => textboxNaziv; set => textboxNaziv = value; }
        public Button ButtonPretrazi { get => buttonPretrazi; set => buttonPretrazi = value; }
    }
}
