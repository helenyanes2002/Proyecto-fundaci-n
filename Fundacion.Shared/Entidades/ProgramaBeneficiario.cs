using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fundacion.Shared.Entidades
{
    public class ProgramaBeneficiario
    {
        public int Id { get; set; }

        //Relaciones 
        public int ProgramaId { get; set; }

        public int BeneficiarioId { get; set; }

        [JsonIgnore]
        public Programa Programas { get; set; }

        [JsonIgnore]
        public Beneficiario Beneficiarios { get; set; }

    }
}
