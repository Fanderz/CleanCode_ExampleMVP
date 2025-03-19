using System;
using System.Windows.Forms;
using CleanCode_ExampleMVP.Presenters;

namespace CleanCode_ExampleMVP
{
    public partial class MainView : Form, IView
    {
        private VotingPresenter _presenter;

        public MainView(PresenterFactory factory)
        {
            _presenter = factory.Create(this);

            InitializeComponent();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            _presenter.TryGetAccess(passportTextbox.Text);
        }
    }
}
