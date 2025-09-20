using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRelationships
{
    public class Telefone
    {
        public UInt64 Id { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [Range(1, 99)]
        public Byte Ddd { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [Range(10000000, 999999999)]
        public UInt32 Numero { get; set; }

        [ForeignKey("usuario_id")]
        public Usuario? Usuario { get; set; }
    }
}
