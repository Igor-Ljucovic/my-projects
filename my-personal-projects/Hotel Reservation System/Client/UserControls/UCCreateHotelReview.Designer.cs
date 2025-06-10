using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateHotelReview
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
            richTextBoxKomentar = new RichTextBox();
            label3 = new Label();
            label2 = new Label();
            comboBoxBrojZvezdica = new ComboBox();
            dateTimePickerDatum = new DateTimePicker();
            label1 = new Label();
            dataGridViewRecenzijeHotela = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            comboBoxImenaHotela = new ComboBox();
            comboBoxImenaInstitucijaZaRecenzije = new ComboBox();
            buttonKreiraj = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecenzijeHotela).BeginInit();
            SuspendLayout();
            // 
            // richTextBoxKomentar
            // 
            richTextBoxKomentar.Location = new System.Drawing.Point(120, 112);
            richTextBoxKomentar.Name = "richTextBoxKomentar";
            richTextBoxKomentar.Size = new System.Drawing.Size(211, 88);
            richTextBoxKomentar.TabIndex = 13;
            richTextBoxKomentar.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(46, 115);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 15);
            label3.TabIndex = 12;
            label3.Text = "Comment:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(62, 80);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 11;
            label2.Text = "Date:";
            // 
            // comboBoxBrojZvezdica
            // 
            comboBoxBrojZvezdica.DisplayMember = "hotelid";
            comboBoxBrojZvezdica.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxBrojZvezdica.FormattingEnabled = true;
            comboBoxBrojZvezdica.Location = new System.Drawing.Point(120, 33);
            comboBoxBrojZvezdica.Name = "comboBoxBrojZvezdica";
            comboBoxBrojZvezdica.Size = new System.Drawing.Size(121, 23);
            comboBoxBrojZvezdica.TabIndex = 10;
            comboBoxBrojZvezdica.ValueMember = "hotelid";
            // 
            // dateTimePickerDatum
            // 
            dateTimePickerDatum.Location = new System.Drawing.Point(120, 74);
            dateTimePickerDatum.Name = "dateTimePickerDatum";
            dateTimePickerDatum.Size = new System.Drawing.Size(211, 23);
            dateTimePickerDatum.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(62, 41);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 15);
            label1.TabIndex = 8;
            label1.Text = "Stars:";
            // 
            // dataGridViewRecenzijeHotela
            // 
            dataGridViewRecenzijeHotela.AllowUserToAddRows = false;
            dataGridViewRecenzijeHotela.AllowUserToDeleteRows = false;
            dataGridViewRecenzijeHotela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRecenzijeHotela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecenzijeHotela.Location = new System.Drawing.Point(342, 31);
            dataGridViewRecenzijeHotela.MultiSelect = false;
            dataGridViewRecenzijeHotela.Name = "dataGridViewRecenzijeHotela";
            dataGridViewRecenzijeHotela.ReadOnly = true;
            dataGridViewRecenzijeHotela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRecenzijeHotela.Size = new System.Drawing.Size(206, 291);
            dataGridViewRecenzijeHotela.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(152, 219);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(39, 15);
            label4.TabIndex = 14;
            label4.Text = "Hotel:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(87, 256);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 15);
            label5.TabIndex = 15;
            label5.Text = "Review institution:";
            // 
            // comboBoxImenaHotela
            // 
            comboBoxImenaHotela.DisplayMember = "hotelid";
            comboBoxImenaHotela.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImenaHotela.FormattingEnabled = true;
            comboBoxImenaHotela.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxImenaHotela.Location = new System.Drawing.Point(197, 211);
            comboBoxImenaHotela.Name = "comboBoxImenaHotela";
            comboBoxImenaHotela.Size = new System.Drawing.Size(121, 23);
            comboBoxImenaHotela.TabIndex = 16;
            comboBoxImenaHotela.ValueMember = "hotelid";
            // 
            // comboBoxImenaInstitucijaZaRecenzije
            // 
            comboBoxImenaInstitucijaZaRecenzije.DisplayMember = "hotelid";
            comboBoxImenaInstitucijaZaRecenzije.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxImenaInstitucijaZaRecenzije.FormattingEnabled = true;
            comboBoxImenaInstitucijaZaRecenzije.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxImenaInstitucijaZaRecenzije.Location = new System.Drawing.Point(197, 248);
            comboBoxImenaInstitucijaZaRecenzije.Name = "comboBoxImenaInstitucijaZaRecenzije";
            comboBoxImenaInstitucijaZaRecenzije.Size = new System.Drawing.Size(121, 23);
            comboBoxImenaInstitucijaZaRecenzije.TabIndex = 17;
            comboBoxImenaInstitucijaZaRecenzije.ValueMember = "hotelid";
            // 
            // buttonKreiraj
            // 
            buttonKreiraj.Location = new System.Drawing.Point(166, 299);
            buttonKreiraj.Name = "buttonKreiraj";
            buttonKreiraj.Size = new System.Drawing.Size(75, 23);
            buttonKreiraj.TabIndex = 18;
            buttonKreiraj.Text = "Create";
            buttonKreiraj.UseVisualStyleBackColor = true;
            // 
            // UCCreateHotelReview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonKreiraj);
            Controls.Add(comboBoxImenaInstitucijaZaRecenzije);
            Controls.Add(comboBoxImenaHotela);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(richTextBoxKomentar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBoxBrojZvezdica);
            Controls.Add(dateTimePickerDatum);
            Controls.Add(label1);
            Controls.Add(dataGridViewRecenzijeHotela);
            Name = "UCCreateHotelReview";
            Size = new System.Drawing.Size(579, 353);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecenzijeHotela).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxKomentar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBrojZvezdica;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewRecenzijeHotela;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxImenaHotela;
        private System.Windows.Forms.ComboBox comboBoxImenaInstitucijaZaRecenzije;
        private System.Windows.Forms.Button buttonKreiraj;

        public RichTextBox RichTextBoxKomentar { get => richTextBoxKomentar; set => richTextBoxKomentar = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public ComboBox ComboBoxBrojZvezdica { get => comboBoxBrojZvezdica; set => comboBoxBrojZvezdica = value; }
        public DateTimePicker DateTimePickerDatum { get => dateTimePickerDatum; set => dateTimePickerDatum = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public DataGridView DataGridViewRecenzijeHotela { get => dataGridViewRecenzijeHotela; set => dataGridViewRecenzijeHotela = value; }
        public Button ButtonKreiraj { get => buttonKreiraj; set => buttonKreiraj = value; }
        public ComboBox ComboBoxImenaHotela { get => comboBoxImenaHotela; set => comboBoxImenaHotela = value; }
        public ComboBox ComboBoxImenaInstitucijaZaRecenzije { get => comboBoxImenaInstitucijaZaRecenzije; set => comboBoxImenaInstitucijaZaRecenzije = value; }
    }
}
