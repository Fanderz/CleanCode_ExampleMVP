using System;
using CleanCode_ExampleMVP.Models;
using CleanCode_ExampleMVP.Services;

namespace CleanCode_ExampleMVP.Presenters
{
    public class VotingPresenter
    {
        private const string AccessAllowed = "ПРЕДОСТАВЛЕН";
        private const string AccessDenied = "НЕ ПРЕДОСТАВЛЕН";

        private IView _view;

        public VotingPresenter(IView view)
        {
            _view = view;
        }

        public void TryGetAccess(string passport)
        {
            try
            {
                string query = $"select * from passports where num = '{new Service().GetPassports(new Passport(passport))}' limit 1;";
                bool? hasAccess = new Repository(DatabaseContext.ExecuteQuery(query)).Citizen.IsAccess;

                if (hasAccess.HasValue == false)
                {
                    _view.ShowMessage($"Паспорт «{passport}» в списке участников дистанционного голосования НЕ НАЙДЕН.");
                    return;
                }

                _view.ShowMessage(BuildMessage(passport, hasAccess.Value));
            }
            catch(Exception ex)
            {
                _view.ShowMessage(ex.Message);
            }
        }

        private string BuildMessage(string passport, bool access)
        {
            return string.Format($"По паспорту «{passport}» доступ к бюллетеню на дистанционном электронном голосовании {(access ? AccessAllowed : AccessDenied)}.");
        }
    }
}
