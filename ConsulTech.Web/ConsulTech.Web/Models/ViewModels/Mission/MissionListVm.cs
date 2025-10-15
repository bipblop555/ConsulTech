namespace ConsulTech.Web.Models.ViewModels.Mission
{
    public class MissionListVm
    {
        public Guid Id { get; set; }
        public string Titre { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Debut { get; set; }
        public DateTime Fin { get; set; }
        public float Budget { get; set; }
        public string ClientNom { get; set; } = "";
    }
}
