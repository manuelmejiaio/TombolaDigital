using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TombolaDigital.Models
{
    public class PremioModels
    {
        [Key]
        public int premioID { get; set; }
        public string nombrePremio { get; set; }

    }
}