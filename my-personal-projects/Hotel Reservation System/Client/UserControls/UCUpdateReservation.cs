using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCUpdateReservation : UserControl
    {
        public UCUpdateReservation()
        {
            InitializeComponent();
            dataGridViewRezervacije.Click += UpdateReservationController.Instance.FillFormWithSelectedDataGridViewRow;
            buttonPromeniRezervaciju.Click += UpdateReservationController.Instance.UpdateReservation;
            buttonPromeniStavkeRezervacije.Click += UpdateReservationController.Instance.UpdateReservationItem;
        }
    }
}
