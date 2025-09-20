using System;

namespace EntityFrameworkRelationships
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("EntityFrameworkRelationships running");

            #region Usuario
            // Usuario creation
            Usuario u1 = new Usuario
            {
                Nome = "Ana Zaira"
            };

            Usuario u2 = new Usuario
            {
                Nome = "Zélia Alcântara"
            };
            #endregion

            #region Telefone
            // Telefone creation for u1
            Telefone t1 = new Telefone
            {
                Ddd = 11,
                Numero = 11111111
            };

            Telefone t2 = new Telefone
            {
                Ddd = 12,
                Numero = 911111111
            };

            // Telefone ligation

            u1.Telefones?.Add(t1);
            u1.Telefones?.Add(t2);

            t1.Usuario = u1;
            t2.Usuario = u1;

            // Telefone creation for u2

            Telefone t3 = new Telefone
            {
                Ddd = 21,
                Numero = 22222222
            };

            Telefone t4 = new Telefone
            {
                Ddd = 23,
                Numero = 822222222
            };

            Telefone t5 = new Telefone
            {
                Ddd = 24,
                Numero = 922222222
            };

            // Telefone ligation

            u2.Telefones?.Add(t3);
            u2.Telefones?.Add(t4);
            u2.Telefones?.Add(t5);

            t3.Usuario = u2;
            t4.Usuario = u2;
            t5.Usuario = u2;
            #endregion

            // Endereco creation for u1 and u2
            Endereco e1 = new Endereco
            {
                TipoLogradouro = "Alameda",
                Logradouro = "dos Abacaxis",
                Numero = 100,
                Bairro = "Jardim dos Abacaxis",
                Cep = 11111111
            };

            Endereco e2 = new Endereco
            {
                TipoLogradouro = "Baixa",
                Logradouro = "das Bananas",
                Numero = 200,
                Bairro = "Jardim dos Bananais",
                Cep = 22222222
            };

            Endereco e3 = new Endereco
            {
                TipoLogradouro = "Chácara",
                Logradouro = "dos Caquis",
                Numero = 300,
                Bairro = "Jardim dos Caquizais",
                Cep = 33333333
            };

            // Endereco ligation
            UsuarioEndereco ue1 = new UsuarioEndereco
            {
                Usuario = u1,
                Endereco = e1
            };

            UsuarioEndereco ue2 = new UsuarioEndereco
            {
                Usuario = u1,
                Endereco = e2
            };

            UsuarioEndereco ue3 = new UsuarioEndereco
            {
                Usuario = u2,
                Endereco = e2
            };

            UsuarioEndereco ue4 = new UsuarioEndereco
            {
                Usuario = u2,
                Endereco = e3
            };

            u1.UsuariosEnderecos?.Add(ue1);
            u1.UsuariosEnderecos?.Add(ue2);
            u2.UsuariosEnderecos?.Add(ue3);
            u2.UsuariosEnderecos?.Add(ue4);

            // Credencial creation and ligation for u1
            Credencial c1 = new Credencial
            {
                Email = "ana.zaira@mail.com",
                Senha = "123456789",
                Usuario = u1
            };

            u1.Credencial = c1;

            // Credencial creation and ligation for u2
            Credencial c2 = new Credencial
            {
                Email = "zelia.alcantara@mail.com",
                Senha = "98765421",
                Usuario = u2
            };

            u2.Credencial = c2;

            // Perfil creation for c1 and c2
            Perfil p1 = new Perfil
            {
                Tipo = 'A',
                Ler = true,
                Escrever = true,
                Excluir = true
            };

            Perfil p2 = new Perfil
            {
                Tipo = 'B',
                Ler = true,
                Escrever = true,
                Excluir = false
            };

            Perfil p3 = new Perfil
            {
                Tipo = 'C',
                Ler = true,
                Escrever = false,
                Excluir = false
            };

            // Credencial ligation for c1 and p1/p2/p3
            c1.Perfis?.Add(p1);
            p1.Credenciais?.Add(c1);

            c1.Perfis?.Add(p2);
            p2.Credenciais?.Add(c1);

            c1.Perfis?.Add(p3);
            p3.Credenciais?.Add(c2);

            // Credencial ligation for c2 and p1/p3
            c2.Perfis?.Add(p1);
            p1.Credenciais?.Add(c2);

            c2.Perfis?.Add(p3);
            p3.Credenciais?.Add(c2);

            // Persist data
            UsuarioRepository.Save(u1);
            UsuarioRepository.Save(u2);


        }
    }
}
