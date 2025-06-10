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
    public partial class UCUpdateReviewInstitution : UserControl
    {
        public UCUpdateReviewInstitution()
        {
            InitializeComponent();
            buttonPromeni.Click += UpdateReviewInstitutionController.Instance.UpdateReviewInstitution;
            dataGridViewInstitucijeZaRecenzije.Click += UpdateReviewInstitutionController.Instance.FillFormWithSelectedDataGridViewRow;
        }
    }
}
