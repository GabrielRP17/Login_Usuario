using Login.Interface;
using Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Login.Service
{
    public class ServiceUsuario : IServiceUsuario
    {
        public readonly IRepositorioUsuario _repositorio;
        public ServiceUsuario(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }



        public void AlterarUsuario(Usuario usu)
        {
            string has = GeraMD5Hash(usu.UsuarioSenha);
            usu.UsuarioSenha = has;
            _repositorio.AlterarUsuario(usu);
        }
        public Usuario BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public List<Usuario> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public void InserirUsuario(Usuario usu)
        {
            string has = GeraMD5Hash(usu.UsuarioSenha);
            usu.UsuarioSenha = has;
            _repositorio.InserirUsuario(usu);
        }

        public int VerificarUsuario(string Email, string senha)
        {
            string senhaCriptografada = GeraMD5Hash(senha);
            return _repositorio.VerificarUsuario(Email, senhaCriptografada);
        }

        public Usuario BuscarporSenha(string sen)
        {
            return _repositorio.BuscarporSenha(sen);
        }

        public static string GeraMD5Hash(string texto)
        {
            //cria instância da classe MD5CryptoServiceProvider
            MD5CryptoServiceProvider MD5provider = new MD5CryptoServiceProvider();
            //gera o hash do texto
            byte[] valorHash = MD5provider.ComputeHash(Encoding.Default.GetBytes(texto));
            StringBuilder str = new StringBuilder();
            //retorna o hash
            for (int contador = 0; contador < valorHash.Length; contador++)
            {
                str.Append(valorHash[contador].ToString("x2"));
            }
            return str.ToString();

        }

        static bool VerificaMD5Hash(string texto, string valorHashArmazenado)
        {
            //gera o hash para o texto
            string valorHash2 = GeraMD5Hash(texto);
            // Cria um StringComparer e compara o hash gerado com o armazenado
            StringComparer strcomparer = StringComparer.OrdinalIgnoreCase;
            //se o valor dos hash forem iguais então retorna true
            if (strcomparer.Compare(valorHash2, valorHashArmazenado).Equals(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
