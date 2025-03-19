namespace CleanCode_ExampleMVP.Presenters
{
    public class PresenterFactory
    {
        public VotingPresenter Create(IView view)
        {
            return new VotingPresenter(view);
        }
    }
}
