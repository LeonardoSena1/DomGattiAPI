using System.Data;
using System.Data.SqlClient;

namespace Dev.SqlServer.Client
{
    public class SqlRepository : ISqlRepository
    {
        /// <summary>
        /// Run load
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="CmdText"></param>
        /// <param name="StoredProcedure"></param>
        /// <param name="Parameters"></param>
        public int RunLoad(string ConnectionString
            , string CmdText
            , bool StoredProcedure = true
            , Dictionary<string, object> Parameters = null
            , bool IdOutput = false)
        {
            var Id = 0;

            using (var sqlCnn = new SqlConnection(ConnectionString))
            {
                sqlCnn.Open();

                using (var sqlCmd = new SqlCommand(CmdText, sqlCnn))
                {
                    if (StoredProcedure)
                        _ = sqlCmd.CommandType = CommandType.StoredProcedure;

                    if (Parameters != null)
                        foreach (var valuePair in Parameters)
                            _ = sqlCmd.Parameters.AddWithValue(valuePair.Key, valuePair.Value);

                    if (IdOutput)
                        _ = sqlCmd.Parameters.Add("@CustomerId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    _ = sqlCmd.CommandTimeout = 0;
                    _ = sqlCmd.ExecuteNonQuery();

                    if (IdOutput)
                        Id = (int)sqlCmd.Parameters["@CustomerId"].Value;
                }
            }

            return Id;
        }

    }
}