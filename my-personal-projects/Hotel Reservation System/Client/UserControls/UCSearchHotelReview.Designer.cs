using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCSearchHotelReview
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
            buttonPretrazi = new Button();
            comboBoxImenaInstitucijaZaRecenzije = new ComboBox();
            comboBoxImenaHotela = new ComboBox();
            richTextBoxKomentar = new RichTextBox();
            label2 = new Label();
            comboBoxMinimalanBrojZvezdica = new ComboBox();
            dateTimePickerNajranijiDatum = new DateTimePicker();
            label1 = new Label();
            dataGridViewRecenzijeHotela = new DataGridView();
            label6 = new Label();
            comboBoxMaksimalanBrojZvezdica = new ComboBox();
            label7 = new Label();
            dateTimePickerNajkasnijiDatum = new DateTimePicker();
            checkBoxBrojZvezdica = new CheckBox();
            checkBoxDatum = new CheckBox();
            checkBoxKomentar = new CheckBox();
            checkBoxNazivHotela = new CheckBox();
            checkBoxNazivInstitucijeZaRecenzije = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecenzijeHotela).BeginInit();
            SuspendLayout();
            // 
            // buttonPretrazi
            // 
            buttonPretrazi.Location = new System.Drawing.Point(287, 398);
            buttonPretrazi.Name = "buttonPretrazi";
            buttonPretrazi.Size = new System.Drawing.Size(75, 23);
            buttonPretrazi.TabIndex = 30;
            buttonPretrazi.Text = "Search";
            buttonPretrazi.UseVisualStyleBackColor = true;
            // 
            // comboBoxImenaInstitucijaZaRecenzije
            // 
            comboBoxImenaInstitucijaZaRecenzije.DisplayMember = "hotelid";
            comboBoxImenaInstitucijaZaRecenzije.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImenaInstitucijaZaRecenzije.FormattingEnabled = true;
            comboBoxImenaInstitucijaZaRecenzije.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxImenaInstitucijaZaRecenzije.Location = new System.Drawing.Point(318, 347);
            comboBoxImenaInstitucijaZaRecenzije.Name = "comboBoxImenaInstitucijaZaRecenzije";
            comboBoxImenaInstitucijaZaRecenzije.Size = new System.Drawing.Size(121, 23);
            comboBoxImenaInstitucijaZaRecenzije.TabIndex = 29;
            comboBoxImenaInstitucijaZaRecenzije.ValueMember = "hotelid";
            // 
            // comboBoxImenaHotela
            // 
            comboBoxImenaHotela.DisplayMember = "hotelid";
            comboBoxImenaHotela.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImenaHotela.FormattingEnabled = true;
            comboBoxImenaHotela.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxImenaHotela.Location = new System.Drawing.Point(318, 310);
            comboBoxImenaHotela.Name = "comboBoxImenaHotela";
            comboBoxImenaHotela.Size = new System.Drawing.Size(121, 23);
            comboBoxImenaHotela.TabIndex = 28;
            comboBoxImenaHotela.ValueMember = "hotelid";
            // 
            // richTextBoxKomentar
            // 
            richTextBoxKomentar.Location = new System.Drawing.Point(241, 211);
            richTextBoxKomentar.Name = "richTextBoxKomentar";
            richTextBoxKomentar.Size = new System.Drawing.Size(211, 88);
            richTextBoxKomentar.TabIndex = 25;
            richTextBoxKomentar.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(145, 156);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(47, 15);
            label2.TabIndex = 23;
            label2.Text = "Earliest:";
            // 
            // comboBoxMinimalanBrojZvezdica
            // 
            comboBoxMinimalanBrojZvezdica.DisplayMember = "hotelid";
            comboBoxMinimalanBrojZvezdica.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMinimalanBrojZvezdica.FormattingEnabled = true;
            comboBoxMinimalanBrojZvezdica.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxMinimalanBrojZvezdica.Location = new System.Drawing.Point(145, 120);
            comboBoxMinimalanBrojZvezdica.Name = "comboBoxMinimalanBrojZvezdica";
            comboBoxMinimalanBrojZvezdica.Size = new System.Drawing.Size(121, 23);
            comboBoxMinimalanBrojZvezdica.TabIndex = 22;
            comboBoxMinimalanBrojZvezdica.ValueMember = "hotelid";
            // 
            // dateTimePickerNajranijiDatum
            // 
            dateTimePickerNajranijiDatum.Location = new System.Drawing.Point(145, 182);
            dateTimePickerNajranijiDatum.Name = "dateTimePickerNajranijiDatum";
            dateTimePickerNajranijiDatum.Size = new System.Drawing.Size(121, 23);
            dateTimePickerNajranijiDatum.TabIndex = 21;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(145, 93);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 15);
            label1.TabIndex = 20;
            label1.Text = "Min:";
            // 
            // dataGridViewRecenzijeHotela
            // 
            dataGridViewRecenzijeHotela.AllowUserToAddRows = false;
            dataGridViewRecenzijeHotela.AllowUserToDeleteRows = false;
            dataGridViewRecenzijeHotela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRecenzijeHotela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecenzijeHotela.Location = new System.Drawing.Point(463, 93);
            dataGridViewRecenzijeHotela.MultiSelect = false;
            dataGridViewRecenzijeHotela.Name = "dataGridViewRecenzijeHotela";
            dataGridViewRecenzijeHotela.ReadOnly = true;
            dataGridViewRecenzijeHotela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRecenzijeHotela.Size = new System.Drawing.Size(244, 328);
            dataGridViewRecenzijeHotela.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(307, 93);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(33, 15);
            label6.TabIndex = 31;
            label6.Text = "Max:";
            // 
            // comboBoxMaksimalanBrojZvezdica
            // 
            comboBoxMaksimalanBrojZvezdica.DisplayMember = "hotelid";
            comboBoxMaksimalanBrojZvezdica.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaksimalanBrojZvezdica.FormattingEnabled = true;
            comboBoxMaksimalanBrojZvezdica.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxMaksimalanBrojZvezdica.Location = new System.Drawing.Point(307, 120);
            comboBoxMaksimalanBrojZvezdica.Name = "comboBoxMaksimalanBrojZvezdica";
            comboBoxMaksimalanBrojZvezdica.Size = new System.Drawing.Size(121, 23);
            comboBoxMaksimalanBrojZvezdica.TabIndex = 32;
            comboBoxMaksimalanBrojZvezdica.ValueMember = "hotelid";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(307, 156);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(41, 15);
            label7.TabIndex = 34;
            label7.Text = "Latest:";
            // 
            // dateTimePickerNajkasnijiDatum
            // 
            dateTimePickerNajkasnijiDatum.Location = new System.Drawing.Point(307, 182);
            dateTimePickerNajkasnijiDatum.Name = "dateTimePickerNajkasnijiDatum";
            dateTimePickerNajkasnijiDatum.Size = new System.Drawing.Size(121, 23);
            dateTimePickerNajkasnijiDatum.TabIndex = 33;
            // 
            // checkBoxBrojZvezdica
            // 
            checkBoxBrojZvezdica.AutoSize = true;
            checkBoxBrojZvezdica.Location = new System.Drawing.Point(57, 89);
            checkBoxBrojZvezdica.Name = "checkBoxBrojZvezdica";
            checkBoxBrojZvezdica.Size = new System.Drawing.Size(54, 19);
            checkBoxBrojZvezdica.TabIndex = 35;
            checkBoxBrojZvezdica.Text = "Stars:";
            checkBoxBrojZvezdica.UseVisualStyleBackColor = true;
            // 
            // checkBoxDatum
            // 
            checkBoxDatum.AutoSize = true;
            checkBoxDatum.Location = new System.Drawing.Point(58, 152);
            checkBoxDatum.Name = "checkBoxDatum";
            checkBoxDatum.Size = new System.Drawing.Size(53, 19);
            checkBoxDatum.TabIndex = 36;
            checkBoxDatum.Text = "Date:";
            checkBoxDatum.UseVisualStyleBackColor = true;
            // 
            // checkBoxKomentar
            // 
            checkBoxKomentar.AutoSize = true;
            checkBoxKomentar.Location = new System.Drawing.Point(145, 211);
            checkBoxKomentar.Name = "checkBoxKomentar";
            checkBoxKomentar.Size = new System.Drawing.Size(83, 19);
            checkBoxKomentar.TabIndex = 37;
            checkBoxKomentar.Text = "Comment:";
            checkBoxKomentar.UseVisualStyleBackColor = true;
            // 
            // checkBoxNazivHotela
            // 
            checkBoxNazivHotela.AutoSize = true;
            checkBoxNazivHotela.Location = new System.Drawing.Point(254, 314);
            checkBoxNazivHotela.Name = "checkBoxNazivHotela";
            checkBoxNazivHotela.Size = new System.Drawing.Size(58, 19);
            checkBoxNazivHotela.TabIndex = 38;
            checkBoxNazivHotela.Text = "Hotel:";
            checkBoxNazivHotela.UseVisualStyleBackColor = true;
            // 
            // checkBoxNazivInstitucijeZaRecenzije
            // 
            checkBoxNazivInstitucijeZaRecenzije.AutoSize = true;
            checkBoxNazivInstitucijeZaRecenzije.Location = new System.Drawing.Point(189, 351);
            checkBoxNazivInstitucijeZaRecenzije.Name = "checkBoxNazivInstitucijeZaRecenzije";
            checkBoxNazivInstitucijeZaRecenzije.Size = new System.Drawing.Size(123, 19);
            checkBoxNazivInstitucijeZaRecenzije.TabIndex = 39;
            checkBoxNazivInstitucijeZaRecenzije.Text = "Review institution:";
            checkBoxNazivInstitucijeZaRecenzije.UseVisualStyleBackColor = true;
            // 
            // UCSearchHotelReview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBoxNazivInstitucijeZaRecenzije);
            Controls.Add(checkBoxNazivHotela);
            Controls.Add(checkBoxKomentar);
            Controls.Add(checkBoxDatum);
            Controls.Add(checkBoxBrojZvezdica);
            Controls.Add(label7);
            Controls.Add(dateTimePickerNajkasnijiDatum);
            Controls.Add(comboBoxMaksimalanBrojZvezdica);
            Controls.Add(label6);
            Controls.Add(buttonPretrazi);
            Controls.Add(comboBoxImenaInstitucijaZaRecenzije);
            Controls.Add(comboBoxImenaHotela);
            Controls.Add(richTextBoxKomentar);
            Controls.Add(label2);
            Controls.Add(comboBoxMinimalanBrojZvezdica);
            Controls.Add(dateTimePickerNajranijiDatum);
            Controls.Add(label1);
            Controls.Add(dataGridViewRecenzijeHotela);
            Name = "UCSearchHotelReview";
            Size = new System.Drawing.Size(782, 549);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecenzijeHotela).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonPretrazi;
        private System.Windows.Forms.ComboBox comboBoxImenaInstitucijaZaRecenzije;
        private System.Windows.Forms.ComboBox comboBoxImenaHotela;
        private System.Windows.Forms.RichTextBox richTextBoxKomentar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMinimalanBrojZvezdica;
        private System.Windows.Forms.DateTimePicker dateTimePickerNajranijiDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewRecenzijeHotela;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private ComboBox comboBoxMaksimalanBrojZvezdica;
        private Label label7;
        private DateTimePicker dateTimePickerNajkasnijiDatum;
        private CheckBox checkBoxBrojZvezdica;
        private CheckBox checkBoxDatum;
        private CheckBox checkBoxKomentar;
        private CheckBox checkBoxNazivHotela;
        private CheckBox checkBoxNazivInstitucijeZaRecenzije;

        public Button ButtonKreiraj { get => buttonPretrazi; set => buttonPretrazi = value; }
        public ComboBox ComboBoxImenaInstitucijaZaRecenzije { get => comboBoxImenaInstitucijaZaRecenzije; set => comboBoxImenaInstitucijaZaRecenzije = value; }
        public ComboBox ComboBoxHoteli { get => comboBoxImenaHotela; set => comboBoxImenaHotela = value; }
        public Label Label5 { get => label5; set => label5 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public RichTextBox RichTextBoxKomentar { get => richTextBoxKomentar; set => richTextBoxKomentar = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public ComboBox ComboBoxMinimalanBrojZvezdica { get => comboBoxMinimalanBrojZvezdica; set => comboBoxMinimalanBrojZvezdica = value; }
        public DateTimePicker DateTimePickerNajranijiDatum { get => dateTimePickerNajranijiDatum; set => dateTimePickerNajranijiDatum = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public DataGridView DataGridViewRecenzijeHotela { get => dataGridViewRecenzijeHotela; set => dataGridViewRecenzijeHotela = value; }
        public Label Label6 { get => label6; set => label6 = value; }
        public ComboBox ComboBoxMaksimalanBrojZvezdica { get => comboBoxMaksimalanBrojZvezdica; set => comboBoxMaksimalanBrojZvezdica = value; }
        public Label Label7 { get => label7; set => label7 = value; }
        public DateTimePicker DateTimePickerNajkasnijiDatum { get => dateTimePickerNajkasnijiDatum; set => dateTimePickerNajkasnijiDatum = value; }
        public CheckBox CheckBoxBrojZvezdica { get => checkBoxBrojZvezdica; set => checkBoxBrojZvezdica = value; }
        public CheckBox CheckBoxDatum { get => checkBoxDatum; set => checkBoxDatum = value; }
        public CheckBox CheckBoxKomentar { get => checkBoxKomentar; set => checkBoxKomentar = value; }
        public CheckBox CheckBoxNazivHotela { get => checkBoxNazivHotela; set => checkBoxNazivHotela = value; }
        public CheckBox CheckBoxNazivInstitucijeZaRecenzije { get => checkBoxNazivInstitucijeZaRecenzije; set => checkBoxNazivInstitucijeZaRecenzije = value; }
    }
}
