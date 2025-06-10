using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateReservation
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
            dateTimeDatum = new DateTimePicker();
            comboBoxHoteli = new ComboBox();
            comboBoxGosti = new ComboBox();
            dataGridViewRezervacije = new DataGridView();
            labelWebsiteHotela = new Label();
            labelImeGosta = new Label();
            labelDatum = new Label();
            buttonPromeniRezervaciju = new Button();
            buttonPromeniStavkeRezervacije = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervacije).BeginInit();
            SuspendLayout();
            // 
            // dateTimeDatum
            // 
            dateTimeDatum.Location = new System.Drawing.Point(119, 114);
            dateTimeDatum.Name = "dateTimeDatum";
            dateTimeDatum.Size = new System.Drawing.Size(161, 23);
            dateTimeDatum.TabIndex = 63;
            // 
            // comboBoxHoteli
            // 
            comboBoxHoteli.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHoteli.FormattingEnabled = true;
            comboBoxHoteli.Location = new System.Drawing.Point(159, 162);
            comboBoxHoteli.Name = "comboBoxHoteli";
            comboBoxHoteli.Size = new System.Drawing.Size(121, 23);
            comboBoxHoteli.TabIndex = 62;
            // 
            // comboBoxGosti
            // 
            comboBoxGosti.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGosti.FormattingEnabled = true;
            comboBoxGosti.Location = new System.Drawing.Point(159, 206);
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
            dataGridViewRezervacije.Location = new System.Drawing.Point(305, 52);
            dataGridViewRezervacije.MultiSelect = false;
            dataGridViewRezervacije.Name = "dataGridViewRezervacije";
            dataGridViewRezervacije.ReadOnly = true;
            dataGridViewRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRezervacije.Size = new System.Drawing.Size(352, 267);
            dataGridViewRezervacije.TabIndex = 60;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(114, 170);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(39, 15);
            labelWebsiteHotela.TabIndex = 59;
            labelWebsiteHotela.Text = "Hotel:";
            // 
            // labelImeGosta
            // 
            labelImeGosta.AutoSize = true;
            labelImeGosta.Location = new System.Drawing.Point(119, 214);
            labelImeGosta.Name = "labelImeGosta";
            labelImeGosta.Size = new System.Drawing.Size(40, 15);
            labelImeGosta.TabIndex = 58;
            labelImeGosta.Text = "Guest:";
            // 
            // labelDatum
            // 
            labelDatum.AutoSize = true;
            labelDatum.Location = new System.Drawing.Point(32, 122);
            labelDatum.Name = "labelDatum";
            labelDatum.Size = new System.Drawing.Size(81, 15);
            labelDatum.TabIndex = 57;
            labelDatum.Text = "Creation date:";
            // 
            // buttonPromeniRezervaciju
            // 
            buttonPromeniRezervaciju.Location = new System.Drawing.Point(17, 279);
            buttonPromeniRezervaciju.Name = "buttonPromeniRezervaciju";
            buttonPromeniRezervaciju.Size = new System.Drawing.Size(120, 40);
            buttonPromeniRezervaciju.TabIndex = 56;
            buttonPromeniRezervaciju.Text = "Update reservation";
            buttonPromeniRezervaciju.UseVisualStyleBackColor = true;
            // 
            // buttonPromeniStavkeRezervacije
            // 
            buttonPromeniStavkeRezervacije.Location = new System.Drawing.Point(159, 279);
            buttonPromeniStavkeRezervacije.Name = "buttonPromeniStavkeRezervacije";
            buttonPromeniStavkeRezervacije.Size = new System.Drawing.Size(120, 40);
            buttonPromeniStavkeRezervacije.TabIndex = 64;
            buttonPromeniStavkeRezervacije.Text = "Update reservation item";
            buttonPromeniStavkeRezervacije.UseVisualStyleBackColor = true;
            // 
            // UCUpdateReservation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonPromeniStavkeRezervacije);
            Controls.Add(dateTimeDatum);
            Controls.Add(comboBoxHoteli);
            Controls.Add(comboBoxGosti);
            Controls.Add(dataGridViewRezervacije);
            Controls.Add(labelWebsiteHotela);
            Controls.Add(labelImeGosta);
            Controls.Add(labelDatum);
            Controls.Add(buttonPromeniRezervaciju);
            Name = "UCUpdateReservation";
            Size = new System.Drawing.Size(677, 371);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRezervacije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeDatum;
        private System.Windows.Forms.ComboBox comboBoxHoteli;
        private System.Windows.Forms.ComboBox comboBoxGosti;
        private System.Windows.Forms.DataGridView dataGridViewRezervacije;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.Label labelImeGosta;
        private System.Windows.Forms.Label labelDatum;
        private System.Windows.Forms.Button buttonPromeniRezervaciju;
        private System.Windows.Forms.Button buttonPromeniStavkeRezervacije;

        public DateTimePicker DateTimeDatum { get => dateTimeDatum; set => dateTimeDatum = value; }
        public ComboBox ComboBoxHoteli { get => comboBoxHoteli; set => comboBoxHoteli = value; }
        public ComboBox ComboBoxGosti { get => comboBoxGosti; set => comboBoxGosti = value; }
        public DataGridView DataGridViewRezervacije { get => dataGridViewRezervacije; set => dataGridViewRezervacije = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public Label LabelImeGosta { get => labelImeGosta; set => labelImeGosta = value; }
        public Label LabelDatum { get => labelDatum; set => labelDatum = value; }
        public Button ButtonDodajStavke { get => buttonPromeniRezervaciju; set => buttonPromeniRezervaciju = value; }
        public Button ButtonPromeniStavkuRezervacije { get => buttonPromeniStavkeRezervacije; set => buttonPromeniStavkeRezervacije = value; }
    }
}
