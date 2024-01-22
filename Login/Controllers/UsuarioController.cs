using Login.Interface;
using Login.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Login.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IServiceUsuario _service;
        public UsuarioController(IServiceUsuario service)
        {
            _service = service;
        }

        [HttpGet("VerificarUsuario/{Email}/{senha}")]
        public bool VerificarUsuario(string Email, string senha)
        {
            bool retorno = false;

            if (_service.VerificarUsuario(Email, senha) != 0)
                retorno = true;

            return retorno;
        }

        [HttpPost]
        public void Post(Usuario value)
        {

            _service.InserirUsuario(value);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Usuario usu)
        {
            _service.AlterarUsuario(usu);
        }

    }
}
