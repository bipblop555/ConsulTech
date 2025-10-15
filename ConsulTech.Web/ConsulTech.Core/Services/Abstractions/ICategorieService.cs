using ConsulTech.Core.DTO;
using ConsulTech.Core.Entities;

namespace ConsulTech.Core.Services.Abstractions
{
    public interface ICategorieService
    {
        Task<List<CategorieDto>> GetAllCategoriesAsync();
        Task<CategorieDto?> GetCategorieByIdAsync(Guid id);
        Task<Guid> CreateCategorieAsync(CategorieDto categorieDto);
        Task<Guid> UpdateCategorieAsync(CategorieDto categorieDto);
        Task<bool> DeleteCategorieAsync(Guid id);
    }
}
