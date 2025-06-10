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
    public partial class UCUpdateRoom : UserControl
    {
        public UCUpdateRoom()
        {
            InitializeComponent();
            buttonPromeni.Click += UpdateRoomController.Instance.UpdateRoom;
            DataGridViewSobe.Click += UpdateRoomController.Instance.FillFormWithSelectedDataGridViewRow;
        }
    }
}
