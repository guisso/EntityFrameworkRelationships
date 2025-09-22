using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkRelationships
{
    internal class UsuarioRepository
    {
        public static void Save(Usuario usuario)
        {
            try
            {
                using (Repository dbContext = new())
                {
                    if (usuario.Id == 0)
                    {
                        //
                        // Pay attention to related entities!
                        // If they are not attached, EF Core will try to insert them again!
                        //
                        foreach (Telefone t in usuario.Telefones)
                        {
                            if (t?.Id != null && t?.Id != 0)
                            {
                                // Attach related entities to avoid duplicate inserts
                                dbContext.Enderecos.Attach(t);
                            }
                        }

                        foreach (UsuarioEndereco ue in usuario.UsuariosEnderecos)
                        {
                            if (ue.Endereco?.Id != null && ue.Endereco?.Id != 0)
                            {
                                // Attach related entities to avoid duplicate inserts
                                dbContext.Enderecos.Attach(ue.Endereco);
                            }
                        }

                        dbContext.Usuarios.Add(usuario);
                    }
                    else
                    {
                        //
                        // Pay attention to related entities!
                        // If they are not attached, EF Core will try to insert them again!
                        //
                        foreach (Telefone t in usuario.Telefones)
                        {
                            if (t?.Id != null && t?.Id != 0)
                            {
                                // Attach related entities to avoid duplicate inserts
                                dbContext.Telefones.Attach(t);
                            }
                        }

                        foreach (UsuarioEndereco ue in usuario.UsuariosEnderecos)
                        {
                            if (ue.UsuarioId != null && ue.UsuarioId != 0)
                            {
                                // Attach related entities to avoid duplicate inserts
                                dbContext.UsuariosEnderecos.Attach(ue);
                            }
                        }

                        dbContext.Entry(usuario).State
                            = EntityState.Modified;
                    }

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> FindAll()
        {
            try
            {
                using (Repository dbContext = new())
                {
                    return dbContext.Usuarios.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Usuario? FindById(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new())
                {
                    return dbContext.Usuarios.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Usuario? FindByIdWCredencial(UInt64 id)
        {
            try
            {
                using (Repository dbContext = new())
                {
                    return dbContext.Usuarios
                        .Include("Credencial")
                        .Where(u => u.Id == id)
                        .FirstOrDefault<Usuario>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> FindByPartialName(String partialName)
        {
            try
            {
                using (Repository dbContext = new())
                {
                    return dbContext.Usuarios
                        .Where(u => u.Nome.Contains(partialName))
                        .ToList<Usuario>();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Remove(Usuario usuario)
        {
            try
            {
                using (Repository dbContext = new())
                {
                    dbContext.Usuarios.Attach(usuario);
                    dbContext.Usuarios.Remove(usuario);

                    // OR

                    // But cascade delete fails...
                    //dbContext.Entry(usuario).State
                    //    = EntityState.Deleted;

                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
