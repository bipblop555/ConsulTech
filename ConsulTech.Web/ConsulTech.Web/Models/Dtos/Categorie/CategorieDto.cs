namespace ConsulTech.Web.Models.Dtos.Categorie;

public record CategorieDto()
{
    public Guid Id { get; set; }
    public string Titre { get; set; } = string.Empty;
};
