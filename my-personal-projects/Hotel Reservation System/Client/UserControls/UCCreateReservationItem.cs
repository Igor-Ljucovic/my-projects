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
    public partial class UCCreateReservationItem : UserControl
    {
        public UCCreateReservationItem()
        {
            InitializeComponent();
            buttonDodaj.Click += CreateReservationItemController.Instance.UCCreateReservationItem;
            ComboBoxSobe.SelectedIndexChanged += CreateReservationItemController.Instance.ShowItemPrice;
            DateTimePickerPocetak.ValueChanged += CreateReservationItemController.Instance.ShowItemPrice;
            DateTimePickerKraj.ValueChanged += CreateReservationItemController.Instance.ShowItemPrice;
        }
    }
}
