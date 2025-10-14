namespace ConsulTech.Web.Services
{
    public class CompetencesClient
    {
        private readonly HttpClient _http;
        public CompetencesClient(HttpClient http) => _http = http;
    }
}
