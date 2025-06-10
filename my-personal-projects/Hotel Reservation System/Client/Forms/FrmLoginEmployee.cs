using Client.GuiController;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmLogInEmployee : Form
    {
        public FrmLogInEmployee()
        {
            InitializeComponent();
            buttonLogin.Click += LogInEmployeeController.Instance.Login;
        }

        private void buttonLogin_Click(object sender, System.EventArgs e)
        {

        }
    }
}
