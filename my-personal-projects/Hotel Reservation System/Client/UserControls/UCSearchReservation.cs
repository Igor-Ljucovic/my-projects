using Client.GuiController;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCSearchReservation : UserControl
    {
        public UCSearchReservation()
        {
            InitializeComponent();
            ButtonPretrazi.Click += SearchReservationController.Instance.SearchReservation;
            buttonPretraziStavkeRezervacije.Click += SearchReservationController.Instance.PretraziReservationItem;
        }
    }
}
