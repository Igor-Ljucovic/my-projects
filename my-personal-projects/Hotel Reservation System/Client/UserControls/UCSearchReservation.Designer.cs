using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCSearchReservation
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
            comboBoxHoteli = new ComboBox();
            comboBoxGosti = new ComboBox();
            dataGridViewRezervacije = new DataGridView();
            buttonPretraziRezervacije = new Button();
            checkBoxDatum = new CheckBox();
            dateTimePickerNajkasnijiDatum = new DateTimePicker();
            dateTimePickerNajranijiDatum = new DateTimePicker();
            checkBoxGost = new CheckBox();
            checkBoxHotel = new CheckBox();
            buttonPretraziStavkeRezervacije = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervacije).BeginInit();
            SuspendLayout();
            // 
            // comboBoxHoteli
            // 
            comboBoxHoteli.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHoteli.FormattingEnabled = true;
            comboBoxHoteli.Location = new System.Drawing.Point(180, 211);
            comboBoxHoteli.Name = "comboBoxHoteli";
            comboBoxHoteli.Size = new System.Drawing.Size(121, 23);
            comboBoxHoteli.TabIndex = 62;
            // 
            // comboBoxGosti
            // 
            comboBoxGosti.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGosti.FormattingEnabled = true;
            comboBoxGosti.Location = new System.Drawing.Point(180, 255);
            comboBoxGosti.Name = "comboBoxGosti";
            comboBoxGosti.Size = new System.Drawing.Size(121, 23);
            comboBoxGosti.TabIndex = 61;
            // 
            // dataGridViewRezervacije
            // 
            dataGridViewRezervacije.AllowUserToAddRows = false;
            dataGridViewRezervacije.AllowUserToDeleteRows = false;
            dataGridViewRezervacije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRezervacije.Location = new System.Drawing.Point(394, 66);
            dataGridViewRezervacije.MultiSelect = false;
            dataGridViewRezervacije.Name = "dataGridViewRezervacije";
            dataGridViewRezervacije.ReadOnly = true;
            dataGridViewRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRezervacije.Size = new System.Drawing.Size(383, 304);
            dataGridViewRezervacije.TabIndex = 60;
            // 
            // buttonPretraziRezervacije
            // 
            buttonPretraziRezervacije.Location = new System.Drawing.Point(59, 333);
            buttonPretraziRezervacije.Name = "buttonPretraziRezervacije";
            buttonPretraziRezervacije.Size = new System.Drawing.Size(134, 37);
            buttonPretraziRezervacije.TabIndex = 56;
            buttonPretraziRezervacije.Text = "Search reservations";
            buttonPretraziRezervacije.UseVisualStyleBackColor = true;
            // 
            // checkBoxDatum
            // 
            checkBoxDatum.AutoSize = true;
            checkBoxDatum.Location = new System.Drawing.Point(45, 66);
            checkBoxDatum.Name = "checkBoxDatum";
            checkBoxDatum.Size = new System.Drawing.Size(53, 19);
            checkBoxDatum.TabIndex = 68;
            checkBoxDatum.Text = "Date:";
            checkBoxDatum.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerNajkasnijiDatum
            // 
            dateTimePickerNajkasnijiDatum.Location = new System.Drawing.Point(150, 150);
            dateTimePickerNajkasnijiDatum.Name = "dateTimePickerNajkasnijiDatum";
            dateTimePickerNajkasnijiDatum.Size = new System.Drawing.Size(226, 23);
            dateTimePickerNajkasnijiDatum.TabIndex = 66;
            // 
            // dateTimePickerNajranijiDatum
            // 
            dateTimePickerNajranijiDatum.Location = new System.Drawing.Point(150, 102);
            dateTimePickerNajranijiDatum.Name = "dateTimePickerNajranijiDatum";
            dateTimePickerNajranijiDatum.Size = new System.Drawing.Size(226, 23);
            dateTimePickerNajranijiDatum.TabIndex = 64;
            // 
            // checkBoxGost
            // 
            checkBoxGost.AutoSize = true;
            checkBoxGost.Location = new System.Drawing.Point(121, 259);
            checkBoxGost.Name = "checkBoxGost";
            checkBoxGost.Size = new System.Drawing.Size(59, 19);
            checkBoxGost.TabIndex = 69;
            checkBoxGost.Text = "Guest:";
            checkBoxGost.UseVisualStyleBackColor = true;
            // 
            // checkBoxHotel
            // 
            checkBoxHotel.AutoSize = true;
            checkBoxHotel.Location = new System.Drawing.Point(116, 215);
            checkBoxHotel.Name = "checkBoxHotel";
            checkBoxHotel.Size = new System.Drawing.Size(58, 19);
            checkBoxHotel.TabIndex = 70;
            checkBoxHotel.Text = "Hotel:";
            checkBoxHotel.UseVisualStyleBackColor = true;
            // 
            // buttonPretraziStavkeRezervacije
            // 
            buttonPretraziStavkeRezervacije.Location = new System.Drawing.Point(225, 333);
            buttonPretraziStavkeRezervacije.Name = "buttonPretraziStavkeRezervacije";
            buttonPretraziStavkeRezervacije.Size = new System.Drawing.Size(151, 37);
            buttonPretraziStavkeRezervacije.TabIndex = 71;
            buttonPretraziStavkeRezervacije.Text = "Search reservation items";
            buttonPretraziStavkeRezervacije.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(90, 110);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(47, 15);
            label1.TabIndex = 72;
            label1.Text = "Earliest:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(96, 156);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(41, 15);
            label2.TabIndex = 73;
            label2.Text = "Latest:";
            // 
            // UCSearchReservation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonPretraziStavkeRezervacije);
            Controls.Add(checkBoxHotel);
            Controls.Add(checkBoxGost);
            Controls.Add(checkBoxDatum);
            Controls.Add(dateTimePickerNajkasnijiDatum);
            Controls.Add(dateTimePickerNajranijiDatum);
            Controls.Add(comboBoxHoteli);
            Controls.Add(comboBoxGosti);
            Controls.Add(dataGridViewRezervacije);
            Controls.Add(buttonPretraziRezervacije);
            Name = "UCSearchReservation";
            Size = new System.Drawing.Size(805, 406);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxHoteli;
        private System.Windows.Forms.ComboBox comboBoxGosti;
        private System.Windows.Forms.DataGridView dataGridViewRezervacije;
        private System.Windows.Forms.Button buttonPretraziRezervacije;
        private System.Windows.Forms.CheckBox checkBoxDatum;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.DateTimePicker dateTimePickerNajkasnijiDatum;
        private System.Windows.Forms.Label labelImeGosta;
        private System.Windows.Forms.DateTimePicker dateTimePickerNajranijiDatum;
        private System.Windows.Forms.CheckBox checkBoxGost;
        private System.Windows.Forms.CheckBox checkBoxHotel;
        private System.Windows.Forms.Button buttonPretraziStavkeRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        public ComboBox ComboBoxHoteli { get => comboBoxHoteli; set => comboBoxHoteli = value; }
        public ComboBox ComboBoxGosti { get => comboBoxGosti; set => comboBoxGosti = value; }
        public DataGridView DataGridViewRezervacije { get => dataGridViewRezervacije; set => dataGridViewRezervacije = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public Label LabelImeGosta { get => labelImeGosta; set => labelImeGosta = value; }
        public Button ButtonPretrazi { get => buttonPretraziRezervacije; set => buttonPretraziRezervacije = value; }
        public CheckBox CheckBoxDatum { get => checkBoxDatum; set => checkBoxDatum = value; }
        public DateTimePicker DateTimePickerNajkasnijiDatum { get => dateTimePickerNajkasnijiDatum; set => dateTimePickerNajkasnijiDatum = value; }
        public DateTimePicker DateTimePickerNajranijiDatum { get => dateTimePickerNajranijiDatum; set => dateTimePickerNajranijiDatum = value; }
        public CheckBox CheckBoxGost { get => checkBoxGost; set => checkBoxGost = value; }
        public CheckBox CheckBoxHotel { get => checkBoxHotel; set => checkBoxHotel = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
    }
}
