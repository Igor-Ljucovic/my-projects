using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateGuest
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
            buttonKreiraj = new Button();
            comboBoxMesta = new ComboBox();
            checkBoxBrojTelefona = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGosti).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewGosti
            // 
            dataGridViewGosti.AllowUserToAddRows = false;
            dataGridViewGosti.AllowUserToDeleteRows = false;
            dataGridViewGosti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewGosti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGosti.Location = new System.Drawing.Point(243, 18);
            dataGridViewGosti.MultiSelect = false;
            dataGridViewGosti.Name = "dataGridViewGosti";
            dataGridViewGosti.ReadOnly = true;
            dataGridViewGosti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGosti.Size = new System.Drawing.Size(240, 236);
            dataGridViewGosti.TabIndex = 40;
            // 
            // maskedTextBoxBrojTelefonaHotela
            // 
            maskedTextBoxBrojTelefonaHotela.Location = new System.Drawing.Point(105, 147);
            maskedTextBoxBrojTelefonaHotela.Mask = "0000000000";
            maskedTextBoxBrojTelefonaHotela.Name = "maskedTextBoxBrojTelefonaHotela";
            maskedTextBoxBrojTelefonaHotela.PromptChar = ' ';
            maskedTextBoxBrojTelefonaHotela.Size = new System.Drawing.Size(112, 23);
            maskedTextBoxBrojTelefonaHotela.TabIndex = 39;
            // 
            // textboxPrezime
            // 
            textboxPrezime.Location = new System.Drawing.Point(105, 50);
            textboxPrezime.Name = "textboxPrezime";
            textboxPrezime.Size = new System.Drawing.Size(112, 23);
            textboxPrezime.TabIndex = 37;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(25, 192);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(56, 15);
            labelWebsiteHotela.TabIndex = 36;
            labelWebsiteHotela.Text = "Location:";
            // 
            // textboxEmail
            // 
            textboxEmail.Location = new System.Drawing.Point(105, 84);
            textboxEmail.Name = "textboxEmail";
            textboxEmail.Size = new System.Drawing.Size(112, 23);
            textboxEmail.TabIndex = 35;
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(25, 58);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(57, 15);
            labelAdresaHotela.TabIndex = 34;
            labelAdresaHotela.Text = "Surname:";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(10, 155);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(89, 15);
            labelBrojTelefonaHotela.TabIndex = 33;
            labelBrojTelefonaHotela.Text = "Phone number:";
            // 
            // labelEmailHotela
            // 
            labelEmailHotela.AutoSize = true;
            labelEmailHotela.Location = new System.Drawing.Point(25, 91);
            labelEmailHotela.Name = "labelEmailHotela";
            labelEmailHotela.Size = new System.Drawing.Size(39, 15);
            labelEmailHotela.TabIndex = 32;
            labelEmailHotela.Text = "Email:";
            // 
            // labelIme
            // 
            labelIme.AutoSize = true;
            labelIme.Location = new System.Drawing.Point(25, 23);
            labelIme.Name = "labelIme";
            labelIme.Size = new System.Drawing.Size(42, 15);
            labelIme.TabIndex = 31;
            labelIme.Text = "Name:";
            // 
            // textboxIme
            // 
            textboxIme.Location = new System.Drawing.Point(105, 18);
            textboxIme.Name = "textboxIme";
            textboxIme.Size = new System.Drawing.Size(112, 23);
            textboxIme.TabIndex = 30;
            // 
            // buttonKreiraj
            // 
            buttonKreiraj.Location = new System.Drawing.Point(56, 217);
            buttonKreiraj.Name = "buttonKreiraj";
            buttonKreiraj.Size = new System.Drawing.Size(94, 37);
            buttonKreiraj.TabIndex = 29;
            buttonKreiraj.Text = "Create";
            buttonKreiraj.UseVisualStyleBackColor = true;
            // 
            // comboBoxMesta
            // 
            comboBoxMesta.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMesta.FormattingEnabled = true;
            comboBoxMesta.Location = new System.Drawing.Point(105, 184);
            comboBoxMesta.Name = "comboBoxMesta";
            comboBoxMesta.Size = new System.Drawing.Size(121, 23);
            comboBoxMesta.TabIndex = 41;
            // 
            // checkBoxBrojTelefona
            // 
            checkBoxBrojTelefona.AutoSize = true;
            checkBoxBrojTelefona.Location = new System.Drawing.Point(25, 122);
            checkBoxBrojTelefona.Name = "checkBoxBrojTelefona";
            checkBoxBrojTelefona.Size = new System.Drawing.Size(204, 19);
            checkBoxBrojTelefona.TabIndex = 42;
            checkBoxBrojTelefona.Text = "I want to enter my phone number";
            checkBoxBrojTelefona.UseVisualStyleBackColor = true;
            // 
            // UCCreateGuest
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
            Controls.Add(buttonKreiraj);
            Name = "UCCreateGuest";
            Size = new System.Drawing.Size(538, 282);
            ((System.ComponentModel.ISupportInitialize)dataGridViewGosti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private System.Windows.Forms.Button buttonKreiraj;
        private System.Windows.Forms.ComboBox comboBoxMesta;
        private System.Windows.Forms.CheckBox checkBoxBrojTelefona;

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
        public Button ButtonKreiraj { get => buttonKreiraj; set => buttonKreiraj = value; }
        public ComboBox ComboBoxMesta { get => comboBoxMesta; set => comboBoxMesta = value; }
        public CheckBox CheckBoxBrojTelefona { get => checkBoxBrojTelefona; set => checkBoxBrojTelefona = value; }
    }
}
