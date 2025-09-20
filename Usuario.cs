using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityFrameworkRelationships
{
    public class Usuario
    {
        public Int64 Id { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MaxLength(45)]
        public String? Nome { get; set; }

        // TODO : Implement automatic bidirectional one-to-one relationship
        // Foreign key is in Credencial class. I assumed it was DEPENDENT.
        public Credencial? Credencial { get; set; }

        // TODO : Implement automatic bidirectional one-to-one relationship
        public List<Telefone>? Telefones { get; set; }

        // TODO : Implement AdicionarTelefone() method

        #region ToString
        public override String ToString()
        {
            return Id
                + ", " + Nome
                + ", Credencial: " + Credencial
                + ", Telefones: " + (Telefones is null
                    ? "---"
                    : $"[{String.Join(", ", Telefones)}]");
        }
        #endregion
    }
}
