using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCSearchReservationItem
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
            comboBoxSobe = new ComboBox();
            dateTimePickerNajkasnijiDatumPocetka = new DateTimePicker();
            dateTimePickerNajranijiDatumPocetka = new DateTimePicker();
            dataGridViewStavkeRezervacije = new DataGridView();
            label2 = new Label();
            label1 = new Label();
            buttonPretrazi = new Button();
            checkBoxDatumPocetka = new CheckBox();
            checkBoxCena = new CheckBox();
            checkBoxSoba = new CheckBox();
            textBoxNajmanjaCena = new TextBox();
            textBoxNajvecaCena = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textboxNajveciBrojNocenja = new TextBox();
            textboxNajmanjiBrojNocenja = new TextBox();
            checkBoxBrojNocenja = new CheckBox();
            checkBoxDatumKraja = new CheckBox();
            dateTimePickerNajkasnijiDatumKraja = new DateTimePicker();
            dateTimePickerNajranijiDatumKraja = new DateTimePicker();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStavkeRezervacije).BeginInit();
            SuspendLayout();
            // 
            // comboBoxSobe
            // 
            comboBoxSobe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSobe.FormattingEnabled = true;
            comboBoxSobe.Location = new System.Drawing.Point(127, 279);
            comboBoxSobe.Name = "comboBoxSobe";
            comboBoxSobe.Size = new System.Drawing.Size(121, 23);
            comboBoxSobe.TabIndex = 25;
            // 
            // dateTimePickerNajkasnijiDatumPocetka
            // 
            dateTimePickerNajkasnijiDatumPocetka.Location = new System.Drawing.Point(127, 145);
            dateTimePickerNajkasnijiDatumPocetka.Name = "dateTimePickerNajkasnijiDatumPocetka";
            dateTimePickerNajkasnijiDatumPocetka.Size = new System.Drawing.Size(200, 23);
            dateTimePickerNajkasnijiDatumPocetka.TabIndex = 24;
            // 
            // dateTimePickerNajranijiDatumPocetka
            // 
            dateTimePickerNajranijiDatumPocetka.Location = new System.Drawing.Point(127, 111);
            dateTimePickerNajranijiDatumPocetka.Name = "dateTimePickerNajranijiDatumPocetka";
            dateTimePickerNajranijiDatumPocetka.Size = new System.Drawing.Size(200, 23);
            dateTimePickerNajranijiDatumPocetka.TabIndex = 23;
            // 
            // dataGridViewStavkeRezervacije
            // 
            dataGridViewStavkeRezervacije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewStavkeRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStavkeRezervacije.Location = new System.Drawing.Point(342, 83);
            dataGridViewStavkeRezervacije.MultiSelect = false;
            dataGridViewStavkeRezervacije.Name = "dataGridViewStavkeRezervacije";
            dataGridViewStavkeRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStavkeRezervacije.Size = new System.Drawing.Size(278, 438);
            dataGridViewStavkeRezervacije.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(73, 151);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 15);
            label2.TabIndex = 20;
            label2.Text = "Latest:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(67, 119);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 15);
            label1.TabIndex = 19;
            label1.Text = "Earliest:";
            // 
            // buttonPretrazi
            // 
            buttonPretrazi.Location = new System.Drawing.Point(161, 498);
            buttonPretrazi.Name = "buttonPretrazi";
            buttonPretrazi.Size = new System.Drawing.Size(75, 23);
            buttonPretrazi.TabIndex = 18;
            buttonPretrazi.Text = "Search";
            buttonPretrazi.UseVisualStyleBackColor = true;
            // 
            // checkBoxDatumPocetka
            // 
            checkBoxDatumPocetka.AutoSize = true;
            checkBoxDatumPocetka.Location = new System.Drawing.Point(42, 83);
            checkBoxDatumPocetka.Name = "checkBoxDatumPocetka";
            checkBoxDatumPocetka.Size = new System.Drawing.Size(96, 19);
            checkBoxDatumPocetka.TabIndex = 69;
            checkBoxDatumPocetka.Text = "Starting date:";
            checkBoxDatumPocetka.UseVisualStyleBackColor = true;
            // 
            // checkBoxCena
            // 
            checkBoxCena.AutoSize = true;
            checkBoxCena.Location = new System.Drawing.Point(42, 310);
            checkBoxCena.Name = "checkBoxCena";
            checkBoxCena.Size = new System.Drawing.Size(55, 19);
            checkBoxCena.TabIndex = 70;
            checkBoxCena.Text = "Price:";
            checkBoxCena.UseVisualStyleBackColor = true;
            // 
            // checkBoxSoba
            // 
            checkBoxSoba.AutoSize = true;
            checkBoxSoba.Location = new System.Drawing.Point(42, 283);
            checkBoxSoba.Name = "checkBoxSoba";
            checkBoxSoba.Size = new System.Drawing.Size(61, 19);
            checkBoxSoba.TabIndex = 71;
            checkBoxSoba.Text = "Room:";
            checkBoxSoba.UseVisualStyleBackColor = true;
            // 
            // textBoxNajmanjaCena
            // 
            textBoxNajmanjaCena.Location = new System.Drawing.Point(152, 337);
            textBoxNajmanjaCena.Name = "textBoxNajmanjaCena";
            textBoxNajmanjaCena.Size = new System.Drawing.Size(84, 23);
            textBoxNajmanjaCena.TabIndex = 72;
            // 
            // textBoxNajvecaCena
            // 
            textBoxNajvecaCena.Location = new System.Drawing.Point(152, 368);
            textBoxNajvecaCena.Name = "textBoxNajvecaCena";
            textBoxNajvecaCena.Size = new System.Drawing.Size(84, 23);
            textBoxNajvecaCena.TabIndex = 73;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(103, 345);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(31, 15);
            label3.TabIndex = 74;
            label3.Text = "Min:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(101, 376);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(33, 15);
            label4.TabIndex = 75;
            label4.Text = "Max:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(101, 472);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(33, 15);
            label5.TabIndex = 80;
            label5.Text = "Max:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(103, 441);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(31, 15);
            label6.TabIndex = 79;
            label6.Text = "Min:";
            // 
            // textboxNajveciBrojNocenja
            // 
            textboxNajveciBrojNocenja.Location = new System.Drawing.Point(152, 464);
            textboxNajveciBrojNocenja.Name = "textboxNajveciBrojNocenja";
            textboxNajveciBrojNocenja.Size = new System.Drawing.Size(84, 23);
            textboxNajveciBrojNocenja.TabIndex = 78;
            // 
            // textboxNajmanjiBrojNocenja
            // 
            textboxNajmanjiBrojNocenja.Location = new System.Drawing.Point(152, 433);
            textboxNajmanjiBrojNocenja.Name = "textboxNajmanjiBrojNocenja";
            textboxNajmanjiBrojNocenja.Size = new System.Drawing.Size(84, 23);
            textboxNajmanjiBrojNocenja.TabIndex = 77;
            // 
            // checkBoxBrojNocenja
            // 
            checkBoxBrojNocenja.AutoSize = true;
            checkBoxBrojNocenja.Location = new System.Drawing.Point(42, 406);
            checkBoxBrojNocenja.Name = "checkBoxBrojNocenja";
            checkBoxBrojNocenja.Size = new System.Drawing.Size(64, 19);
            checkBoxBrojNocenja.TabIndex = 76;
            checkBoxBrojNocenja.Text = "Nights:";
            checkBoxBrojNocenja.UseVisualStyleBackColor = true;
            // 
            // checkBoxDatumKraja
            // 
            checkBoxDatumKraja.AutoSize = true;
            checkBoxDatumKraja.Location = new System.Drawing.Point(42, 181);
            checkBoxDatumKraja.Name = "checkBoxDatumKraja";
            checkBoxDatumKraja.Size = new System.Drawing.Size(92, 19);
            checkBoxDatumKraja.TabIndex = 85;
            checkBoxDatumKraja.Text = "Ending date:";
            checkBoxDatumKraja.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNajkasnijiDatumKraja
            // 
            dateTimePickerNajkasnijiDatumKraja.Location = new System.Drawing.Point(127, 242);
            dateTimePickerNajkasnijiDatumKraja.Name = "dateTimePickerNajkasnijiDatumKraja";
            dateTimePickerNajkasnijiDatumKraja.Size = new System.Drawing.Size(200, 23);
            dateTimePickerNajkasnijiDatumKraja.TabIndex = 84;
            // 
            // dateTimePickerNajranijiDatumKraja
            // 
            dateTimePickerNajranijiDatumKraja.Location = new System.Drawing.Point(127, 209);
            dateTimePickerNajranijiDatumKraja.Name = "dateTimePickerNajranijiDatumKraja";
            dateTimePickerNajranijiDatumKraja.Size = new System.Drawing.Size(200, 23);
            dateTimePickerNajranijiDatumKraja.TabIndex = 83;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(73, 250);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(41, 15);
            label7.TabIndex = 82;
            label7.Text = "Latest:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(67, 217);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(47, 15);
            label8.TabIndex = 81;
            label8.Text = "Earliest:";
            // 
            // UCSearchReservationItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxDatumKraja);
            Controls.Add(dateTimePickerNajkasnijiDatumKraja);
            Controls.Add(dateTimePickerNajranijiDatumKraja);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(textboxNajveciBrojNocenja);
            Controls.Add(textboxNajmanjiBrojNocenja);
            Controls.Add(checkBoxBrojNocenja);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxNajvecaCena);
            Controls.Add(textBoxNajmanjaCena);
            Controls.Add(checkBoxSoba);
            Controls.Add(checkBoxCena);
            Controls.Add(checkBoxDatumPocetka);
            Controls.Add(comboBoxSobe);
            Controls.Add(dateTimePickerNajkasnijiDatumPocetka);
            Controls.Add(dateTimePickerNajranijiDatumPocetka);
            Controls.Add(dataGridViewStavkeRezervacije);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonPretrazi);
            Name = "UCSearchReservationItem";
            Size = new System.Drawing.Size(643, 546);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStavkeRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSobe;
        private System.Windows.Forms.DateTimePicker dateTimePickerNajkasnijiDatumPocetka;
        private System.Windows.Forms.DateTimePicker dateTimePickerNajranijiDatumPocetka;
        private System.Windows.Forms.DataGridView dataGridViewStavkeRezervacije;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPretrazi;
        private CheckBox checkBoxDatumPocetka;
        private CheckBox checkBoxCena;
        private CheckBox checkBoxSoba;
        private TextBox textBoxNajmanjaCena;
        private TextBox textBoxNajvecaCena;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textboxNajveciBrojNocenja;
        private TextBox textboxNajmanjiBrojNocenja;
        private CheckBox checkBoxBrojNocenja;
        private CheckBox checkBoxDatumKraja;
        private DateTimePicker dateTimePickerNajkasnijiDatumKraja;
        private DateTimePicker dateTimePickerNajranijiDatumKraja;
        private Label label7;
        private Label label8;

        public ComboBox ComboBoxSobe { get => comboBoxSobe; set => comboBoxSobe = value; }
        public DateTimePicker DateTimePickerNajkasnijiDatumPocetka { get => dateTimePickerNajkasnijiDatumPocetka; set => dateTimePickerNajkasnijiDatumPocetka = value; }
        public DateTimePicker DateTimePickerNajranijiDatumPocetka { get => dateTimePickerNajranijiDatumPocetka; set => dateTimePickerNajranijiDatumPocetka = value; }
        public DataGridView DataGridViewStavkeRezervacije { get => dataGridViewStavkeRezervacije; set => dataGridViewStavkeRezervacije = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Button ButtonPretrazi { get => buttonPretrazi; set => buttonPretrazi = value; }
        public CheckBox CheckBoxDatumPocetka { get => checkBoxDatumPocetka; set => checkBoxDatumPocetka = value; }
        public CheckBox CheckBoxCena { get => checkBoxCena; set => checkBoxCena = value; }
        public CheckBox CheckBoxSoba { get => checkBoxSoba; set => checkBoxSoba = value; }
        public TextBox TextBoxNajmanjaCena { get => textBoxNajmanjaCena; set => textBoxNajmanjaCena = value; }
        public TextBox TextBoxNajvecaCena { get => textBoxNajvecaCena; set => textBoxNajvecaCena = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label Label5 { get => label5; set => label5 = value; }
        public Label Label6 { get => label6; set => label6 = value; }
        public TextBox TextboxNajveciBrojNocenja { get => textboxNajveciBrojNocenja; set => textboxNajveciBrojNocenja = value; }
        public TextBox TextboxNajmanjiBrojNocenja { get => textboxNajmanjiBrojNocenja; set => textboxNajmanjiBrojNocenja = value; }
        public CheckBox CheckBoxBrojNocenja { get => checkBoxBrojNocenja; set => checkBoxBrojNocenja = value; }
        public CheckBox CheckBoxDatumKraja { get => checkBoxDatumKraja; set => checkBoxDatumKraja = value; }
        public DateTimePicker DateTimePickerNajkasnijiDatumKraja { get => dateTimePickerNajkasnijiDatumKraja; set => dateTimePickerNajkasnijiDatumKraja = value; }
        public DateTimePicker DateTimePickerNajranijiDatumKraja { get => dateTimePickerNajranijiDatumKraja; set => dateTimePickerNajranijiDatumKraja = value; }
        public Label Label7 { get => label7; set => label7 = value; }
        public Label Label8 { get => label8; set => label8 = value; }
    }
}
