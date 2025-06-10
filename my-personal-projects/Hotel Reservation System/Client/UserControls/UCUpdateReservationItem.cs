using Client.GuiController;
using System.Windows.Forms;

namespace Client.UserControls
{
    public partial class UCUpdateReservationItem : UserControl
    {
        public UCUpdateReservationItem()
        {
            InitializeComponent();
            buttonPromeni.Click += UpdateReservationItemController.Instance.UpdateReservationItem;
            DataGridViewStavkeRezervacije.CellValueChanged += UpdateReservationItemController.Instance.FillFormWithSelectedDataGridViewRow;
            DataGridViewStavkeRezervacije.Click += UpdateReservationItemController.Instance.FillFormWithSelectedDataGridViewRow;
            DateTimePickerPocetak.ValueChanged += UpdateReservationItemController.Instance.ShowReservationItemPrice;
            DateTimePickerKraj.ValueChanged += UpdateReservationItemController.Instance.ShowReservationItemPrice;
            comboBoxSobe.TextChanged += UpdateReservationItemController.Instance.ShowReservationItemPrice;
        }
    }
}
