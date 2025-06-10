using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCSearchLocation
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
            buttonPretrazi = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMesta
            // 
            dataGridViewMesta.AllowUserToAddRows = false;
            dataGridViewMesta.AllowUserToDeleteRows = false;
            dataGridViewMesta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMesta.Location = new System.Drawing.Point(259, 24);
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
            labelAdresaMesta.Location = new System.Drawing.Point(31, 189);
            labelAdresaMesta.Name = "labelAdresaMesta";
            labelAdresaMesta.Size = new System.Drawing.Size(42, 15);
            labelAdresaMesta.TabIndex = 43;
            labelAdresaMesta.Text = "Name:";
            // 
            // textboxAdresa
            // 
            textboxAdresa.Location = new System.Drawing.Point(111, 184);
            textboxAdresa.Name = "textboxAdresa";
            textboxAdresa.Size = new System.Drawing.Size(112, 23);
            textboxAdresa.TabIndex = 42;
            // 
            // buttonPretrazi
            // 
            buttonPretrazi.Location = new System.Drawing.Point(59, 223);
            buttonPretrazi.Name = "buttonPretrazi";
            buttonPretrazi.Size = new System.Drawing.Size(94, 37);
            buttonPretrazi.TabIndex = 41;
            buttonPretrazi.Text = "Search";
            buttonPretrazi.UseVisualStyleBackColor = true;
            // 
            // UCSearchLocation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewMesta);
            Controls.Add(labelAdresaMesta);
            Controls.Add(textboxAdresa);
            Controls.Add(buttonPretrazi);
            Name = "UCSearchLocation";
            Size = new System.Drawing.Size(489, 284);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMesta;
        private System.Windows.Forms.TextBox textboxAdresa;
        private Label labelAdresaMesta;
        private Button buttonPretrazi;

        public DataGridView DataGridViewMesta { get => dataGridViewMesta; set => dataGridViewMesta = value; }
        public Label LabelAdresaMesta { get => labelAdresaMesta; set => labelAdresaMesta = value; }
        public TextBox TextboxAdresa { get => textboxAdresa; set => textboxAdresa = value; }
        public Button ButtonPretrazi { get => buttonPretrazi; set => buttonPretrazi = value; }
    }
}
