using Client.GuiController;
using System;

namespace Client
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            LogInEmployeeController.Instance.ShowFrmLogin();
        }
    }
}
