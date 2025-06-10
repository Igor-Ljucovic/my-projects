using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCDeleteHotel
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
            dataGridViewHoteli = new DataGridView();
            buttonObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewHoteli
            // 
            dataGridViewHoteli.AllowUserToAddRows = false;
            dataGridViewHoteli.AllowUserToDeleteRows = false;
            dataGridViewHoteli.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHoteli.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoteli.Location = new System.Drawing.Point(225, 11);
            dataGridViewHoteli.MultiSelect = false;
            dataGridViewHoteli.Name = "dataGridViewHoteli";
            dataGridViewHoteli.ReadOnly = true;
            dataGridViewHoteli.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHoteli.Size = new System.Drawing.Size(223, 249);
            dataGridViewHoteli.TabIndex = 35;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new System.Drawing.Point(57, 223);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new System.Drawing.Size(94, 37);
            buttonObrisi.TabIndex = 32;
            buttonObrisi.Text = "Delete";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // UCDeleteHotel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewHoteli);
            Controls.Add(buttonObrisi);
            Name = "UCDeleteHotel";
            Size = new System.Drawing.Size(455, 270);
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoteli).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.DataGridView dataGridViewHoteli;

        public Button ButtonObrisi { get => buttonObrisi; set => buttonObrisi = value; }
        public DataGridView DataGridViewHoteli { get => dataGridViewHoteli; set => dataGridViewHoteli = value; }
    }
}
