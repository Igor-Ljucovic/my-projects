using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateHotel
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
            textboxEmail = new TextBox();
            labelAdresaHotela = new Label();
            labelBrojTelefonaHotela = new Label();
            labelEmailHotela = new Label();
            labelNazivHotela = new Label();
            textboxNaziv = new TextBox();
            buttonKreiraj = new Button();
            labelWebsiteHotela = new Label();
            textboxAdresa = new TextBox();
            textboxWebsite = new TextBox();
            maskedTextBoxBrojTelefonaHotela = new MaskedTextBox();
            dataGridViewHoteli = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).BeginInit();
            SuspendLayout();
            // 
            // textboxEmail
            // 
            textboxEmail.Location = new System.Drawing.Point(99, 52);
            textboxEmail.Name = "textboxEmail";
            textboxEmail.Size = new System.Drawing.Size(112, 23);
            textboxEmail.TabIndex = 22;
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(19, 133);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(52, 15);
            labelAdresaHotela.TabIndex = 21;
            labelAdresaHotela.Text = "Address:";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(4, 97);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(89, 15);
            labelBrojTelefonaHotela.TabIndex = 20;
            labelBrojTelefonaHotela.Text = "Phone number:";
            // 
            // labelEmailHotela
            // 
            labelEmailHotela.AutoSize = true;
            labelEmailHotela.Location = new System.Drawing.Point(19, 59);
            labelEmailHotela.Name = "labelEmailHotela";
            labelEmailHotela.Size = new System.Drawing.Size(39, 15);
            labelEmailHotela.TabIndex = 19;
            labelEmailHotela.Text = "Email:";
            // 
            // labelNazivHotela
            // 
            labelNazivHotela.AutoSize = true;
            labelNazivHotela.Location = new System.Drawing.Point(19, 21);
            labelNazivHotela.Name = "labelNazivHotela";
            labelNazivHotela.Size = new System.Drawing.Size(42, 15);
            labelNazivHotela.TabIndex = 18;
            labelNazivHotela.Text = "Name:";
            // 
            // textboxNaziv
            // 
            textboxNaziv.Location = new System.Drawing.Point(99, 16);
            textboxNaziv.Name = "textboxNaziv";
            textboxNaziv.Size = new System.Drawing.Size(112, 23);
            textboxNaziv.TabIndex = 16;
            // 
            // buttonKreiraj
            // 
            buttonKreiraj.Location = new System.Drawing.Point(50, 215);
            buttonKreiraj.Name = "buttonKreiraj";
            buttonKreiraj.Size = new System.Drawing.Size(94, 37);
            buttonKreiraj.TabIndex = 12;
            buttonKreiraj.Text = "Create";
            buttonKreiraj.UseVisualStyleBackColor = true;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(19, 169);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(52, 15);
            labelWebsiteHotela.TabIndex = 23;
            labelWebsiteHotela.Text = "Website:";
            // 
            // textboxAdresa
            // 
            textboxAdresa.Location = new System.Drawing.Point(99, 125);
            textboxAdresa.Name = "textboxAdresa";
            textboxAdresa.Size = new System.Drawing.Size(112, 23);
            textboxAdresa.TabIndex = 25;
            // 
            // textboxWebsite
            // 
            textboxWebsite.Location = new System.Drawing.Point(99, 161);
            textboxWebsite.Name = "textboxWebsite";
            textboxWebsite.Size = new System.Drawing.Size(112, 23);
            textboxWebsite.TabIndex = 26;
            // 
            // maskedTextBoxBrojTelefonaHotela
            // 
            maskedTextBoxBrojTelefonaHotela.Location = new System.Drawing.Point(99, 89);
            maskedTextBoxBrojTelefonaHotela.Mask = "\\0110000000";
            maskedTextBoxBrojTelefonaHotela.Name = "maskedTextBoxBrojTelefonaHotela";
            maskedTextBoxBrojTelefonaHotela.PromptChar = ' ';
            maskedTextBoxBrojTelefonaHotela.Size = new System.Drawing.Size(112, 23);
            maskedTextBoxBrojTelefonaHotela.TabIndex = 27;
            // 
            // dataGridViewHoteli
            // 
            dataGridViewHoteli.AllowUserToAddRows = false;
            dataGridViewHoteli.AllowUserToDeleteRows = false;
            dataGridViewHoteli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHoteli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoteli.Location = new System.Drawing.Point(228, 16);
            dataGridViewHoteli.Name = "dataGridViewHoteli";
            dataGridViewHoteli.ReadOnly = true;
            dataGridViewHoteli.Size = new System.Drawing.Size(240, 236);
            dataGridViewHoteli.TabIndex = 28;
            // 
            // UCCreateHotel
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
            Controls.Add(buttonKreiraj);
            Name = "UCCreateHotel";
            Size = new System.Drawing.Size(483, 309);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textboxEmail;
        private System.Windows.Forms.Label labelAdresaHotela;
        private System.Windows.Forms.Label labelBrojTelefonaHotela;
        private System.Windows.Forms.Label labelEmailHotela;
        private System.Windows.Forms.Label labelNazivHotela;
        private System.Windows.Forms.TextBox textboxNaziv;
        private System.Windows.Forms.Button buttonKreiraj;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.TextBox textboxAdresa;
        private System.Windows.Forms.TextBox textboxWebsite;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBrojTelefonaHotela;
        private System.Windows.Forms.DataGridView dataGridViewHoteli;

        public TextBox TextboxEmail { get => textboxEmail; set => textboxEmail = value; }
        public TextBox TextboxNaziv { get => textboxNaziv; set => textboxNaziv = value; }
        public TextBox TextboxAdresa { get => textboxAdresa; set => textboxAdresa = value; }
        public TextBox TextboxWebsite { get => textboxWebsite; set => textboxWebsite = value; }
        public MaskedTextBox MaskedTextBoxBrojTelefonaHotela { get => maskedTextBoxBrojTelefonaHotela; set => maskedTextBoxBrojTelefonaHotela = value; }
        public Label LabelAdresaHotela { get => labelAdresaHotela; set => labelAdresaHotela = value; }
        public Label LabelBrojTelefonaHotela { get => labelBrojTelefonaHotela; set => labelBrojTelefonaHotela = value; }
        public Label LabelEmailHotela { get => labelEmailHotela; set => labelEmailHotela = value; }
        public Label LabelNazivHotela { get => labelNazivHotela; set => labelNazivHotela = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public DataGridView DataGridViewHoteli { get => dataGridViewHoteli; set => dataGridViewHoteli = value; }
    }
}
