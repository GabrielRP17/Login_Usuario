using Login.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Interface
{
    public interface IServiceUsuario
    {
        public List<Usuario> BuscarTodos();
        public int VerificarUsuario(string Email, string senha);
        public Usuario BuscarporSenha(string sen);
        public Usuario BuscarPorId(int id);
        public void AlterarUsuario(Usuario usu);
        public void InserirUsuario(Usuario usu);

    }
}
