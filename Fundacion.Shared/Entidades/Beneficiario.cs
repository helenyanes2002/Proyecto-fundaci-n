using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundacion.Shared.Entidades
{
    public class Beneficiario
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Edad")]
        [MaxLength(5, ErrorMessage = "No se permiten más de 5 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Edad { get; set; }

        [Display(Name = "Información de contacto")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Informacion { get; set; }

        [Display(Name = "Programa participativo")]
        [MaxLength(100, ErrorMessage = "No se permiten más de 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Programa { get; set; }

        //Relaciones
        public ICollection<ProgramaBeneficiario> ProgramasBeneficiarios { get; set; }

    }
}
