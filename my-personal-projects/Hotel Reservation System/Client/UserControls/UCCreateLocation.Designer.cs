using System.Windows.Forms;

namespace Client.UserControls
{
    partial class UCCreateLocation
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
            buttonKreiraj = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewMesta
            // 
            dataGridViewMesta.AllowUserToAddRows = false;
            dataGridViewMesta.AllowUserToDeleteRows = false;
            dataGridViewMesta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMesta.Location = new System.Drawing.Point(259, 43);
            dataGridViewMesta.MultiSelect = false;
            dataGridViewMesta.Name = "dataGridViewMesta";
            dataGridViewMesta.ReadOnly = true;
            dataGridViewMesta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMesta.Size = new System.Drawing.Size(198, 236);
            dataGridViewMesta.TabIndex = 40;
            // 
            // labelAdresaMesta
            // 
            labelAdresaMesta.AutoSize = true;
            labelAdresaMesta.Location = new System.Drawing.Point(31, 208);
            labelAdresaMesta.Name = "labelAdresaMesta";
            labelAdresaMesta.Size = new System.Drawing.Size(42, 15);
            labelAdresaMesta.TabIndex = 31;
            labelAdresaMesta.Text = "Name:";
            // 
            // textboxAdresa
            // 
            textboxAdresa.Location = new System.Drawing.Point(111, 203);
            textboxAdresa.Name = "textboxAdresa";
            textboxAdresa.Size = new System.Drawing.Size(112, 23);
            textboxAdresa.TabIndex = 30;
            // 
            // buttonKreiraj
            // 
            buttonKreiraj.Location = new System.Drawing.Point(59, 242);
            buttonKreiraj.Name = "buttonKreiraj";
            buttonKreiraj.Size = new System.Drawing.Size(94, 37);
            buttonKreiraj.TabIndex = 29;
            buttonKreiraj.Text = "Create";
            buttonKreiraj.UseVisualStyleBackColor = true;
            // 
            // UCCreateLocation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridViewMesta);
            Controls.Add(labelAdresaMesta);
            Controls.Add(textboxAdresa);
            Controls.Add(buttonKreiraj);
            Name = "UCCreateLocation";
            Size = new System.Drawing.Size(485, 322);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMesta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewMesta;
        private Label labelAdresaMesta;
        private Button buttonKreiraj;
        private TextBox textboxAdresa;

        public TextBox TextboxAdresa { get => textboxAdresa; set => textboxAdresa = value; }
        public DataGridView DataGridViewMesta { get => dataGridViewMesta; set => dataGridViewMesta = value; }
        public Label LabelAdresaMesta { get => labelAdresaMesta; set => labelAdresaMesta = value; }
        public Button ButtonKreiraj { get => buttonKreiraj; set => buttonKreiraj = value; }
    }
}
