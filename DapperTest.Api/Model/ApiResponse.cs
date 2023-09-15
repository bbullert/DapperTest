namespace DapperTest.Api.Model
{
    internal class ApiResponse<T>
    {
        public T Result { get; set; }
        public int Status { get; set; }
        public string Details { get; set; }
    }
}
