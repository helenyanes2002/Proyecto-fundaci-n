using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fundacion.Shared.Entidades
{
    public class DonacionMonetariaGasto
    {
        public int Id { get; set; }

        //Relaciones

        public int GastoId { get; set; }

        public int DonacionMonetariaId { get; set; }

        [JsonIgnore]
        public Gasto Gastos { get; set; }

        [JsonIgnore]
        public DonacionMonetaria DonacionesMonetarias { get; set; }



    }
}
