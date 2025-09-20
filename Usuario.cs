using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkRelationships
{
    public class Usuario
    {
        public UInt64 Id { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MaxLength(45)]
        public String? Nome { get; set; }

        // TODO : Implement automatic bidirectional one-to-one relationship
        // Foreign key is in Credencial class. I assumed it was DEPENDENT.
        public Credencial? Credencial { get; set; }

        // TODO : Implement automatic bidirectional one-to-one relationship
        public List<Telefone>? Telefones { get; set; }

        // WARNING : In bidirectional relationships, no Fluente API is needed
        // TODO : Implement automatic bidirectional one-to-one relationship
        public List<UsuarioEndereco>? UsuariosEnderecos { get; set; }

        // TODO : Implement AdicionarTelefone() method
        // TODO : Implement AdicionarUsuarioEndereco() method

        #region ToString
        public override String ToString()
        {
            return Id
                + ", " + Nome
                + ", Credencial: " + Credencial
                + ", Telefones: " + (Telefones is null
                    ? "---"
                    : $"[{String.Join(", ", Telefones)}]")
                    + ", Enderecos: " 
                    + (Enderecos is null
                        ? "---"
                        : $"[{String.Join(", ", Enderecos)}]");
        }
        #endregion
    }
}
