using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCDeleteLocation
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
            dataGridViewMesta = new DataGridView();
            buttonObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMesta
            // 
            dataGridViewMesta.AllowUserToAddRows = false;
            dataGridViewMesta.AllowUserToDeleteRows = false;
            dataGridViewMesta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMesta.Location = new System.Drawing.Point(261, 26);
            dataGridViewMesta.MultiSelect = false;
            dataGridViewMesta.Name = "dataGridViewMesta";
            dataGridViewMesta.ReadOnly = true;
            dataGridViewMesta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMesta.Size = new System.Drawing.Size(198, 236);
            dataGridViewMesta.TabIndex = 44;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new System.Drawing.Point(61, 225);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new System.Drawing.Size(94, 37);
            buttonObrisi.TabIndex = 41;
            buttonObrisi.Text = "Delete";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // UCDeleteLocation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewMesta);
            Controls.Add(buttonObrisi);
            Name = "UCDeleteLocation";
            Size = new System.Drawing.Size(493, 289);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMesta;
        private System.Windows.Forms.Button buttonObrisi;

        public DataGridView DataGridViewMesta { get => dataGridViewMesta; set => dataGridViewMesta = value; }
        public Button ButtonObrisi { get => buttonObrisi; set => buttonObrisi = value; }
    }
}
