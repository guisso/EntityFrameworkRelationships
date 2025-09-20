using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRelationships
{
    public class Repository : DbContext
    {
        private static readonly String _connectionParams = @"server=127.0.0.1;port=3306;uid=root;pwd=;database=basicpersistence";

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Credencial> Credenciais { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<UsuarioEndereco> UsuariosEnderecos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public Repository() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(_connectionParams);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioEndereco>(
                entity =>
                {
                    // Composite primary key
                    entity
                        .HasKey(ue => new { ue.UsuarioId, ue.EnderecoId });

                    // Change foreign key names
                    entity
                        .Property(ue => ue.UsuarioId)
                        .HasColumnName("usuario_id");
                    entity
                        .Property(ue => ue.EnderecoId)
                        .HasColumnName("endereco_id");
                });
        }
    }
}
