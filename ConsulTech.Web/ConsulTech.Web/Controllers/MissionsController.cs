using ConsulTech.Web.Models.ViewModels.Mission;
using ConsulTech.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Web.Controllers
{
    public class MissionsController : Controller
    {
        private readonly MissionsClient _missions;
        private readonly ClientsClient _clients;
        private readonly ConsultantsClient _consultants;

        public MissionsController(MissionsClient missions, ClientsClient clients, ConsultantsClient consultants)
        {
            _missions = missions;
            _clients = clients;
            _consultants = consultants;
        }

        // GET /Mission
        public async Task<IActionResult> Index()
        {
            var dtos = await _missions.GetAll();
            var vm = dtos.Select(m => new MissionListVm
            {
                Id = m.Id, Titre = m.Titre, Description = m.Description,
                Debut = m.Debut, Fin = m.Fin, Budget = m.Budget,
                ClientNom = m.ClientNom,
                Consultants = m.Consultants,
                ConsultantsCount = m.ConsultantIds?.Count
            }).ToList();

            return View(vm);
        }

        // GET /Mission/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clients = await _clients.GetAll(); // déjà existant côté Web
            var consultants = await _consultants.GetAll();
            var vm = new MissionEditVm
            {
                ClientOptions = clients
                    .Select(c => (c.Id.ToString(), $"{c.Nom} ({c.Secteur})"))
                    .ToList(),
                ConsultantOptions = consultants
                    .Select(c => (c.Id.ToString(), $"{c.Prenom} {c.Nom}"))
                    .ToList()
            };
            return View(vm);
        }

        // POST /Mission/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MissionEditVm vm)
        {
            if (!ModelState.IsValid)
            {
                var clients = await _clients.GetAll();
                var consultants = await _consultants.GetAll();
                vm.ClientOptions = clients
                    .Select(c => (c.Id.ToString(), $"{c.Nom} ({c.Secteur})"))
                    .ToList();
                vm.ConsultantOptions = consultants
                    .Select(c => (c.Id.ToString(), $"{c.Prenom} {c.Nom}"))
                    .ToList();
                return View(vm);
            }
            await _missions.Create(new MissionsClient.CreateMissionDto(
                vm.Titre, vm.Description, vm.Debut, vm.Fin, vm.Budget, vm.ClientId, vm.ConsultantIds));

            return RedirectToAction(nameof(Index));
        }

        // GET /Mission/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var m = await _missions.Get(id);
            if (m is null) return NotFound();

            var clients = await _clients.GetAll();
            var consultants = await _consultants.GetAll();
            var vm = new MissionEditVm
            {
                Titre = m.Titre,
                Description = m.Description,
                Debut = m.Debut,
                Fin = m.Fin,
                Budget = m.Budget,
                ClientId = m.ClientId,
                ClientOptions = clients.Select(c => (c.Id.ToString(), $"{c.Nom} ({c.Secteur})")).ToList(),
                ConsultantOptions = consultants
                    .Select(c => (c.Id.ToString(), $"{c.Prenom} {c.Nom}"))
                    .ToList(),
                ConsultantIds = m.ConsultantIds ?? new()
            };
            ViewBag.MissionId = m.Id;
            return View(vm);
        }

        // POST /Mission/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, MissionEditVm vm)
        {
            if (!ModelState.IsValid)
            {
                var clients = await _clients.GetAll();
                var consultants = await _consultants.GetAll();
                vm.ClientOptions = clients.Select(c => (c.Id.ToString(), $"{c.Nom} ({c.Secteur})")).ToList();
                vm.ConsultantOptions = consultants
                    .Select(c => (c.Id.ToString(), $"{c.Prenom} {c.Nom}"))
                    .ToList();
                return View(vm);
            }

            var ok = await _missions.Update(new MissionsClient.UpdateMissionDto(
                id, vm.Titre, vm.Description, vm.Debut, vm.Fin, vm.Budget, vm.ClientId, vm.ConsultantIds));

            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "Mise à jour impossbile (API ?)");
                var clients = await _clients.GetAll();
                var consultants = await _consultants.GetAll();
                vm.ClientOptions = clients.Select(c => (c.Id.ToString(), $"{c.Nom} ({c.Secteur})")).ToList();
                vm.ConsultantOptions = consultants
                    .Select(c => (c.Id.ToString(), $"{c.Prenom} {c.Nom}"))
                    .ToList();
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST /Mission/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _missions.Delete(id);
            if (!ok) TempData["Error"] = "Suppression impossible (API indisponible ?)";
            return RedirectToAction(nameof(Index));
        }


        // GET /Mission/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var m = await _missions.Get(id);
            if (m is null) return NotFound();

            var vm = new MissionListVm
            {
                Id = m.Id,
                Titre = m.Titre,
                Description = m.Description,
                Debut = m.Debut,
                Fin = m.Fin,
                Budget = m.Budget,
                ClientNom = m.ClientNom,
                Consultants = m.Consultants,
                ConsultantsCount = m.ConsultantIds?.Count
            };
            return View(vm);
        }
    }
}
