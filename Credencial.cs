using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkRelationships
{
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
        public String? Senha { get; set; }
    }
}
