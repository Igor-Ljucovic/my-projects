using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCUpdateLocation
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
            labelAdresaMesta = new Label();
            textboxAdresa = new TextBox();
            buttonPromeni = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMesta
            // 
            dataGridViewMesta.AllowUserToAddRows = false;
            dataGridViewMesta.AllowUserToDeleteRows = false;
            dataGridViewMesta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMesta.Location = new System.Drawing.Point(272, 39);
            dataGridViewMesta.MultiSelect = false;
            dataGridViewMesta.Name = "dataGridViewMesta";
            dataGridViewMesta.ReadOnly = true;
            dataGridViewMesta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMesta.Size = new System.Drawing.Size(198, 236);
            dataGridViewMesta.TabIndex = 44;
            // 
            // labelAdresaMesta
            // 
            labelAdresaMesta.AutoSize = true;
            labelAdresaMesta.Location = new System.Drawing.Point(44, 204);
            labelAdresaMesta.Name = "labelAdresaMesta";
            labelAdresaMesta.Size = new System.Drawing.Size(42, 15);
            labelAdresaMesta.TabIndex = 43;
            labelAdresaMesta.Text = "Name:";
            // 
            // textboxAdresa
            // 
            textboxAdresa.Location = new System.Drawing.Point(124, 199);
            textboxAdresa.Name = "textboxAdresa";
            textboxAdresa.Size = new System.Drawing.Size(112, 23);
            textboxAdresa.TabIndex = 42;
            // 
            // buttonPromeni
            // 
            buttonPromeni.Location = new System.Drawing.Point(72, 238);
            buttonPromeni.Name = "buttonPromeni";
            buttonPromeni.Size = new System.Drawing.Size(94, 37);
            buttonPromeni.TabIndex = 41;
            buttonPromeni.Text = "Update";
            buttonPromeni.UseVisualStyleBackColor = true;
            // 
            // UCUpdateLocation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewMesta);
            Controls.Add(labelAdresaMesta);
            Controls.Add(textboxAdresa);
            Controls.Add(buttonPromeni);
            Name = "UCUpdateLocation";
            Size = new System.Drawing.Size(515, 315);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMesta;
        private System.Windows.Forms.Label labelAdresaMesta;
        private System.Windows.Forms.TextBox textboxAdresa;
        private System.Windows.Forms.Button buttonPromeni;

        public DataGridView DataGridViewMesta { get => dataGridViewMesta; set => dataGridViewMesta = value; }
        public Label LabelAdresaMesta { get => labelAdresaMesta; set => labelAdresaMesta = value; }
        public TextBox TextboxAdresa { get => textboxAdresa; set => textboxAdresa = value; }
        public Button ButtonPromeni { get => buttonPromeni; set => buttonPromeni = value; }
    }
}
