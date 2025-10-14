namespace ConsulTech.Web.Services
{
    public class ConsultantsClient
    {
        private readonly HttpClient _http;
        public ConsultantsClient(HttpClient http) => _http = http;
    }
}
