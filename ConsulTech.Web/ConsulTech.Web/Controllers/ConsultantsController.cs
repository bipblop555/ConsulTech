using ConsulTech.Web.Models.Dtos.Consultant;
using ConsulTech.Web.Models.ViewModels.Consultant;
using ConsulTech.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Web.Controllers
{
    public class ConsultantsController : Controller
    {
        private readonly ConsultantsClient _consultants;
        public ConsultantsController(ConsultantsClient consultants) => _consultants = consultants;

        // GET /Consultants
        public async Task<IActionResult> Index()
        {
            var dtos = await _consultants.GetAll();
            var vm = dtos.Select(c => new ConsultantListVm
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                DateEmbauche = c.DateEmbauche,
                EstDisponible = c.EstDisponible,
                Competences = c.Competences?.Select(k => k.Titre).ToList() ?? new()
            }).ToList();

            return View(vm);
        }

        // GET /Consultants/Create
        [HttpGet]
        public IActionResult Create() => View(new ConsultantEditVm());

        // POST /Consultants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConsultantEditVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var ok = await _consultants.Create(new CreateConsultantDto()
            {
                Nom = vm.Nom,
                Prenom = vm.Prenom,
                Email = vm.Email,
                DateEmbauche = vm.DateEmbauche,
                EstDisponible = vm.EstDisponible
            });

            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "Création impossible (API ?)");
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET /Consultants/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var c = await _consultants.Get(id);
            if (c is null) return NotFound();

            var vm = new ConsultantEditVm
            {
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                DateEmbauche = c.DateEmbauche,
                EstDisponible = c.EstDisponible
            };
            ViewBag.ConsultantId = c.Id;
            return View(vm);
        }

        // POST /Consultants/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ConsultantEditVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var ok = await _consultants.Update(new UpdateConsultantDto
            {
                Id = id,
                Nom = vm.Nom,
                Prenom = vm.Prenom,
                Email = vm.Email,
                DateEmbauche = vm.DateEmbauche,
                EstDisponible = vm.EstDisponible
            });

            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "Mise à jour impossible (API ?)");
                return View(vm);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET /Consultants/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var c = await _consultants.Get(id);
            if (c is null) return NotFound();

            var vm = new ConsulTech.Web.Models.ViewModels.Consultant.ConsultantListVm
            {
                Id = c.Id,
                Nom = c.Nom,
                Prenom = c.Prenom,
                Email = c.Email,
                DateEmbauche = c.DateEmbauche,
                EstDisponible = c.EstDisponible,
                Competences = c.Competences.Select(k => k.Titre).ToList() ?? new()
            };
            return View(vm);
        }

        // POST /Clients/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _consultants.Delete(id);
            if (!ok) TempData["Error"] = "Suppression Impossible (API Indisponible ?)";
            return RedirectToAction(nameof(Index));
        }
    }
}
