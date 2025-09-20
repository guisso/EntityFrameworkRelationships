using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRelationships
{
    public class Endereco
    {
        public UInt64 Id { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MaxLength(15)]
        public String? TipoLogradouro { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MaxLength(120)]
        public String? Logradouro { get; set; }

        // TODO : Implement constraints in the UML class diagram
        [Required]
        public UInt16? Numero { get; set; }
        
        // TODO : Implement constraints in the UML class diagram
        [Required]
        [MaxLength(50)]
        public String? Bairro { get; set; }
        
        // TODO : Implement constraints in the UML class diagram
        [Required]
        public UInt32? Cep { get; set; }

        #region ToString
        public override String ToString()
        {
            return Id
                + ", " + TipoLogradouro
                + ", " + Logradouro
                + ", " + Numero
                + ", " + Bairro
                + ", " + Cep;
        }
        #endregion
    }
}
