namespace Dev.SqlServer
{
    public interface ISqlRepository
    {
        int RunLoad(string ConnectionString
            , string CmdText
            , bool StoredProcedure = true
            , Dictionary<string, object> Parameters = null
            , bool IdOutput = false);
    }
}
