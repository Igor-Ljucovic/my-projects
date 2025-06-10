using Common.Communication;
using System.Windows.Forms;

namespace Client.Util
{
    static internal class FormMessageBoxHandler
    {
        static internal void ShowSystemOperationResultMessage(Response response, string systemOperationSuccessfulMessage)
        { 
            if (response.Exception == null)
                MessageBox.Show(systemOperationSuccessfulMessage);
            else
                MessageBox.Show(response.Exception);
        }
    }
}
