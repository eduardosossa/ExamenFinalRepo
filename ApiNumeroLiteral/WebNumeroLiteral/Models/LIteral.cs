using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebNumeroLiteral.Models
{
    public class LIteral
    {
        [Key]
        [Required]
        public int NumeroId { get; set; }
        [Required]
        public string FormaLiteral { get; set; }
    }
}