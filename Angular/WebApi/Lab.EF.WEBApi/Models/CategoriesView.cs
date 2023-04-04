using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.EF.WEBApi.Models
{
    public class CategoriesView
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string NombreCategoria { get; set; }

        [Required]
        [StringLength(30)]
        public string Descripcion { get; set; }
    }
}