using ConsulTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.DTO
{
    public sealed class CompetenceDto
    {
        public Guid Id { get; set; }

        public string Titre { get; set; } = string.Empty;

        public Categorie Categorie { get; set; } = null!;

        public Niveau Niveau { get; set; } = null!;
    }
}
