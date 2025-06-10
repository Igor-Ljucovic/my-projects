using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCDeleteGuest
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
            dataGridViewGosti = new DataGridView();
            buttonObrisi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGosti).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewGosti
            // 
            dataGridViewGosti.AllowUserToAddRows = false;
            dataGridViewGosti.AllowUserToDeleteRows = false;
            dataGridViewGosti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewGosti.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGosti.Location = new System.Drawing.Point(241, 47);
            dataGridViewGosti.MultiSelect = false;
            dataGridViewGosti.Name = "dataGridViewGosti";
            dataGridViewGosti.ReadOnly = true;
            dataGridViewGosti.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGosti.Size = new System.Drawing.Size(229, 237);
            dataGridViewGosti.TabIndex = 66;
            // 
            // buttonObrisi
            // 
            buttonObrisi.Location = new System.Drawing.Point(71, 247);
            buttonObrisi.Name = "buttonObrisi";
            buttonObrisi.Size = new System.Drawing.Size(94, 37);
            buttonObrisi.TabIndex = 56;
            buttonObrisi.Text = "Delete";
            buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // UCDeleteGuest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewGosti);
            Controls.Add(buttonObrisi);
            Name = "UCDeleteGuest";
            Size = new System.Drawing.Size(563, 322);
            ((System.ComponentModel.ISupportInitialize)dataGridViewGosti).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGosti;
        private System.Windows.Forms.Button buttonObrisi;

        public DataGridView DataGridViewGosti { get => dataGridViewGosti; set => dataGridViewGosti = value; }
        public Button ButtonObrisi { get => buttonObrisi; set => buttonObrisi = value; }
    }
}
