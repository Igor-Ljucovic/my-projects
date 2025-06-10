using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateGuest
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
            checkBoxBrojTelefona = new CheckBox();
            comboBoxMesta = new ComboBox();
            dataGridViewGosti = new DataGridView();
            maskedTextBoxBrojTelefonaHotela = new MaskedTextBox();
            textboxPrezime = new TextBox();
            labelWebsiteHotela = new Label();
            textboxEmail = new TextBox();
            labelAdresaHotela = new Label();
            labelBrojTelefonaHotela = new Label();
            labelEmailHotela = new Label();
            labelIme = new Label();
            textboxIme = new TextBox();
            buttonPromeni = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGosti).BeginInit();
            SuspendLayout();
            // 
            // checkBoxBrojTelefona
            // 
            checkBoxBrojTelefona.AutoSize = true;
            checkBoxBrojTelefona.Location = new System.Drawing.Point(25, 124);
            checkBoxBrojTelefona.Name = "checkBoxBrojTelefona";
            checkBoxBrojTelefona.Size = new System.Drawing.Size(204, 19);
            checkBoxBrojTelefona.TabIndex = 55;
            checkBoxBrojTelefona.Text = "I want to enter my phone number";
            checkBoxBrojTelefona.UseVisualStyleBackColor = true;
            // 
            // comboBoxMesta
            // 
            comboBoxMesta.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMesta.FormattingEnabled = true;
            comboBoxMesta.Location = new System.Drawing.Point(105, 186);
            comboBoxMesta.Name = "comboBoxMesta";
            comboBoxMesta.Size = new System.Drawing.Size(121, 23);
            comboBoxMesta.TabIndex = 54;
            // 
            // dataGridViewGosti
            // 
            dataGridViewGosti.AllowUserToAddRows = false;
            dataGridViewGosti.AllowUserToDeleteRows = false;
            dataGridViewGosti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewGosti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGosti.Location = new System.Drawing.Point(243, 20);
            dataGridViewGosti.MultiSelect = false;
            dataGridViewGosti.Name = "dataGridViewGosti";
            dataGridViewGosti.ReadOnly = true;
            dataGridViewGosti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGosti.Size = new System.Drawing.Size(240, 236);
            dataGridViewGosti.TabIndex = 53;
            // 
            // maskedTextBoxBrojTelefonaHotela
            // 
            maskedTextBoxBrojTelefonaHotela.Location = new System.Drawing.Point(105, 149);
            maskedTextBoxBrojTelefonaHotela.Mask = "0000000000";
            maskedTextBoxBrojTelefonaHotela.Name = "maskedTextBoxBrojTelefonaHotela";
            maskedTextBoxBrojTelefonaHotela.PromptChar = ' ';
            maskedTextBoxBrojTelefonaHotela.Size = new System.Drawing.Size(112, 23);
            maskedTextBoxBrojTelefonaHotela.TabIndex = 52;
            // 
            // textboxPrezime
            // 
            textboxPrezime.Location = new System.Drawing.Point(105, 52);
            textboxPrezime.Name = "textboxPrezime";
            textboxPrezime.Size = new System.Drawing.Size(112, 23);
            textboxPrezime.TabIndex = 51;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(43, 194);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(56, 15);
            labelWebsiteHotela.TabIndex = 50;
            labelWebsiteHotela.Text = "Location:";
            // 
            // textboxEmail
            // 
            textboxEmail.Location = new System.Drawing.Point(105, 86);
            textboxEmail.Name = "textboxEmail";
            textboxEmail.Size = new System.Drawing.Size(112, 23);
            textboxEmail.TabIndex = 49;
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(38, 60);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(57, 15);
            labelAdresaHotela.TabIndex = 48;
            labelAdresaHotela.Text = "Surname:";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(10, 157);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(89, 15);
            labelBrojTelefonaHotela.TabIndex = 47;
            labelBrojTelefonaHotela.Text = "Phone number:";
            // 
            // labelEmailHotela
            // 
            labelEmailHotela.AutoSize = true;
            labelEmailHotela.Location = new System.Drawing.Point(56, 94);
            labelEmailHotela.Name = "labelEmailHotela";
            labelEmailHotela.Size = new System.Drawing.Size(39, 15);
            labelEmailHotela.TabIndex = 46;
            labelEmailHotela.Text = "Email:";
            // 
            // labelIme
            // 
            labelIme.AutoSize = true;
            labelIme.Location = new System.Drawing.Point(53, 28);
            labelIme.Name = "labelIme";
            labelIme.Size = new System.Drawing.Size(42, 15);
            labelIme.TabIndex = 45;
            labelIme.Text = "Name:";
            // 
            // textboxIme
            // 
            textboxIme.Location = new System.Drawing.Point(105, 20);
            textboxIme.Name = "textboxIme";
            textboxIme.Size = new System.Drawing.Size(112, 23);
            textboxIme.TabIndex = 44;
            // 
            // buttonPromeni
            // 
            buttonPromeni.Location = new System.Drawing.Point(56, 219);
            buttonPromeni.Name = "buttonPromeni";
            buttonPromeni.Size = new System.Drawing.Size(94, 37);
            buttonPromeni.TabIndex = 43;
            buttonPromeni.Text = "Update";
            buttonPromeni.UseVisualStyleBackColor = true;
            // 
            // UCUpdateGuest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxBrojTelefona);
            Controls.Add(comboBoxMesta);
            Controls.Add(dataGridViewGosti);
            Controls.Add(maskedTextBoxBrojTelefonaHotela);
            Controls.Add(textboxPrezime);
            Controls.Add(labelWebsiteHotela);
            Controls.Add(textboxEmail);
            Controls.Add(labelAdresaHotela);
            Controls.Add(labelBrojTelefonaHotela);
            Controls.Add(labelEmailHotela);
            Controls.Add(labelIme);
            Controls.Add(textboxIme);
            Controls.Add(buttonPromeni);
            Name = "UCUpdateGuest";
            Size = new System.Drawing.Size(578, 344);
            ((System.ComponentModel.ISupportInitialize)dataGridViewGosti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxBrojTelefona;
        private System.Windows.Forms.ComboBox comboBoxMesta;
        private System.Windows.Forms.DataGridView dataGridViewGosti;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBrojTelefonaHotela;
        private System.Windows.Forms.TextBox textboxPrezime;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.TextBox textboxEmail;
        private System.Windows.Forms.Label labelAdresaHotela;
        private System.Windows.Forms.Label labelBrojTelefonaHotela;
        private System.Windows.Forms.Label labelEmailHotela;
        private System.Windows.Forms.Label labelIme;
        private System.Windows.Forms.TextBox textboxIme;
        private System.Windows.Forms.Button buttonPromeni;

        public CheckBox CheckBoxBrojTelefona { get => checkBoxBrojTelefona; set => checkBoxBrojTelefona = value; }
        public ComboBox ComboBoxMesta { get => comboBoxMesta; set => comboBoxMesta = value; }
        public DataGridView DataGridViewGosti { get => dataGridViewGosti; set => dataGridViewGosti = value; }
        public MaskedTextBox MaskedTextBoxBrojTelefonaHotela { get => maskedTextBoxBrojTelefonaHotela; set => maskedTextBoxBrojTelefonaHotela = value; }
        public TextBox TextboxPrezime { get => textboxPrezime; set => textboxPrezime = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public TextBox TextboxEmail { get => textboxEmail; set => textboxEmail = value; }
        public Label LabelAdresaHotela { get => labelAdresaHotela; set => labelAdresaHotela = value; }
        public Label LabelBrojTelefonaHotela { get => labelBrojTelefonaHotela; set => labelBrojTelefonaHotela = value; }
        public Label LabelEmailHotela { get => labelEmailHotela; set => labelEmailHotela = value; }
        public Label LabelIme { get => labelIme; set => labelIme = value; }
        public TextBox TextboxIme { get => textboxIme; set => textboxIme = value; }
        public Button ButtonPromeni { get => buttonPromeni; set => buttonPromeni = value; }
    }
}
