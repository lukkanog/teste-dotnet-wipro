using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebApi.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Por favor, insira o nome do cliente")]
        [Column("Nome", TypeName = "VARCHAR(250)")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Por favor, insira o email do cliente")]
        [Column("Email", TypeName = "VARCHAR(150)")]
        public string Email { get; set; }

        public ICollection<Locacao> Locacoes { get; set; }

    }
}
