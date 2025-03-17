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
            if (string.IsNullOrEmpty(passportTextbox.Text.Trim()))
            {
                ShowMessage("Введите серию и номер паспорта!");
                return;
            }

            if (passportTextbox.Text.Trim().Length < 10)
            {
                ShowMessage("Неверный формат серии или номера паспорта.");
                return;
            }

            TryingAccess?.Invoke(passportTextbox.Text.Trim());
        }
    }
}
