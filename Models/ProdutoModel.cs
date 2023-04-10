using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = null!;
        public bool Disponivel { get; set; }
        [Required]
        public decimal Preco { get; set; }
    }
}
