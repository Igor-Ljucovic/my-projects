using Domen;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class FrmReservationItem : Form
    {
        public List<ReservationItem> ReservationItems { get; set; }
        public Reservation Reservation { get; set; }

        public FrmReservationItem()
        {
            InitializeComponent();
            ReservationItems = new List<ReservationItem>();
        }

        public void ChangePanel(Control control)
        {
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlMain.AutoSize = true;
            pnlMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
    }
}
