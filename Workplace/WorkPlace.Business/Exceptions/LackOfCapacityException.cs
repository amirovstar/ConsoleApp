namespace WorkPlace.Business.Exceptions
{
    public class LackOfCapacityException:Exception
	{
		public LackOfCapacityException(string message) : base(message) { }
	}
}

