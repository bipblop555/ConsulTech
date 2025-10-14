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

    public CompetenceController(CompetencesClient client, NiveauClient niveauClient, CategoriesClient categoriesClient)
    {
        _clients = client;
        _niveaux = niveauClient;
        _categories = categoriesClient;
    }

    // GET: CompetenceController
    public async Task<ActionResult> Index()
    {
        var dtos = await _clients.GetAll();

        var vm = dtos.Select(c => new CompetenceBaseViewModel
        {
            Id = c.Id,
            Titre = c.Titre,
            Categorie = c.Categorie.Titre,
            Niveau = c.Niveau.Titre,
            Consultant = c.Consultant
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
            Categorie = competence.Categorie.Titre,
            Niveau = competence.Niveau.Titre,
            Consultant = competence.Consultant
        };
        return View(vm);
    }

    // GET: CompetenceController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CompetenceController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CompetenceController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: CompetenceController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: CompetenceController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CompetenceController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    private async Task<CompetenceEditViewModel> PopulateListAsync(CompetenceEditViewModel vm)
    {
        var niveauxFromApi = await _niveaux.GetAll();
        if(niveauxFromApi is not null)
        {
            vm.Niveaux = niveauxFromApi
                .Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.Titre})
                .ToList();
        }

        var categoriesFromApi = await _categories.GetAll();
        if(categoriesFromApi is not null)
        {
            vm.Categories = categoriesFromApi
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Titre })
                .ToList();
        }

        return vm;
    }
}
