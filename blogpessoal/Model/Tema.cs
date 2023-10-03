using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogpessoal.Model
{
    public class Tema
    {
        [Key] // Primary Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY(1,1)
        public long Id { get; set; }

        [Column(TypeName = "varchar")] //Definindo como atributo da tabela e o tipo
        [StringLength(255)] //Definindo o máximo de caracteres
        public string Descricao { get; set; } = string.Empty;

        [InverseProperty("Tema")]
        public virtual ICollection<Postagem>? Postagem { get; set; }
    }
}