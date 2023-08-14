namespace Dev.Application.Shared
{
    public class BaseRequest
    {
        public string ConnectionString { get; set; }
        public string CmdText { get; set; }
        public bool StoredProcedure { get; set; }
    }
}
