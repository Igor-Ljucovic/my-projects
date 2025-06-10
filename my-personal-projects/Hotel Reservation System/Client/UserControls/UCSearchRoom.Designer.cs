using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCSearchRoom
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
            textBoxBrojSobe = new TextBox();
            textBoxCenaPoNociDinMinimum = new TextBox();
            comboBoxHotel = new ComboBox();
            comboBoxTipSobe = new ComboBox();
            dataGridViewSobe = new DataGridView();
            textboxPovrsinaUm2Minimum = new TextBox();
            labelAdresaHotela = new Label();
            labelBrojTelefonaHotela = new Label();
            buttonPretrazi = new Button();
            checkBoxNazivIHotela = new CheckBox();
            checkBoxTipSobe = new CheckBox();
            checkBoxBrojSobe = new CheckBox();
            checkBoxPovrsinaUm2 = new CheckBox();
            checkBoxCenaPoNociDin = new CheckBox();
            textBoxCenaPoNociDinMaximum = new TextBox();
            textboxPovrsinaUm2Maximum = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSobe).BeginInit();
            SuspendLayout();
            // 
            // textBoxBrojSobe
            // 
            textBoxBrojSobe.Location = new System.Drawing.Point(293, 14);
            textBoxBrojSobe.Name = "textBoxBrojSobe";
            textBoxBrojSobe.Size = new System.Drawing.Size(112, 23);
            textBoxBrojSobe.TabIndex = 56;
            // 
            // textBoxCenaPoNociDinMinimum
            // 
            textBoxCenaPoNociDinMinimum.Location = new System.Drawing.Point(245, 90);
            textBoxCenaPoNociDinMinimum.Name = "textBoxCenaPoNociDinMinimum";
            textBoxCenaPoNociDinMinimum.Size = new System.Drawing.Size(112, 23);
            textBoxCenaPoNociDinMinimum.TabIndex = 55;
            // 
            // comboBoxHotel
            // 
            comboBoxHotel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHotel.FormattingEnabled = true;
            comboBoxHotel.Location = new System.Drawing.Point(245, 234);
            comboBoxHotel.Name = "comboBoxHotel";
            comboBoxHotel.Size = new System.Drawing.Size(121, 23);
            comboBoxHotel.TabIndex = 54;
            // 
            // comboBoxTipSobe
            // 
            comboBoxTipSobe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipSobe.FormattingEnabled = true;
            comboBoxTipSobe.Location = new System.Drawing.Point(293, 52);
            comboBoxTipSobe.Name = "comboBoxTipSobe";
            comboBoxTipSobe.Size = new System.Drawing.Size(121, 23);
            comboBoxTipSobe.TabIndex = 53;
            // 
            // dataGridViewSobe
            // 
            dataGridViewSobe.AllowUserToAddRows = false;
            dataGridViewSobe.AllowUserToDeleteRows = false;
            dataGridViewSobe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSobe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSobe.Location = new System.Drawing.Point(438, 14);
            dataGridViewSobe.MultiSelect = false;
            dataGridViewSobe.Name = "dataGridViewSobe";
            dataGridViewSobe.ReadOnly = true;
            dataGridViewSobe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSobe.Size = new System.Drawing.Size(230, 298);
            dataGridViewSobe.TabIndex = 52;
            // 
            // textboxPovrsinaUm2Minimum
            // 
            textboxPovrsinaUm2Minimum.Location = new System.Drawing.Point(245, 157);
            textboxPovrsinaUm2Minimum.Name = "textboxPovrsinaUm2Minimum";
            textboxPovrsinaUm2Minimum.Size = new System.Drawing.Size(112, 23);
            textboxPovrsinaUm2Minimum.TabIndex = 51;
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(200, 165);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(31, 15);
            labelAdresaHotela.TabIndex = 49;
            labelAdresaHotela.Text = "min:";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(202, 98);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(31, 15);
            labelBrojTelefonaHotela.TabIndex = 48;
            labelBrojTelefonaHotela.Text = "min:";
            // 
            // buttonPretrazi
            // 
            buttonPretrazi.Location = new System.Drawing.Point(263, 275);
            buttonPretrazi.Name = "buttonPretrazi";
            buttonPretrazi.Size = new System.Drawing.Size(94, 37);
            buttonPretrazi.TabIndex = 45;
            buttonPretrazi.Text = "Search";
            buttonPretrazi.UseVisualStyleBackColor = true;
            // 
            // checkBoxNazivIHotela
            // 
            checkBoxNazivIHotela.AutoSize = true;
            checkBoxNazivIHotela.Location = new System.Drawing.Point(176, 238);
            checkBoxNazivIHotela.Name = "checkBoxNazivIHotela";
            checkBoxNazivIHotela.Size = new System.Drawing.Size(58, 19);
            checkBoxNazivIHotela.TabIndex = 59;
            checkBoxNazivIHotela.Text = "Hotel:";
            checkBoxNazivIHotela.UseVisualStyleBackColor = true;
            // 
            // checkBoxTipSobe
            // 
            checkBoxTipSobe.AutoSize = true;
            checkBoxTipSobe.Location = new System.Drawing.Point(181, 56);
            checkBoxTipSobe.Name = "checkBoxTipSobe";
            checkBoxTipSobe.Size = new System.Drawing.Size(87, 19);
            checkBoxTipSobe.TabIndex = 58;
            checkBoxTipSobe.Text = "Room type:";
            checkBoxTipSobe.UseVisualStyleBackColor = true;
            // 
            // checkBoxBrojSobe
            // 
            checkBoxBrojSobe.AutoSize = true;
            checkBoxBrojSobe.Location = new System.Drawing.Point(181, 18);
            checkBoxBrojSobe.Name = "checkBoxBrojSobe";
            checkBoxBrojSobe.Size = new System.Drawing.Size(106, 19);
            checkBoxBrojSobe.TabIndex = 57;
            checkBoxBrojSobe.Text = "Room number:";
            checkBoxBrojSobe.UseVisualStyleBackColor = true;
            // 
            // checkBoxPovrsinaUm2
            // 
            checkBoxPovrsinaUm2.AutoSize = true;
            checkBoxPovrsinaUm2.Location = new System.Drawing.Point(26, 161);
            checkBoxPovrsinaUm2.Name = "checkBoxPovrsinaUm2";
            checkBoxPovrsinaUm2.Size = new System.Drawing.Size(109, 19);
            checkBoxPovrsinaUm2.TabIndex = 60;
            checkBoxPovrsinaUm2.Text = "Surface (in m2):";
            checkBoxPovrsinaUm2.UseVisualStyleBackColor = true;
            // 
            // checkBoxCenaPoNociDin
            // 
            checkBoxCenaPoNociDin.AutoSize = true;
            checkBoxCenaPoNociDin.Location = new System.Drawing.Point(26, 90);
            checkBoxCenaPoNociDin.Name = "checkBoxCenaPoNociDin";
            checkBoxCenaPoNociDin.Size = new System.Drawing.Size(144, 19);
            checkBoxCenaPoNociDin.TabIndex = 61;
            checkBoxCenaPoNociDin.Text = "Night price (in dinars):";
            checkBoxCenaPoNociDin.UseVisualStyleBackColor = true;
            // 
            // textBoxCenaPoNociDinMaximum
            // 
            textBoxCenaPoNociDinMaximum.Location = new System.Drawing.Point(245, 122);
            textBoxCenaPoNociDinMaximum.Name = "textBoxCenaPoNociDinMaximum";
            textBoxCenaPoNociDinMaximum.Size = new System.Drawing.Size(112, 23);
            textBoxCenaPoNociDinMaximum.TabIndex = 62;
            // 
            // textboxPovrsinaUm2Maximum
            // 
            textboxPovrsinaUm2Maximum.Location = new System.Drawing.Point(245, 195);
            textboxPovrsinaUm2Maximum.Name = "textboxPovrsinaUm2Maximum";
            textboxPovrsinaUm2Maximum.Size = new System.Drawing.Size(112, 23);
            textboxPovrsinaUm2Maximum.TabIndex = 63;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(200, 130);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 15);
            label1.TabIndex = 64;
            label1.Text = "max:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(198, 203);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(33, 15);
            label2.TabIndex = 65;
            label2.Text = "max:";
            // 
            // UCSearchRoom
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textboxPovrsinaUm2Maximum);
            Controls.Add(textBoxCenaPoNociDinMaximum);
            Controls.Add(checkBoxCenaPoNociDin);
            Controls.Add(checkBoxPovrsinaUm2);
            Controls.Add(checkBoxNazivIHotela);
            Controls.Add(checkBoxTipSobe);
            Controls.Add(checkBoxBrojSobe);
            Controls.Add(textBoxBrojSobe);
            Controls.Add(textBoxCenaPoNociDinMinimum);
            Controls.Add(comboBoxHotel);
            Controls.Add(comboBoxTipSobe);
            Controls.Add(dataGridViewSobe);
            Controls.Add(textboxPovrsinaUm2Minimum);
            Controls.Add(labelAdresaHotela);
            Controls.Add(labelBrojTelefonaHotela);
            Controls.Add(buttonPretrazi);
            Name = "UCSearchRoom";
            Size = new System.Drawing.Size(681, 337);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSobe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBrojSobe;
        private System.Windows.Forms.TextBox textBoxCenaPoNociDinMinimum;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.ComboBox comboBoxTipSobe;
        private System.Windows.Forms.DataGridView dataGridViewSobe;
        private System.Windows.Forms.TextBox textboxPovrsinaUm2Minimum;
        private System.Windows.Forms.Label labelAdresaHotela;
        private System.Windows.Forms.Label labelBrojTelefonaHotela;
        private System.Windows.Forms.Button buttonPretrazi;
        private System.Windows.Forms.CheckBox checkBoxNazivIHotela;
        private System.Windows.Forms.CheckBox checkBoxTipSobe;
        private System.Windows.Forms.CheckBox checkBoxBrojSobe;
        private System.Windows.Forms.CheckBox checkBoxPovrsinaUm2;
        private System.Windows.Forms.CheckBox checkBoxCenaPoNociDin;
        private System.Windows.Forms.TextBox textBoxCenaPoNociDinMaximum;
        private System.Windows.Forms.TextBox textboxPovrsinaUm2Maximum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        public TextBox TextBoxBrojSobe { get => textBoxBrojSobe; set => textBoxBrojSobe = value; }
        public TextBox TextBoxCenaPoNociDinMinimum { get => textBoxCenaPoNociDinMinimum; set => textBoxCenaPoNociDinMinimum = value; }
        public ComboBox ComboBoxHotel { get => comboBoxHotel; set => comboBoxHotel = value; }
        public ComboBox ComboBoxTipSobe { get => comboBoxTipSobe; set => comboBoxTipSobe = value; }
        public DataGridView DataGridViewSobe { get => dataGridViewSobe; set => dataGridViewSobe = value; }
        public TextBox TextboxPovrsinaUm2Minimum { get => textboxPovrsinaUm2Minimum; set => textboxPovrsinaUm2Minimum = value; }
        public Label LabelAdresaHotela { get => labelAdresaHotela; set => labelAdresaHotela = value; }
        public Label LabelBrojTelefonaHotela { get => labelBrojTelefonaHotela; set => labelBrojTelefonaHotela = value; }
        public Button ButtonPretrazi { get => buttonPretrazi; set => buttonPretrazi = value; }
        public CheckBox CheckBoxNazivHotela { get => checkBoxNazivIHotela; set => checkBoxNazivIHotela = value; }
        public CheckBox CheckBoxTipSobe { get => checkBoxTipSobe; set => checkBoxTipSobe = value; }
        public CheckBox CheckBoxBrojSobe { get => checkBoxBrojSobe; set => checkBoxBrojSobe = value; }
        public CheckBox CheckBoxPovrsinaUm2 { get => checkBoxPovrsinaUm2; set => checkBoxPovrsinaUm2 = value; }
        public CheckBox CheckBoxCenaPoNociDin { get => checkBoxCenaPoNociDin; set => checkBoxCenaPoNociDin = value; }
        public TextBox TextBoxCenaPoNociDinMaximum { get => textBoxCenaPoNociDinMaximum; set => textBoxCenaPoNociDinMaximum = value; }
        public TextBox TextboxPovrsinaUm2Maximum { get => textboxPovrsinaUm2Maximum; set => textboxPovrsinaUm2Maximum = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
    }
}
