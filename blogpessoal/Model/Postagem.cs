using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace blogpessoal.Model
{
    public class Postagem : Auditable
    {
        [Key] // Primary Key (Id)
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // IDENTITY(1,1)
        public long Id {get; set;}
        
        [Column(TypeName = "varchar")] //Definindo como atributo da tabela e o tipo
        [StringLength(100)] //Definindo o máximo de caracteres
        public string Titulo {get; set;} = string.Empty;

        [Column(TypeName = "varchar")] //Definindo como atributo da tabela e o tipo
        [StringLength(1000)] //Definindo o máximo de caracteres
        public string Texto {get; set;} = string.Empty;

        public virtual Tema? Tema {get; set;}

        public virtual User? Usuario {get; set;}
    }
}