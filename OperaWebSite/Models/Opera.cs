using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using OperaWebSite.Validations;

namespace OperaWebSite.Models
{
    [Table("Opera")]
    public class Opera
    {
        public int OperaId { get; set; }
        [Required(ErrorMessage = "Must give a Title")]
        [StringLength(150)]
        public string Title { get; set; }
        [Required]
        public string Composer { get; set; }
        
        //Llamo mi validacion personalizada
        [CheckValidYear]
        public int Year { get; set; }
    }
}