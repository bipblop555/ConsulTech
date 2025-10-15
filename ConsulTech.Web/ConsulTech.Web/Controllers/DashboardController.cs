using ConsulTech.Web.Models.ViewModels.Dashboard;
using ConsulTech.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ClientsClient _client;
        private readonly MissionsClient _mission;
        private readonly ConsultantsClient _consultants;

        public DashboardController(ClientsClient client, MissionsClient mission, ConsultantsClient consultants)
        {
            _client = client;
            _mission = mission;
            _consultants = consultants;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _client.GetAll();
            var missions = await _mission.GetAll();
            var consultants = await _consultants.GetAll();

            var now = DateTime.Today;

            var missionsEnCours = missions.Count(m => m.Debut.Date <= now && m.Fin.Date >= now);
            var missionsAVenir = missions.Count(m => m.Debut.Date > now);
            var budgetTotalEnCours = missions
                .Where(m => m.Debut.Date <= now && m.Fin.Date >= now)
                .Sum(m => m.Budget);

            var vm = new DashboardVm
            {
                TotalClients = clients.Count,
                TotalMissions = missions.Count,
                MissionsEnCours = missionsEnCours,
                BudgetTotalEnCours = budgetTotalEnCours,
                ConsultantsTotal = consultants.Count,
                ConsultantsDisponibles = consultants.Count(c => c.EstDisponible)
            };

            var upcoming = missions
                .Where(m => m.Debut.Date >= now)
                .OrderBy(m => m.Debut.Date)
                .Take(5)
                .Select(m => new UpcomingMissionItem
                {
                    Id = m.Id,
                    Titre = m.Titre,
                    ClientNom = m.ClientNom,
                    Debut = m.Debut
                }).ToList();

            var dispo = consultants
                .Where(c => c.EstDisponible)
                .OrderBy(c => c.Nom).ThenBy(c => c.Prenom)
                .Take(5)
                .Select(c => new ConsultantDispoItem
                {
                    Id = c.Id, NomComplet = $"{c.Prenom} {c.Nom}", Email = c.Email
                }).ToList();

            vm.UpcomingMissions = upcoming;
            vm.ConsultantsDispos = dispo;

            return View(vm);
        }
    }
}
