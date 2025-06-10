using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCDeleteRoom
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
            dataGridViewSobe = new DataGridView();
            buttonObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSobe).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewSobe
            // 
            dataGridViewSobe.AllowUserToAddRows = false;
            dataGridViewSobe.AllowUserToDeleteRows = false;
            dataGridViewSobe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSobe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSobe.Location = new System.Drawing.Point(258, 18);
            dataGridViewSobe.MultiSelect = false;
            dataGridViewSobe.Name = "dataGridViewSobe";
            dataGridViewSobe.ReadOnly = true;
            dataGridViewSobe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSobe.Size = new System.Drawing.Size(286, 239);
            dataGridViewSobe.TabIndex = 52;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new System.Drawing.Point(43, 217);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new System.Drawing.Size(94, 37);
            buttonObrisi.TabIndex = 45;
            buttonObrisi.Text = "Delete";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // UCDeleteRoom
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewSobe);
            Controls.Add(buttonObrisi);
            Name = "UCDeleteRoom";
            Size = new System.Drawing.Size(560, 313);
            ((System.ComponentModel.ISupportInitialize)dataGridViewSobe).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSobe;
        private System.Windows.Forms.Button buttonObrisi;

        public DataGridView DataGridViewSobe { get => dataGridViewSobe; set => dataGridViewSobe = value; }
        public Button ButtonObrisi { get => buttonObrisi; set => buttonObrisi = value; }
    }
}
