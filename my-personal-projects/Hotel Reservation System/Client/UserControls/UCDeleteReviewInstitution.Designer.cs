using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCDeleteReviewInstitution
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
            dataGridViewInstitucijeZaRecenzije = new DataGridView();
            buttonObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstitucijeZaRecenzije).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewInstitucijeZaRecenzije
            // 
            dataGridViewInstitucijeZaRecenzije.AllowUserToAddRows = false;
            dataGridViewInstitucijeZaRecenzije.AllowUserToDeleteRows = false;
            dataGridViewInstitucijeZaRecenzije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInstitucijeZaRecenzije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInstitucijeZaRecenzije.Location = new System.Drawing.Point(256, 58);
            dataGridViewInstitucijeZaRecenzije.MultiSelect = false;
            dataGridViewInstitucijeZaRecenzije.Name = "dataGridViewInstitucijeZaRecenzije";
            dataGridViewInstitucijeZaRecenzije.ReadOnly = true;
            dataGridViewInstitucijeZaRecenzije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInstitucijeZaRecenzije.Size = new System.Drawing.Size(198, 236);
            dataGridViewInstitucijeZaRecenzije.TabIndex = 50;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new System.Drawing.Point(56, 257);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new System.Drawing.Size(94, 37);
            buttonObrisi.TabIndex = 47;
            buttonObrisi.Text = "Delete";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // UCDeleteReviewInstitution
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewInstitucijeZaRecenzije);
            Controls.Add(buttonObrisi);
            Name = "UCDeleteReviewInstitution";
            Size = new System.Drawing.Size(483, 353);
            ((System.ComponentModel.ISupportInitialize)dataGridViewInstitucijeZaRecenzije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInstitucijeZaRecenzije;
        private System.Windows.Forms.Button buttonObrisi;

        public DataGridView DataGridViewInstitucijeZaRecenzije { get => dataGridViewInstitucijeZaRecenzije; set => dataGridViewInstitucijeZaRecenzije = value; }
        public Button ButtonObrisi { get => buttonObrisi; set => buttonObrisi = value; }
    }
}
