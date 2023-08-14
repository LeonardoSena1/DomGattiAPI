namespace Dev.Application.Shared
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Data = new List<object>();
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Runtime { get; set; }
        public List<object> Data { get; set; }
    }
}
