using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiReceitas.ApiReceitas.Domain
{
    [Table("Ingrediente")]
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}
