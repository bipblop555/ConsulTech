using ConsulTech.Core.Entities;

namespace ConsulTech.Core.DTO;

public sealed class CompetenceDto
{
    public Guid Id { get; set; }

    public string Titre { get; set; } = string.Empty;

    public Categorie Categorie { get; set; } = null!;

    public Niveau Niveau { get; set; } = null!;

    public Consultant Consultant { get; set; } = null!;
}
