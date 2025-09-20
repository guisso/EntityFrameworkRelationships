using System;
using System.ComponentModel.DataAnnotations;

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

        #region ToString
        public override String ToString()
        {
            return Id
                + ", " + Nome
                + ", " + Credencial?.Email
                + ", " + Credencial?.Senha;
        }
        #endregion
    }
}
