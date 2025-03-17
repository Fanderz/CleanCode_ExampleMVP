using System;

namespace CleanCode_ExampleMVP
{
    interface IView
    {
        event Action<string> TryingAccess;

        void ShowView();
        void ShowMessage(string message);
    }
}
