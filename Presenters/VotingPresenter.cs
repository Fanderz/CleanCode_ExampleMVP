using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CleanCode_ExampleMVP.Services;
using CleanCode_ExampleMVP.Models;

namespace CleanCode_ExampleMVP.Presenters
{
    class VotingPresenter : PresenterFactory
    {
        private const string AccessAllowed = "ПРЕДОСТАВЛЕН";
        private const string AccessDenied = "НЕ ПРЕДОСТАВЛЕН";

        private IView _view;
        private DataTable _queryResult;

        public override PresenterFactory Create(IView view)
        {
            if (view == null)
                throw new ArgumentNullException();

            _view = view;

            return this;
        }

        public override void TryGetAccess(string passport)
        {
            _queryResult = new Passport(passport).GetPassport();

            if (_queryResult.Rows.Count > 0)
                _view.ShowMessage(BuildMessage(passport, Convert.ToBoolean(_queryResult.Rows[0].ItemArray[1])));
            else
                _view.ShowMessage($"Паспорт «{passport}» в списке участников дистанционного голосования НЕ НАЙДЕН.");
        }

        private string BuildMessage(string passport, bool access)
        {
            return string.Format($"По паспорту «{passport}» доступ к бюллетеню на дистанционном электронном голосовании {(access ? AccessAllowed : AccessDenied)}.");
        }
    }
}
