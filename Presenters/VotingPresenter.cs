using System;
using CleanCode_ExampleMVP.Models;
using CleanCode_ExampleMVP.Services;

namespace CleanCode_ExampleMVP.Presenters
{
    public class VotingPresenter
    {
        private const string AccessAllowed = "ПРЕДОСТАВЛЕН";
        private const string AccessDenied = "НЕ ПРЕДОСТАВЛЕН";

        private Citizen _citizen;
        private IView _view;

        public VotingPresenter(IView view)
        {
            _view = view;
        }

        public void TryGetAccess(string inputNumber)
        {
            try
            {
                _citizen = new Service().GetCitizen(inputNumber);

                if (_citizen == null)
                    throw new NullReferenceException();

                if (_citizen.IsAccess.HasValue == false)
                {
                    _view.ShowMessage($"Паспорт «{inputNumber}» в списке участников дистанционного голосования НЕ НАЙДЕН.");
                    return;
                }

                _view.ShowMessage(BuildMessage(inputNumber, _citizen.IsAccess.Value));
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
