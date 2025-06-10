using Common.Communication;
using Common.Util;
using Domen;
using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class LogInEmployeeController : SingletonBase<LogInEmployeeController>
    {
        private FrmLogInEmployee frmLogin;

        internal void ShowFrmLogin()
        {
            try
            {
                Communication.Instance.Connect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin = new FrmLogInEmployee();
                frmLogin.AutoSize = true;
                Application.Run(frmLogin);
            }
            catch (SocketException)
            {
                MessageBox.Show("Server communication error!");
            }
        }

        public void Login(object sender, EventArgs e)
        {
            Employee Employee = new Employee { Username = frmLogin.TxtUsername.Text,  Password = frmLogin.TxtPassword.Text, };

            Response response = Communication.Instance.LogInEmployee(Employee);

            if (response.Exception == null)
            {
                frmLogin.Visible = false;
                MainCoordinator.Instance.SetEmployeeUsername(Employee.Username);
                MainCoordinator.Instance.ShowFrmMain();
            }
            else
                MessageBox.Show(response.Exception.ToString());
        }
    }
}