using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateReservation
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
            labelWebsiteHotela = new Label();
            labelImeGosta = new Label();
            labelDatum = new Label();
            buttonKreiraj = new Button();
            dateTimeDatum = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervacije).BeginInit();
            SuspendLayout();
            // 
            // comboBoxHoteli
            // 
            comboBoxHoteli.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHoteli.FormattingEnabled = true;
            comboBoxHoteli.Location = new System.Drawing.Point(184, 141);
            comboBoxHoteli.Name = "comboBoxHoteli";
            comboBoxHoteli.Size = new System.Drawing.Size(121, 23);
            comboBoxHoteli.TabIndex = 54;
            // 
            // comboBoxGosti
            // 
            comboBoxGosti.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGosti.FormattingEnabled = true;
            comboBoxGosti.Location = new System.Drawing.Point(184, 185);
            comboBoxGosti.Name = "comboBoxGosti";
            comboBoxGosti.Size = new System.Drawing.Size(121, 23);
            comboBoxGosti.TabIndex = 53;
            // 
            // dataGridViewRezervacije
            // 
            dataGridViewRezervacije.AllowUserToAddRows = false;
            dataGridViewRezervacije.AllowUserToDeleteRows = false;
            dataGridViewRezervacije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRezervacije.Location = new System.Drawing.Point(330, 31);
            dataGridViewRezervacije.MultiSelect = false;
            dataGridViewRezervacije.Name = "dataGridViewRezervacije";
            dataGridViewRezervacije.ReadOnly = true;
            dataGridViewRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRezervacije.Size = new System.Drawing.Size(347, 267);
            dataGridViewRezervacije.TabIndex = 52;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(139, 149);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(39, 15);
            labelWebsiteHotela.TabIndex = 50;
            labelWebsiteHotela.Text = "Hotel:";
            // 
            // labelImeGosta
            // 
            labelImeGosta.AutoSize = true;
            labelImeGosta.Location = new System.Drawing.Point(144, 193);
            labelImeGosta.Name = "labelImeGosta";
            labelImeGosta.Size = new System.Drawing.Size(40, 15);
            labelImeGosta.TabIndex = 47;
            labelImeGosta.Text = "Guest:";
            // 
            // labelDatum
            // 
            labelDatum.AutoSize = true;
            labelDatum.Location = new System.Drawing.Point(42, 101);
            labelDatum.Name = "labelDatum";
            labelDatum.Size = new System.Drawing.Size(34, 15);
            labelDatum.TabIndex = 46;
            labelDatum.Text = "Date:";
            // 
            // buttonKreiraj
            // 
            buttonKreiraj.Location = new System.Drawing.Point(122, 261);
            buttonKreiraj.Name = "buttonKreiraj";
            buttonKreiraj.Size = new System.Drawing.Size(112, 37);
            buttonKreiraj.TabIndex = 45;
            buttonKreiraj.Text = "Create";
            buttonKreiraj.UseVisualStyleBackColor = true;
            // 
            // dateTimeDatum
            // 
            dateTimeDatum.Location = new System.Drawing.Point(105, 93);
            dateTimeDatum.Name = "dateTimeDatum";
            dateTimeDatum.Size = new System.Drawing.Size(200, 23);
            dateTimeDatum.TabIndex = 55;
            // 
            // UCCreateReservation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dateTimeDatum);
            Controls.Add(comboBoxHoteli);
            Controls.Add(comboBoxGosti);
            Controls.Add(dataGridViewRezervacije);
            Controls.Add(labelWebsiteHotela);
            Controls.Add(labelImeGosta);
            Controls.Add(labelDatum);
            Controls.Add(buttonKreiraj);
            Name = "UCCreateReservation";
            Size = new System.Drawing.Size(693, 327);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBrojSobe;
        private System.Windows.Forms.ComboBox comboBoxHoteli;
        private System.Windows.Forms.ComboBox comboBoxGosti;
        private System.Windows.Forms.DataGridView dataGridViewRezervacije;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.Label labelImeGosta;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Button buttonKreiraj;
        private System.Windows.Forms.DateTimePicker dateTimeDatum;

        public TextBox TextBoxBrojSobe { get => textBoxBrojSobe; set => textBoxBrojSobe = value; }
        public ComboBox ComboBoxHoteli { get => comboBoxHoteli; set => comboBoxHoteli = value; }
        public ComboBox ComboBoxGosti { get => comboBoxGosti; set => comboBoxGosti = value; }
        public DataGridView DataGridViewRezervacije { get => dataGridViewRezervacije; set => dataGridViewRezervacije = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public Label LabelImeGosta { get => labelImeGosta; set => labelImeGosta = value; }
        public Label LabelDatum { get => labelDatum; set => labelDatum = value; }
        public Button ButtonKreiraj { get => buttonKreiraj; set => buttonKreiraj = value; }
        public DateTimePicker DateTimeDatum { get => dateTimeDatum; set => dateTimeDatum = value; }
    }
}
