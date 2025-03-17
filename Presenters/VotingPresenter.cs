using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CleanCode_ExampleMVP.Models;

namespace CleanCode_ExampleMVP.Presenters
{
    class VotingPresenter
    {
        private const string AccessAllowed = "ПРЕДОСТАВЛЕН";
        private const string AccessDenied = "НЕ ПРЕДОСТАВЛЕН";

        private readonly SqlQueryExecutor _sqlExecutor;

        private IView _view;
        private VotingModel _model;
        private DataTable _queryResult;

        public VotingPresenter(IView view, VotingModel model)
        {
            if (view == null)
                throw new ArgumentNullException();

            if (model == null)
                throw new ArgumentNullException();

            _model = model;
            _view = view;
            _sqlExecutor = new SqlQueryExecutor();
        }

        public void Run()
        {
            _view.ShowView();
            _view.TryingAccess += TryGetAccess;
            Application.Run();
        }

        private void TryGetAccess(string passport)
        {
            if (string.IsNullOrEmpty(passport))
                throw new ArgumentNullException();

            _model.SetPassport(passport);

            _queryResult = _sqlExecutor.ExecuteQuery($"select * from passports where num = '{Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passport)))}' limit 1;");

            if (_queryResult.Rows.Count > 0)
            {
                _model.SetAccess(Convert.ToBoolean(_queryResult.Rows[0].ItemArray[1]));
            }
            else
            {
                _view.ShowMessage($"Паспорт «{_model.Passport}» в списке участников дистанционного голосования НЕ НАЙДЕН.");
                return;
            }

            _view.ShowMessage(BuildMessage());
        }

        private string BuildMessage()
        {
            return string.Format($"По паспорту «{_model.Passport}» доступ к бюллетеню на дистанционном электронном голосовании {(_model.HaveAccess ? AccessAllowed : AccessDenied)}.");
        }
    }
}
