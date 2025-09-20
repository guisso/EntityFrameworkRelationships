using System;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkRelationships
{
    public class Telefone
    {
        public UInt64 Id { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        public Byte Ddd { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        public UInt32 Numero { get; set; }
    }
}
