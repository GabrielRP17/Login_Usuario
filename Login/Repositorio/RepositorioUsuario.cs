using Login.Interface;
using Login.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        public void AlterarUsuario(Usuario usu)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Gabriel;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("update Usuario set UsuarioSenha = @UsuarioSenha where UsuarioId = @UsuarioId", _conn);
                cmd.Parameters.AddWithValue("@UsuarioId", usu.UsuarioId);
                cmd.Parameters.AddWithValue("@UsuarioSenha", usu.UsuarioSenha.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }

        public int VerificarUsuario(string Email, string senha)
        {
            Usuario usu = new Usuario();
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Gabriel;Integrated Security=True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select usu.UsuarioId from Usuario usu where usu.UsuarioEmail = @Email and usu.UsuarioSenha = @Senha", _conn);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Senha", senha);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu.UsuarioId = Convert.ToInt32(dr["UsuarioId"].ToString());
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }

            return 1;
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usu = new Usuario();
            SqlConnection _conn = new SqlConnection("Data Source = DESKTOP - 1SNHF9S/SQLEXPRESS02; Initial Catalog = Gabriel; Integrated Security = True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select usu.UsuarioNome, usu.UsuarioEmail, usu.UsuarioSenha from Usuario usu", _conn);
                cmd.Parameters.AddWithValue("@UsuarioId", id);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu.UsuarioEmail = dr["UsuarioEmail"].ToString().Replace(".", "").Replace("_", "");
                    usu.UsuarioSenha = dr["UsuarioSenha"].ToString();
                    usu.UsuarioNome = dr["UsuarioNome"].ToString();
                }
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
            return usu;
        }

        public Usuario BuscarporSenha(string sen)
        {
            Usuario usu = new Usuario();
            SqlConnection _conn = new SqlConnection("Data Source = DESKTOP - 1SNHF9S/SQLEXPRESS02; Initial Catalog = Gabriel; Integrated Security = True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd= new SqlCommand ("select usu.UsuarioNome, usu.UsuarioEmail, usu.UsuarioSenha from Usuario usu", _conn);
                cmd.Parameters.AddWithValue("@UsuarioSenha", usu);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu.UsuarioEmail = dr["UsuarioEmail"].ToString().Replace(".", "").Replace("_", "");
                    usu.UsuarioNome = dr["UsuarioNome"].ToString();  
                }
            }
            finally
            {
                if(dr != null)
                {
                    dr.Close();
                }
                if(_conn != null)
                {
                    _conn.Close();
                }
            }
            return usu;
        }

        public List<Usuario> BuscarTodos()
        {
            Usuario usu = null;
            List<Usuario> ListUsu = new List<Usuario>();
            SqlConnection _conn = new SqlConnection("Data Source = DESKTOP - 1SNHF9S/SQLEXPRESS02; Initial Catalog = Gabriel; Integrated Security = True");
            SqlDataReader dr = null;
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("select usu.UsuarioNome, usu.UsuarioEmail, usu.UsuarioSenha from Usuario usu", _conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu = new Usuario();
                    usu.UsuarioEmail = dr["UsuarioEmail"].ToString().Replace(".", "").Replace("_", "");
                    usu.UsuarioNome = dr["UsuarioNome"].ToString();
                    usu.UsuarioSenha = dr["UsuarioSenha"].ToString();
                    ListUsu.Add(usu);  
                } 
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close(); 
                }
                if(_conn != null)
                {
                    _conn.Close();
                }
            }
            return ListUsu; 
        }

        public void InserirUsuario(Usuario usu)
        {
            SqlConnection _conn = new SqlConnection(@"Data Source=DESKTOP-1SNHF9S\SQLEXPRESS02;Initial Catalog=Gabriel;Integrated Security=True");
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Usuario(UsuarioNome, UsuarioEmail, UsuarioSenha)values(@UsuarioNome, @UsuarioEmail, @UsuarioSenha)", _conn);

                cmd.Parameters.AddWithValue("@UsuarioNome", usu.UsuarioNome.ToString());
                cmd.Parameters.AddWithValue("@UsuarioEmail", usu.UsuarioEmail.ToString());
                cmd.Parameters.AddWithValue("@UsuarioSenha", usu.UsuarioSenha.ToString());

                cmd.ExecuteNonQuery();
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
