using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateRoom
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
            textBoxCenaPoNociDin = new TextBox();
            comboBoxHotel = new ComboBox();
            comboBoxTipSobe = new ComboBox();
            dataGridViewSobe = new DataGridView();
            textboxPovrsinaUm2 = new TextBox();
            labelWebsiteHotela = new Label();
            labelAdresaHotela = new Label();
            labelBrojTelefonaHotela = new Label();
            labelEmailHotela = new Label();
            labelNazivHotela = new Label();
            buttonPromeni = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSobe).BeginInit();
            SuspendLayout();
            // 
            // textBoxBrojSobe
            // 
            textBoxBrojSobe.Location = new System.Drawing.Point(133, 27);
            textBoxBrojSobe.Name = "textBoxBrojSobe";
            textBoxBrojSobe.Size = new System.Drawing.Size(112, 23);
            textBoxBrojSobe.TabIndex = 56;
            // 
            // textBoxCenaPoNociDin
            // 
            textBoxCenaPoNociDin.Location = new System.Drawing.Point(133, 103);
            textBoxCenaPoNociDin.Name = "textBoxCenaPoNociDin";
            textBoxCenaPoNociDin.Size = new System.Drawing.Size(112, 23);
            textBoxCenaPoNociDin.TabIndex = 55;
            // 
            // comboBoxHotel
            // 
            comboBoxHotel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHotel.FormattingEnabled = true;
            comboBoxHotel.Location = new System.Drawing.Point(133, 175);
            comboBoxHotel.Name = "comboBoxHotel";
            comboBoxHotel.Size = new System.Drawing.Size(121, 23);
            comboBoxHotel.TabIndex = 54;
            // 
            // comboBoxTipSobe
            // 
            comboBoxTipSobe.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipSobe.FormattingEnabled = true;
            comboBoxTipSobe.Location = new System.Drawing.Point(133, 65);
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
            dataGridViewSobe.Location = new System.Drawing.Point(262, 30);
            dataGridViewSobe.MultiSelect = false;
            dataGridViewSobe.Name = "dataGridViewSobe";
            dataGridViewSobe.ReadOnly = true;
            dataGridViewSobe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSobe.Size = new System.Drawing.Size(257, 236);
            dataGridViewSobe.TabIndex = 52;
            // 
            // textboxPovrsinaUm2
            // 
            textboxPovrsinaUm2.Location = new System.Drawing.Point(133, 139);
            textboxPovrsinaUm2.Name = "textboxPovrsinaUm2";
            textboxPovrsinaUm2.Size = new System.Drawing.Size(112, 23);
            textboxPovrsinaUm2.TabIndex = 51;
            // 
            // labelWebsiteHotela
            // 
            labelWebsiteHotela.AutoSize = true;
            labelWebsiteHotela.Location = new System.Drawing.Point(88, 183);
            labelWebsiteHotela.Name = "labelWebsiteHotela";
            labelWebsiteHotela.Size = new System.Drawing.Size(39, 15);
            labelWebsiteHotela.TabIndex = 50;
            labelWebsiteHotela.Text = "Hotel:";
            // 
            // labelAdresaHotela
            // 
            labelAdresaHotela.AutoSize = true;
            labelAdresaHotela.Location = new System.Drawing.Point(37, 147);
            labelAdresaHotela.Name = "labelAdresaHotela";
            labelAdresaHotela.Size = new System.Drawing.Size(90, 15);
            labelAdresaHotela.TabIndex = 49;
            labelAdresaHotela.Text = "Surface (in m2):";
            // 
            // labelBrojTelefonaHotela
            // 
            labelBrojTelefonaHotela.AutoSize = true;
            labelBrojTelefonaHotela.Location = new System.Drawing.Point(3, 111);
            labelBrojTelefonaHotela.Name = "labelBrojTelefonaHotela";
            labelBrojTelefonaHotela.Size = new System.Drawing.Size(125, 15);
            labelBrojTelefonaHotela.TabIndex = 48;
            labelBrojTelefonaHotela.Text = "Night price (in dinars):";
            // 
            // labelEmailHotela
            // 
            labelEmailHotela.AutoSize = true;
            labelEmailHotela.Location = new System.Drawing.Point(59, 73);
            labelEmailHotela.Name = "labelEmailHotela";
            labelEmailHotela.Size = new System.Drawing.Size(68, 15);
            labelEmailHotela.TabIndex = 47;
            labelEmailHotela.Text = "Room type:";
            // 
            // labelNazivHotela
            // 
            labelNazivHotela.AutoSize = true;
            labelNazivHotela.Location = new System.Drawing.Point(37, 35);
            labelNazivHotela.Name = "labelNazivHotela";
            labelNazivHotela.Size = new System.Drawing.Size(87, 15);
            labelNazivHotela.TabIndex = 46;
            labelNazivHotela.Text = "Room number:";
            // 
            // buttonPromeni
            // 
            buttonPromeni.Location = new System.Drawing.Point(47, 229);
            buttonPromeni.Name = "buttonPromeni";
            buttonPromeni.Size = new System.Drawing.Size(94, 37);
            buttonPromeni.TabIndex = 45;
            buttonPromeni.Text = "Update";
            buttonPromeni.UseVisualStyleBackColor = true;
            // 
            // UCUpdateRoom
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxBrojSobe);
            Controls.Add(textBoxCenaPoNociDin);
            Controls.Add(comboBoxHotel);
            Controls.Add(comboBoxTipSobe);
            Controls.Add(dataGridViewSobe);
            Controls.Add(textboxPovrsinaUm2);
            Controls.Add(labelWebsiteHotela);
            Controls.Add(labelAdresaHotela);
            Controls.Add(labelBrojTelefonaHotela);
            Controls.Add(labelEmailHotela);
            Controls.Add(labelNazivHotela);
            Controls.Add(buttonPromeni);
            Name = "UCUpdateRoom";
            Size = new System.Drawing.Size(551, 331);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSobe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBrojSobe;
        private System.Windows.Forms.TextBox textBoxCenaPoNociDin;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.ComboBox comboBoxTipSobe;
        private System.Windows.Forms.DataGridView dataGridViewSobe;
        private System.Windows.Forms.TextBox textboxPovrsinaUm2;
        private System.Windows.Forms.Label labelWebsiteHotela;
        private System.Windows.Forms.Label labelAdresaHotela;
        private System.Windows.Forms.Label labelBrojTelefonaHotela;
        private System.Windows.Forms.Label labelEmailHotela;
        private System.Windows.Forms.Label labelNazivHotela;
        private System.Windows.Forms.Button buttonPromeni;

        public TextBox TextBoxBrojSobe { get => textBoxBrojSobe; set => textBoxBrojSobe = value; }
        public TextBox TextBoxCenaPoNociDin { get => textBoxCenaPoNociDin; set => textBoxCenaPoNociDin = value; }
        public ComboBox ComboBoxHotel { get => comboBoxHotel; set => comboBoxHotel = value; }
        public ComboBox ComboBoxTipSobe { get => comboBoxTipSobe; set => comboBoxTipSobe = value; }
        public DataGridView DataGridViewSobe { get => dataGridViewSobe; set => dataGridViewSobe = value; }
        public TextBox TextboxPovrsinaUm2 { get => textboxPovrsinaUm2; set => textboxPovrsinaUm2 = value; }
        public Label LabelWebsiteHotela { get => labelWebsiteHotela; set => labelWebsiteHotela = value; }
        public Label LabelAdresaHotela { get => labelAdresaHotela; set => labelAdresaHotela = value; }
        public Label LabelBrojTelefonaHotela { get => labelBrojTelefonaHotela; set => labelBrojTelefonaHotela = value; }
        public Label LabelEmailHotela { get => labelEmailHotela; set => labelEmailHotela = value; }
        public Label LabelNazivHotela { get => labelNazivHotela; set => labelNazivHotela = value; }
        public Button ButtonPromeni { get => buttonPromeni; set => buttonPromeni = value; }
    }
}
