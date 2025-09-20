using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkRelationships
{
    [Index(nameof(Tipo), IsUnique = true)]
    public class Perfil
    {
        public UInt64 Id { get; set; }

        [Required]
        public Char? Tipo { get; set; }

        public Boolean? Ler { get; set; }

        public Boolean? Escrever { get; set; }

        public Boolean? Excluir { get; set; }

        [ForeignKey("perfil_id")]
        public List<Credencial>? Credenciais { get; set; }

        // TODO : Implement AdicionarCredencial() method
    }
}
