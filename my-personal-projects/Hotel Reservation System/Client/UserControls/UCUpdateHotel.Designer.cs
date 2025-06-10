using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateHotel
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
            buttonPromeni = new Button();
            dataGridViewHoteli = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).BeginInit();
            SuspendLayout();
            // 
            // maskedTextBoxBrojTelefonaHotela
            // 
            maskedTextBoxBrojTelefonaHotela.Location = new System.Drawing.Point(109, 106);
            maskedTextBoxBrojTelefonaHotela.Mask = "\\0110000000";
            maskedTextBoxBrojTelefonaHotela.Name = "maskedTextBoxBrojTelefonaHotela";
            maskedTextBoxBrojTelefonaHotela.PromptChar = ' ';
            maskedTextBoxBrojTelefonaHotela.Size = new System.Drawing.Size(112, 23);
            maskedTextBoxBrojTelefonaHotela.TabIndex = 38;
            // 
            // textboxWebsite
            // 
            textboxWebsite.Location = new System.Drawing.Point(109, 178);
            textboxWebsite.Name = "textboxWebsite";
            textboxWebsite.Size = new System.Drawing.Size(112, 23);
            textboxWebsite.TabIndex = 37;
            // 
            // textboxAdresa
            // 
            textboxAdresa.Location = new System.Drawing.Point(109, 142);
            textboxAdresa.Name = "textboxAdresa";
            textboxAdresa.Size = new System.Drawing.Size(112, 23);
            textboxAdresa.TabIndex = 36;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(51, 186);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(52, 15);
            labelWebsiteHotela.TabIndex = 35;
            labelWebsiteHotela.Text = "Website:";
            // 
            // textboxEmail
            // 
            textboxEmail.Location = new System.Drawing.Point(109, 69);
            textboxEmail.Name = "textboxEmail";
            textboxEmail.Size = new System.Drawing.Size(112, 23);
            textboxEmail.TabIndex = 34;
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(51, 150);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(52, 15);
            labelAdresaHotela.TabIndex = 33;
            labelAdresaHotela.Text = "Address:";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(14, 114);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(89, 15);
            labelBrojTelefonaHotela.TabIndex = 32;
            labelBrojTelefonaHotela.Text = "Phone number:";
            // 
            // labelEmailHotela
            // 
            labelEmailHotela.AutoSize = true;
            labelEmailHotela.Location = new System.Drawing.Point(60, 77);
            labelEmailHotela.Name = "labelEmailHotela";
            labelEmailHotela.Size = new System.Drawing.Size(39, 15);
            labelEmailHotela.TabIndex = 31;
            labelEmailHotela.Text = "Email:";
            // 
            // labelNazivHotela
            // 
            labelNazivHotela.AutoSize = true;
            labelNazivHotela.Location = new System.Drawing.Point(57, 41);
            labelNazivHotela.Name = "labelNazivHotela";
            labelNazivHotela.Size = new System.Drawing.Size(42, 15);
            labelNazivHotela.TabIndex = 30;
            labelNazivHotela.Text = "Name:";
            // 
            // textboxNaziv
            // 
            textboxNaziv.Location = new System.Drawing.Point(109, 33);
            textboxNaziv.Name = "textboxNaziv";
            textboxNaziv.Size = new System.Drawing.Size(112, 23);
            textboxNaziv.TabIndex = 29;
            // 
            // buttonPromeni
            // 
            buttonPromeni.Location = new System.Drawing.Point(60, 232);
            buttonPromeni.Name = "buttonPromeni";
            buttonPromeni.Size = new System.Drawing.Size(94, 37);
            buttonPromeni.TabIndex = 28;
            buttonPromeni.Text = "Update";
            buttonPromeni.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHoteli
            // 
            dataGridViewHoteli.AllowUserToAddRows = false;
            dataGridViewHoteli.AllowUserToDeleteRows = false;
            dataGridViewHoteli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHoteli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoteli.Location = new System.Drawing.Point(245, 33);
            dataGridViewHoteli.MultiSelect = false;
            dataGridViewHoteli.Name = "dataGridViewHoteli";
            dataGridViewHoteli.ReadOnly = true;
            dataGridViewHoteli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHoteli.Size = new System.Drawing.Size(197, 236);
            dataGridViewHoteli.TabIndex = 39;
            // 
            // UCUpdateHotel
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
            Controls.Add(buttonPromeni);
            Name = "UCUpdateHotel";
            Size = new System.Drawing.Size(467, 310);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxBrojTelefonaHotela;
        private System.Windows.Forms.TextBox textboxWebsite;
        private System.Windows.Forms.TextBox textboxAdresa;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.TextBox textboxEmail;
        private System.Windows.Forms.Label labelAdresaHotela;
        private System.Windows.Forms.Label labelBrojTelefonaHotela;
        private System.Windows.Forms.Label labelEmailHotela;
        private System.Windows.Forms.Label labelNazivHotela;
        private System.Windows.Forms.TextBox textboxNaziv;
        private System.Windows.Forms.Button buttonPromeni;
        private System.Windows.Forms.DataGridView dataGridViewHoteli;

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
        public Button ButtonPromeni { get => buttonPromeni; set => buttonPromeni = value; }
        public DataGridView DataGridViewHoteli { get => dataGridViewHoteli; set => dataGridViewHoteli = value; }
    }
}
