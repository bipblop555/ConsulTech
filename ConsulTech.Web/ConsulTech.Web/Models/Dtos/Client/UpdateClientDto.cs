namespace ConsulTech.Web.Models.Dtos.Client;

public record UpdateClientDto
{
    public Guid Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Secteur { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}
