using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Models
{
    [Table("Filmes")]
    public class Filme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome do filme")]
        [Column("Nome", TypeName = "VARCHAR(250)")]
        public string Nome { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }
    }
}
