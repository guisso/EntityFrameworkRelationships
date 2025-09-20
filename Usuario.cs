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

        #region ToString
        public override String ToString()
        {
            return Id
                + ", " + Nome;
        }
        #endregion
    }
}
