using ConsulTech.Web.Models.Dtos.Competence;
using ConsulTech.Web.Models.ViewModels.Competence;
using ConsulTech.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ConsulTech.Web.Controllers;

public class CompetenceController : Controller
{
    private readonly CompetencesClient _clients;
    private readonly NiveauClient _niveaux;
    private readonly CategoriesClient _categories;
    private readonly ConsultantsClient _consultants;

    public CompetenceController
        (
        CompetencesClient client,
        NiveauClient niveauClient,
        CategoriesClient categoriesClient,
         ConsultantsClient consultants
        )
    {
        _clients = client;
        _niveaux = niveauClient;
        _categories = categoriesClient;
        _consultants = consultants;
    }

    // GET: CompetenceController
    public async Task<ActionResult> Index()
    {
        List<CompetenceDto>? dtos = await _clients.GetAll();

        List<CompetenceBaseViewModel>? vm = dtos.Select(c => new CompetenceBaseViewModel
        {
            Id = c.Id,
            Titre = c.Titre,
            Categorie = c.CategorieName,
            Niveau = c.NiveauName
        }).ToList();
        return View(vm);
    }

    // GET: CompetenceController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var competence = await _clients.Get(id);
        if (competence is null)
            return NotFound();
        var vm = new CompetenceBaseViewModel
        {
            Id = competence.Id,
            Titre = competence.Titre,
            Categorie = competence.CategorieName,
            Niveau = competence.NiveauName,
        };
        return View(vm);
    }

    // GET: CompetenceController/Create
    public async Task<ActionResult> Create()
    {
        var vm = new CompetenceEditViewModel();
        vm = await PopulateListAsync(vm);
        return View(vm);
    }

    // POST: CompetenceController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CompetenceEditViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            vm = await PopulateListAsync(vm);
            return View(vm);
        }

        var dto = new CreateCompetenceDto
        {
            Titre = vm.Titre,
            CategorieId = vm.CategorieId,
            NiveauId = vm.NiveauId,
            ConsultantsId = new List<Guid> { vm.ConsultantId }
        };

        await _clients.Create(dto);
        return RedirectToAction(nameof(Index));
    }

    // GET: CompetenceController/Edit/5
    public async Task<ActionResult> Edit(Guid id)
    {
        CompetenceDto? compFromApi = await _clients.Get(id);
        if (compFromApi is null)
            return NotFound();

        var vm = new CompetenceEditViewModel
        {
            Id = compFromApi.Id,
            Titre = compFromApi.Titre,
            CategorieId = compFromApi.CategorieId,
            NiveauId = compFromApi.NiveauId,
        };

        vm = await PopulateListAsync(vm);

        return View(vm);
    }

    // POST: CompetenceController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, CompetenceEditViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            return View(vm);
        }

        await _clients.Update(new CreateCompetenceDto
        {
            Titre = vm.Titre,
            CategorieId = vm.CategorieId,
            NiveauId = vm.NiveauId,
            ConsultantsId = new List<Guid> { vm.ConsultantId }
        }, id);

        return RedirectToAction(nameof(Index));
    }

    // GET: CompetenceController/Delete/5
    public async Task<ActionResult> Delete(Guid id)
    {
        var ok = await _clients.Delete(id);
        if (!ok) TempData["Error"] = "Suppression Impossible (API Indisponible ?)";
        return RedirectToAction(nameof(Index));
    }

    private async Task<CompetenceEditViewModel> PopulateListAsync(CompetenceEditViewModel vm)
    {
        var niveauxFromApi = await _niveaux.GetAll();
        if (niveauxFromApi is not null)
        {
            vm.Niveaux = niveauxFromApi
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Titre })
                .ToList();
        }

        var categoriesFromApi = await _categories.GetAll();
        if (categoriesFromApi is not null)
        {
            vm.Categories = categoriesFromApi
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Titre })
                .ToList();
        }

        List<ConsultantsClient.ConsultantDto>? consultantFromApi = await _consultants.GetAll();
        if (consultantFromApi is not null)
        {
            vm.Consultants = consultantFromApi
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Nom })
                .ToList();
        }

        return vm;
    }
}
