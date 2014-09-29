using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TombolaDigital.Models
{
    public class UbicacionModels
    {
        [Key]
        public int ubicacionID { get; set; }
        public string nombreUbicacion { get; set; }
    }
}