using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCDeleteHotelReview
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
            buttonObrisi = new Button();
            dataGridViewRecenzijeHotela = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecenzijeHotela).BeginInit();
            SuspendLayout();
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new System.Drawing.Point(163, 301);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new System.Drawing.Size(75, 23);
            buttonObrisi.TabIndex = 30;
            buttonObrisi.Text = "Delete";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRecenzijeHotela
            // 
            dataGridViewRecenzijeHotela.AllowUserToAddRows = false;
            dataGridViewRecenzijeHotela.AllowUserToDeleteRows = false;
            dataGridViewRecenzijeHotela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRecenzijeHotela.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRecenzijeHotela.Location = new System.Drawing.Point(340, 33);
            dataGridViewRecenzijeHotela.MultiSelect = false;
            dataGridViewRecenzijeHotela.Name = "dataGridViewRecenzijeHotela";
            dataGridViewRecenzijeHotela.ReadOnly = true;
            dataGridViewRecenzijeHotela.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRecenzijeHotela.Size = new System.Drawing.Size(206, 291);
            dataGridViewRecenzijeHotela.TabIndex = 19;
            // 
            // UCDeleteHotelReview
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonObrisi);
            Controls.Add(dataGridViewRecenzijeHotela);
            Name = "UCDeleteHotelReview";
            Size = new System.Drawing.Size(569, 357);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRecenzijeHotela).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.DataGridView dataGridViewRecenzijeHotela;

        public Button ButtonObrisi { get => buttonObrisi; set => buttonObrisi = value; }
        public DataGridView DataGridViewRecenzijeHotela { get => dataGridViewRecenzijeHotela; set => dataGridViewRecenzijeHotela = value; }
    }
}
