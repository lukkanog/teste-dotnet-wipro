using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Models
{
    [Table("Locacoes")]
    public class Locacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLocacao { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        [ForeignKey("Filme")]
        public int IdFilme { get; set; }
        public Filme Filme { get; set; }
    }
}
