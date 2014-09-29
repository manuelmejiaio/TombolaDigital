using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TombolaDigital.Models
{
    public class ParticipanteModels
    {
        [Key]
        public int participanteID { get; set; }

        [Required(ErrorMessage = "El numero de cédula es requerido.")]
        [StringLength(100, ErrorMessage = "La {0} debe contener {2} números. ", MinimumLength = 11)]
        [DataType(DataType.Text)]
        [Display(Name = "cédula")]
        public string cedula { get; set; }
        public string nombreParticipante { get; set; }
        public string apellidoParticipante { get; set; }

        public int ubicacionID { get; set; }
        [ForeignKey("ubicacionID")]
        public virtual UbicacionModels Ubicacion { get; set; }

    }
}