using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsulTech.Core.DTO
{
    public sealed class NiveauDto
    {
        public Guid Id { get; set; }

        public string Titre { get; set; } = string.Empty;
    }
}
