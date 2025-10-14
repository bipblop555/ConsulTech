namespace ConsulTech.Web.Services
{
    public class MissionsClient
    {
        private readonly HttpClient _http;
        public MissionsClient(HttpClient http) => _http = http;
    }
}
