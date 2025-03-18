using System;
using System.Windows.Forms;

namespace CleanCode_ExampleMVP
{
    public partial class MainView : Form, IView
    {
        public event Action<string> TryingAccess;

        public MainView()
        {
            InitializeComponent();
        }

        public void ShowView()
        {
            Show();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            TryingAccess?.Invoke(passportTextbox.Text.Trim().Replace(" ", string.Empty));
        }
    }
}
