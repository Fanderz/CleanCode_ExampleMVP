using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace CleanCode_ExampleMVP.Presenters
{
    class VotingPresenter
    {
        private const string AccessAllowed = "ПРЕДОСТАВЛЕН";
        private const string AccessDenied = "НЕ ПРЕДОСТАВЛЕН";

        private readonly SqlQueryExecutor _sqlExecutor;

        private IView _view;
        private DataTable _queryResult;

        public VotingPresenter(IView view)
        {
            if (view == null)
                throw new ArgumentNullException();

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

            if (string.IsNullOrEmpty(passport))
                _view.ShowMessage("Введите серию и номер паспорта!");

            if (passport.Length < 10)
                _view.ShowMessage("Неверный формат серии или номера паспорта.");

            try
            {
                _queryResult = _sqlExecutor.ExecuteQuery($"select * from passports where num = '{Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passport)))}' limit 1;");
            }
            catch(Exception ex)
            {
                _view.ShowMessage(ex.Message.ToString());
            }


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
