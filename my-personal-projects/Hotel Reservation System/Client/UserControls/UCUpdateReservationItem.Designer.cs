using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateReservationItem
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
            labelCenaStavkeDin = new Label();
            label4 = new Label();
            comboBoxSobe = new ComboBox();
            dateTimePickerKraj = new DateTimePicker();
            dateTimePickerPocetak = new DateTimePicker();
            dataGridViewStavkeRezervacije = new DataGridView();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonPromeni = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStavkeRezervacije).BeginInit();
            SuspendLayout();
            // 
            // labelCenaStavkeDin
            // 
            labelCenaStavkeDin.AutoSize = true;
            labelCenaStavkeDin.Location = new System.Drawing.Point(139, 277);
            labelCenaStavkeDin.Name = "labelCenaStavkeDin";
            labelCenaStavkeDin.Size = new System.Drawing.Size(13, 15);
            labelCenaStavkeDin.TabIndex = 27;
            labelCenaStavkeDin.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(42, 277);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(92, 15);
            label4.TabIndex = 26;
            label4.Text = "Price (in dinars):";
            // 
            // comboBoxSobe
            // 
            comboBoxSobe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSobe.FormattingEnabled = true;
            comboBoxSobe.Location = new System.Drawing.Point(139, 229);
            comboBoxSobe.Name = "comboBoxSobe";
            comboBoxSobe.Size = new System.Drawing.Size(121, 23);
            comboBoxSobe.TabIndex = 25;
            // 
            // dateTimePickerKraj
            // 
            dateTimePickerKraj.Location = new System.Drawing.Point(139, 184);
            dateTimePickerKraj.Name = "dateTimePickerKraj";
            dateTimePickerKraj.Size = new System.Drawing.Size(200, 23);
            dateTimePickerKraj.TabIndex = 24;
            // 
            // dateTimePickerPocetak
            // 
            dateTimePickerPocetak.Location = new System.Drawing.Point(139, 138);
            dateTimePickerPocetak.Name = "dateTimePickerPocetak";
            dateTimePickerPocetak.Size = new System.Drawing.Size(200, 23);
            dateTimePickerPocetak.TabIndex = 23;
            // 
            // dataGridViewStavkeRezervacije
            // 
            dataGridViewStavkeRezervacije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewStavkeRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStavkeRezervacije.Location = new System.Drawing.Point(361, 88);
            dataGridViewStavkeRezervacije.MultiSelect = false;
            dataGridViewStavkeRezervacije.Name = "dataGridViewStavkeRezervacije";
            dataGridViewStavkeRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStavkeRezervacije.Size = new System.Drawing.Size(301, 240);
            dataGridViewStavkeRezervacije.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(97, 237);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(42, 15);
            label3.TabIndex = 21;
            label3.Text = "Room:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(62, 190);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 20;
            label2.Text = "Ending date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(56, 144);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 15);
            label1.TabIndex = 19;
            label1.Text = "Starting date:";
            // 
            // buttonPromeni
            // 
            buttonPromeni.Location = new System.Drawing.Point(178, 307);
            buttonPromeni.Name = "buttonPromeni";
            buttonPromeni.Size = new System.Drawing.Size(75, 23);
            buttonPromeni.TabIndex = 18;
            buttonPromeni.Text = "Update";
            buttonPromeni.UseVisualStyleBackColor = true;
            // 
            // UCUpdateReservationItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelCenaStavkeDin);
            Controls.Add(label4);
            Controls.Add(comboBoxSobe);
            Controls.Add(dateTimePickerKraj);
            Controls.Add(dateTimePickerPocetak);
            Controls.Add(dataGridViewStavkeRezervacije);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonPromeni);
            Name = "UCUpdateReservationItem";
            Size = new System.Drawing.Size(704, 419);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStavkeRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelCenaStavkeDin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSobe;
        private System.Windows.Forms.DateTimePicker dateTimePickerKraj;
        private System.Windows.Forms.DateTimePicker dateTimePickerPocetak;
        private System.Windows.Forms.DataGridView dataGridViewStavkeRezervacije;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPromeni;

        public Label LabelCenaStavkeDin { get => labelCenaStavkeDin; set => labelCenaStavkeDin = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public ComboBox ComboBoxSobe { get => comboBoxSobe; set => comboBoxSobe = value; }
        public DateTimePicker DateTimePickerKraj { get => dateTimePickerKraj; set => dateTimePickerKraj = value; }
        public DateTimePicker DateTimePickerPocetak { get => dateTimePickerPocetak; set => dateTimePickerPocetak = value; }
        public DataGridView DataGridViewStavkeRezervacije { get => dataGridViewStavkeRezervacije; set => dataGridViewStavkeRezervacije = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Button ButtonPromeni { get => buttonPromeni; set => buttonPromeni = value; }
    }
}
