using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateReviewInstitution
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
            textboxOpis = new TextBox();
            labelOpisInstitucijeZaRecenzije = new Label();
            dataGridViewInstitucijeZaRecenzije = new DataGridView();
            labelNazivInstitucijeZaRecenzije = new Label();
            textboxNaziv = new TextBox();
            buttonPromeni = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstitucijeZaRecenzije).BeginInit();
            SuspendLayout();
            // 
            // textboxOpis
            // 
            textboxOpis.Location = new System.Drawing.Point(112, 193);
            textboxOpis.Name = "textboxOpis";
            textboxOpis.Size = new System.Drawing.Size(112, 23);
            textboxOpis.TabIndex = 52;
            // 
            // labelOpisInstitucijeZaRecenzije
            // 
            labelOpisInstitucijeZaRecenzije.AutoSize = true;
            labelOpisInstitucijeZaRecenzije.Location = new System.Drawing.Point(32, 201);
            labelOpisInstitucijeZaRecenzije.Name = "labelOpisInstitucijeZaRecenzije";
            labelOpisInstitucijeZaRecenzije.Size = new System.Drawing.Size(70, 15);
            labelOpisInstitucijeZaRecenzije.TabIndex = 51;
            labelOpisInstitucijeZaRecenzije.Text = "Description:";
            // 
            // dataGridViewInstitucijeZaRecenzije
            // 
            dataGridViewInstitucijeZaRecenzije.AllowUserToAddRows = false;
            dataGridViewInstitucijeZaRecenzije.AllowUserToDeleteRows = false;
            dataGridViewInstitucijeZaRecenzije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInstitucijeZaRecenzije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInstitucijeZaRecenzije.Location = new System.Drawing.Point(260, 35);
            dataGridViewInstitucijeZaRecenzije.MultiSelect = false;
            dataGridViewInstitucijeZaRecenzije.Name = "dataGridViewInstitucijeZaRecenzije";
            dataGridViewInstitucijeZaRecenzije.ReadOnly = true;
            dataGridViewInstitucijeZaRecenzije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInstitucijeZaRecenzije.Size = new System.Drawing.Size(198, 236);
            dataGridViewInstitucijeZaRecenzije.TabIndex = 50;
            // 
            // labelNazivInstitucijeZaRecenzije
            // 
            labelNazivInstitucijeZaRecenzije.AutoSize = true;
            labelNazivInstitucijeZaRecenzije.Location = new System.Drawing.Point(32, 165);
            labelNazivInstitucijeZaRecenzije.Name = "labelNazivInstitucijeZaRecenzije";
            labelNazivInstitucijeZaRecenzije.Size = new System.Drawing.Size(42, 15);
            labelNazivInstitucijeZaRecenzije.TabIndex = 49;
            labelNazivInstitucijeZaRecenzije.Text = "Name:";
            // 
            // textboxNaziv
            // 
            textboxNaziv.Location = new System.Drawing.Point(112, 157);
            textboxNaziv.Name = "textboxNaziv";
            textboxNaziv.Size = new System.Drawing.Size(112, 23);
            textboxNaziv.TabIndex = 48;
            // 
            // buttonPromeni
            // 
            buttonPromeni.Location = new System.Drawing.Point(60, 234);
            buttonPromeni.Name = "buttonPromeni";
            buttonPromeni.Size = new System.Drawing.Size(94, 37);
            buttonPromeni.TabIndex = 47;
            buttonPromeni.Text = "Update";
            buttonPromeni.UseVisualStyleBackColor = true;
            // 
            // UCUpdateReviewInstitution
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textboxOpis);
            Controls.Add(labelOpisInstitucijeZaRecenzije);
            Controls.Add(dataGridViewInstitucijeZaRecenzije);
            Controls.Add(labelNazivInstitucijeZaRecenzije);
            Controls.Add(textboxNaziv);
            Controls.Add(buttonPromeni);
            Name = "UCUpdateReviewInstitution";
            Size = new System.Drawing.Size(491, 306);
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstitucijeZaRecenzije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInstitucijeZaRecenzije;
        private System.Windows.Forms.TextBox textboxOpis;
        private System.Windows.Forms.Label labelOpisInstitucijeZaRecenzije;
        private System.Windows.Forms.Label labelNazivInstitucijeZaRecenzije;
        private System.Windows.Forms.TextBox textboxNaziv;
        private System.Windows.Forms.Button buttonPromeni;

        public DataGridView DataGridViewInstitucijeZaRecenzije { get => dataGridViewInstitucijeZaRecenzije; set => dataGridViewInstitucijeZaRecenzije = value; }
        public TextBox TextboxOpis { get => textboxOpis; set => textboxOpis = value; }
        public Label LabelOpisInstitucijeZaRecenzije { get => labelOpisInstitucijeZaRecenzije; set => labelOpisInstitucijeZaRecenzije = value; }
        public Label LabelNazivInstitucijeZaRecenzije { get => labelNazivInstitucijeZaRecenzije; set => labelNazivInstitucijeZaRecenzije = value; }
        public TextBox TextboxNaziv { get => textboxNaziv; set => textboxNaziv = value; }
        public Button ButtonPromeni { get => buttonPromeni; set => buttonPromeni = value; }
    }
}
