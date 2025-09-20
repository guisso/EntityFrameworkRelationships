using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRelationships
{
    [Index(nameof(Email), IsUnique = true)]
    public class Credencial
    {
        public UInt64 Id { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public String? Email { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MinLength(8)]
        [MaxLength(20)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,20}$",
            ErrorMessage = "A senha deve ter no mínimo 8 e no máximo 20 caracteres, incluindo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
        public String? Senha { get; set; }

        [Required]
        [ForeignKey("usuario_id")]
        public Usuario? Usuario { get; set; }

        [ForeignKey("credencial_id")]
        public List<Perfil>? Perfis { get; set; }

        #region Constructors
        public Credencial()
        {
            Perfis = new();
        }
        #endregion

        #region ToString
        public override String ToString()
        {
            return Id
                + ", " + Email
                + ", " + Senha
                + ", Usuario: [" + Usuario?.Id + "]";
        }
        #endregion
    }
}
