namespace ConsulTech.Web.Models.ViewModels.Consultant
{
    public class ConsultantListVm
    {
        public Guid Id { get; set; }
        public string Nom { get; set; } = "";
        public string Prenom { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime DateEmbauche { get; set; }
        public bool EstDisponible { get; set; }
        public List<string> Competences { get; set; } = new();
    }
}
