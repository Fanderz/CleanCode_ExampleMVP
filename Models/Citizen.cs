namespace CleanCode_ExampleMVP.Models
{
    public class Citizen
    {
        public Citizen(bool? isAccess)
        {
            IsAccess = isAccess;
        }

        public bool? IsAccess { get; private set; }
    }
}
