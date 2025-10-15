namespace ConsulTech.Web.Models.ViewModels.Dashboard
{
    public class DashboardVm
    {
        public int TotalClients { get; set; }
        public int TotalMissions { get; set; }
        public int MissionsEnCours { get; set; }
        public int MissionsAVenir {  get; set; }
        public int ConsultantsTotal { get; set; }
        public int ConsultantsDisponibles { get; set; }
        public float BudgetTotalEnCours { get; set; }

        public List<UpcomingMissionItem> UpcomingMissions { get; set; } = new();
        public List<ConsultantDispoItem> ConsultantsDispos { get; set; } = new();
    }

    public class UpcomingMissionItem
    {
        public Guid Id { get; set; }
        public string Titre { get; set; } = "";
        public string ClientNom { get; set; } = "";
        public DateTime Debut {  get; set; }
    }

    public class ConsultantDispoItem
    {
        public Guid Id { get; set; }
        public string NomComplet { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
