using Client.GuiController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCCreateReviewInstitution : UserControl
    {
        public UCCreateReviewInstitution()
        {
            InitializeComponent();
            ButtonUbaci.Click += CreateReviewInstitutionController.Instance.CreateReviewInstitution;
        }

        private void InitializeComponent()
        {
            dataGridViewInstitucijeZaRecenzije = new DataGridView();
            labelNazivInstitucijeZaRecenzije = new Label();
            textBoxNaziv = new TextBox();
            buttonUbaci = new Button();
            labelOpisInstitucijeZaRecenzije = new Label();
            textBoxOpis = new TextBox();
            ((ISupportInitialize)dataGridViewInstitucijeZaRecenzije).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewInstitucijeZaRecenzije
            // 
            dataGridViewInstitucijeZaRecenzije.AllowUserToAddRows = false;
            dataGridViewInstitucijeZaRecenzije.AllowUserToDeleteRows = false;
            dataGridViewInstitucijeZaRecenzije.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewInstitucijeZaRecenzije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInstitucijeZaRecenzije.Location = new Point(257, 66);
            dataGridViewInstitucijeZaRecenzije.MultiSelect = false;
            dataGridViewInstitucijeZaRecenzije.Name = "dataGridViewInstitucijeZaRecenzije";
            dataGridViewInstitucijeZaRecenzije.ReadOnly = true;
            dataGridViewInstitucijeZaRecenzije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewInstitucijeZaRecenzije.Size = new Size(198, 236);
            dataGridViewInstitucijeZaRecenzije.TabIndex = 44;
            // 
            // labelNazivInstitucijeZaRecenzije
            // 
            labelNazivInstitucijeZaRecenzije.AutoSize = true;
            labelNazivInstitucijeZaRecenzije.Location = new Point(57, 196);
            labelNazivInstitucijeZaRecenzije.Name = "labelNazivInstitucijeZaRecenzije";
            labelNazivInstitucijeZaRecenzije.Size = new Size(42, 15);
            labelNazivInstitucijeZaRecenzije.TabIndex = 43;
            labelNazivInstitucijeZaRecenzije.Text = "Name:";
            // 
            // textBoxNaziv
            // 
            textBoxNaziv.Location = new Point(109, 188);
            textBoxNaziv.Name = "textBoxNaziv";
            textBoxNaziv.Size = new Size(112, 23);
            textBoxNaziv.TabIndex = 42;
            // 
            // buttonUbaci
            // 
            buttonUbaci.Location = new Point(57, 265);
            buttonUbaci.Name = "buttonUbaci";
            buttonUbaci.Size = new Size(94, 37);
            buttonUbaci.TabIndex = 41;
            buttonUbaci.Text = "Create";
            buttonUbaci.UseVisualStyleBackColor = true;
            // 
            // labelOpisInstitucijeZaRecenzije
            // 
            labelOpisInstitucijeZaRecenzije.AutoSize = true;
            labelOpisInstitucijeZaRecenzije.Location = new Point(29, 232);
            labelOpisInstitucijeZaRecenzije.Name = "labelOpisInstitucijeZaRecenzije";
            labelOpisInstitucijeZaRecenzije.Size = new Size(70, 15);
            labelOpisInstitucijeZaRecenzije.TabIndex = 45;
            labelOpisInstitucijeZaRecenzije.Text = "Description:";
            // 
            // textBoxOpis
            // 
            textBoxOpis.Location = new Point(109, 224);
            textBoxOpis.Name = "textBoxOpis";
            textBoxOpis.Size = new Size(112, 23);
            textBoxOpis.TabIndex = 46;
            // 
            // UCCreateReviewInstitution
            // 
            Controls.Add(textBoxOpis);
            Controls.Add(labelOpisInstitucijeZaRecenzije);
            Controls.Add(dataGridViewInstitucijeZaRecenzije);
            Controls.Add(labelNazivInstitucijeZaRecenzije);
            Controls.Add(textBoxNaziv);
            Controls.Add(buttonUbaci);
            Name = "UCCreateReviewInstitution";
            Size = new Size(484, 368);
            ((ISupportInitialize)dataGridViewInstitucijeZaRecenzije).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
