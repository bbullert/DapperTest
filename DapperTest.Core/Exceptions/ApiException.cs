namespace DapperTest.Core.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string error) : base(error)
        {
        }
    }
}
