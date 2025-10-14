namespace ConsulTech.Web.Models.ViewModels
{
    public class ClientListVm
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Secteur { get; set; } = "";
        public string Adresse { get; set; } = "";
        public string Contact { get; set; } = "";
    }
}
