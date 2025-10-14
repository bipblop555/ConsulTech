using ConsulTech.Web.Models.ViewModels.Categories;
using ConsulTech.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsulTech.Web.Controllers;

public class CategoriesController : Controller
{

    private readonly CategoriesClient _clients;

    public CategoriesController(CategoriesClient client) => _clients = client;

    // GET: CategorieController
    public async Task<ActionResult> Index()
    {
        var dtos = await _clients.GetAll();
        var vm = dtos.Select(c => new CategorieListVm
        {
            Id = c.Id,
            Titre = c.Titre
        }).ToList();

        return View(vm);
    }

    // GET: CategorieController/Create
    public ActionResult Create() => View(new CategorieEditVm());

    // POST: CategorieController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategorieEditVm vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var dto = new CategoriesClient.CreateCategorieDto(vm.Titre);
        await _clients.Create(dto);

        return RedirectToAction(nameof(Index));
    }



    // GET: CategorieController/Edit/5
    public async Task<IActionResult> Edit(Guid id)
    {
        var categorie = await _clients.Get(id);
        if (categorie is null)
            return NotFound();

        var vm = new CategorieEditVm
        {
            Titre = categorie.Titre
        };
        ViewBag.CategorieId = categorie.Id;
        return View(vm);
    }

    // POST: CategorieController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(Guid id, CategorieEditVm vm)
    {
        if(!ModelState.IsValid)
            return View(vm);

        await _clients.Update(new CategoriesClient.UpdateClientDto(id, vm.Titre));

        return RedirectToAction(nameof(Index));
    }


    // POST: CategorieController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(Guid id)
    {
        var ok = await _clients.Delete(id);
        return RedirectToAction(nameof(Index));
    }


    // GET: CategorieController/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var categories = await _clients.Get(id);
        if (categories is null)
            return NotFound();

        var vm = new CategorieListVm
        {
            Id = categories.Id,
            Titre = categories.Titre
        };

        return View(vm);
    }
}
