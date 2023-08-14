using RestSharp;

namespace Dev.Exec.RequestAPI
{
    public static class Product
    {
        public static void Exec()
        {
            var client = new RestClient($"{DevConsts.Url}/api/Email/sendemailerror");
            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            request.AddHeader("SR-Midia-Key", DevConsts.ApiKey);

            _ = Task.Run(() =>
                   client.ExecutePostAsync(request).Wait()
            );
        }
    }
}
