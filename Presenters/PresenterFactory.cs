namespace CleanCode_ExampleMVP.Presenters
{
    public abstract class PresenterFactory
    {
        public abstract PresenterFactory Create(IView view);
        public abstract void TryGetAccess(string passport);
    }
}
