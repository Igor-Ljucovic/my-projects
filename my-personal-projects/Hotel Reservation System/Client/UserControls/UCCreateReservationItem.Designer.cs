using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateReservationItem
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
            dateTimePickerKraj = new DateTimePicker();
            dateTimePickerPocetak = new DateTimePicker();
            dataGridViewStavkeRezervacije = new DataGridView();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonDodaj = new Button();
            label4 = new Label();
            labelCenaStavkeDin = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewStavkeRezervacije).BeginInit();
            SuspendLayout();
            // 
            // comboBoxSobe
            // 
            comboBoxSobe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSobe.FormattingEnabled = true;
            comboBoxSobe.Location = new System.Drawing.Point(113, 204);
            comboBoxSobe.Name = "comboBoxSobe";
            comboBoxSobe.Size = new System.Drawing.Size(121, 23);
            comboBoxSobe.TabIndex = 15;
            // 
            // dateTimePickerKraj
            // 
            dateTimePickerKraj.Location = new System.Drawing.Point(113, 159);
            dateTimePickerKraj.Name = "dateTimePickerKraj";
            dateTimePickerKraj.Size = new System.Drawing.Size(200, 23);
            dateTimePickerKraj.TabIndex = 14;
            // 
            // dateTimePickerPocetak
            // 
            dateTimePickerPocetak.Location = new System.Drawing.Point(113, 113);
            dateTimePickerPocetak.Name = "dateTimePickerPocetak";
            dateTimePickerPocetak.Size = new System.Drawing.Size(200, 23);
            dateTimePickerPocetak.TabIndex = 13;
            // 
            // dataGridViewStavkeRezervacije
            // 
            dataGridViewStavkeRezervacije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewStavkeRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewStavkeRezervacije.Location = new System.Drawing.Point(335, 63);
            dataGridViewStavkeRezervacije.MultiSelect = false;
            dataGridViewStavkeRezervacije.Name = "dataGridViewStavkeRezervacije";
            dataGridViewStavkeRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewStavkeRezervacije.Size = new System.Drawing.Size(278, 240);
            dataGridViewStavkeRezervacije.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(71, 212);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(42, 15);
            label3.TabIndex = 11;
            label3.Text = "Room:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(36, 165);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(73, 15);
            label2.TabIndex = 10;
            label2.Text = "Ending date:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 119);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(77, 15);
            label1.TabIndex = 9;
            label1.Text = "Starting date:";
            // 
            // buttonDodaj
            // 
            buttonDodaj.Location = new System.Drawing.Point(152, 282);
            buttonDodaj.Name = "buttonDodaj";
            buttonDodaj.Size = new System.Drawing.Size(82, 31);
            buttonDodaj.TabIndex = 8;
            buttonDodaj.Text = "Create";
            buttonDodaj.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 252);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(92, 15);
            label4.TabIndex = 16;
            label4.Text = "Price (in dinars):";
            // 
            // labelCenaStavkeDin
            // 
            labelCenaStavkeDin.AutoSize = true;
            labelCenaStavkeDin.Location = new System.Drawing.Point(113, 252);
            labelCenaStavkeDin.Name = "labelCenaStavkeDin";
            labelCenaStavkeDin.Size = new System.Drawing.Size(13, 15);
            labelCenaStavkeDin.TabIndex = 17;
            labelCenaStavkeDin.Text = "0";
            // 
            // UCCreateReservationItem
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
            Controls.Add(buttonDodaj);
            Name = "UCCreateReservationItem";
            Size = new System.Drawing.Size(629, 367);
            ((System.ComponentModel.ISupportInitialize)dataGridViewStavkeRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSobe;
        private System.Windows.Forms.DateTimePicker dateTimePickerKraj;
        private System.Windows.Forms.DateTimePicker dateTimePickerPocetak;
        private System.Windows.Forms.DataGridView dataGridViewStavkeRezervacije;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCenaStavkeDin;

        public ComboBox ComboBoxSobe { get => comboBoxSobe; set => comboBoxSobe = value; }
        public DateTimePicker DateTimePickerKraj { get => dateTimePickerKraj; set => dateTimePickerKraj = value; }
        public DateTimePicker DateTimePickerPocetak { get => dateTimePickerPocetak; set => dateTimePickerPocetak = value; }
        public DataGridView DataGridViewStavkeRezervacije { get => dataGridViewStavkeRezervacije; set => dataGridViewStavkeRezervacije = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Button ButtonDodaj { get => buttonDodaj; set => buttonDodaj = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public Label LabelCenaStavkeDin { get => labelCenaStavkeDin; set => labelCenaStavkeDin = value; }
    }
}
