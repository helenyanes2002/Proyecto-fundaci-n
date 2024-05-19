using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fundacion.Shared.Entidades
{
    public class DonacionMonetaria
    {
        public int Id { get; set; }

        [Display(Name = "Monto")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Monto { get; set; }

        [Display(Name = "Propósito")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Proposito { get; set; }

        [Display(Name = "Método de pago")]
        [MaxLength(20, ErrorMessage = "No se permiten más de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string MetodoPago { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime Fecha { get; set; }

        //Relaciones 
        public ICollection<DonacionMonetariaGasto> DonacionesMonetariasGastos { get; set; }

        public int DonanteId { get; set; }

        [JsonIgnore]
        public Donante Donantes { get; set; }

    }
}
