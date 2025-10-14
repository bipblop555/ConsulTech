using ConsulTech.Web.Models.ViewModels;
using ConsulTech.Web.Services;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientsClient _clients;
        public ClientsController(ClientsClient clients) => _clients = clients;

        // GET /Clients
        public async Task<IActionResult> Index()
        {
            var dtos = await _clients.GetAll();

            var vm = dtos.Select(c => new ClientListVm
            {
                Id = c.Id,
                Nom = c.Nom,
                Secteur = c.Secteur,
                Adresse = c.Adresse,
                Contact = c.Contact
            }).ToList();
            return View(vm);
        }

        // GET /Clients/Create
        [HttpGet]
        public IActionResult Create() => View(new ClientEditVm());

        // POST /Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientEditVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var dto = new ClientsClient.CreateClientDto(vm.Nom, vm.Secteur, vm.Adresse, vm.Contact);
            await _clients.Create(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET /Clients/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var c = await _clients.Get(id);
            if (c is null) return NotFound();

            var vm = new ClientEditVm
            {
                Nom = c.Nom,
                Secteur = c.Secteur,
                Adresse = c.Adresse,
                Contact = c.Contact
            };
            ViewBag.ClientId = c.Id;
            return View(vm);
        }

        // POST /Clients/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClientEditVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _clients.Update(new ClientsClient.UpdateClientDto(id, vm.Nom, vm.Secteur, vm.Adresse, vm.Contact));

            return RedirectToAction(nameof(Index));
        }

        // POST /Clients/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _clients.Delete(id);
            if (!ok) TempData["Error"] = "Suppression Impossible (API Indisponible ?)";
            return RedirectToAction(nameof(Index));
        }

        // GET /Clients/Details/{id}
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var c = await _clients.Get(id);
            if (c is null) return NotFound();

            var vm = new ClientListVm
            {
                Id = c.Id,
                Nom = c.Nom,
                Secteur = c.Secteur,
                Adresse = c.Adresse,
                Contact = c.Contact
            };
            return View(vm);
        }
    }
}
