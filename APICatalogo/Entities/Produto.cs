using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
    
namespace APICatalogo.Entities
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string? Nome { get; set; }

        public decimal Preco { get; set; }

        public float Velocidade { get; set; }
        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
    }
}
