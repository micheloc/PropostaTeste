using LibraryAPP.Interfaces;
using LibraryDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService; 
        }

        // GET api/usuario
        public IEnumerable<Usuario> Get()
        {
            return _usuarioAppService.GetAll();
        }

        // GET api/Usuario/5
        public Usuario Get(int id)
        {
            return _usuarioAppService.Find(id);
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}