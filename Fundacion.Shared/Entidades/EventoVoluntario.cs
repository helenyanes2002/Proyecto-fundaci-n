using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fundacion.Shared.Entidades
{
    public class EventoVoluntario
    {
        public int Id { get; set; }

        //Relaciones 
        public int EventoId { get; set; }

        public int VoluntarioId { get; set; }

        [JsonIgnore]
        public Evento Eventos { get; set; }

        [JsonIgnore]
        public Voluntario Voluntarios { get; set; }

    }
}
