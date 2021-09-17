using FluentValidation.Results;
using LibraryAPP.Interfaces;
using LibraryDomain.Entities;
using System.Collections.Generic;
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

        [HttpGet]
        [ActionName("getlistuser")]
        [Route("api/Usuario/getlistuser")]
        public IEnumerable<Usuario> GetListUser(string filter)
        {
            return _usuarioAppService.GetListUser(filter); 
        }


        // POST api/Usuario
        public ValidationResult Post([FromBody] Usuario obj)
        {
            return _usuarioAppService.Add(obj); 
        }

        // PUT api/Usuario/5
        public ValidationResult Put(int id, [FromBody] Usuario obj)
        {
            return _usuarioAppService.Update(obj); 
        }

        // DELETE api/Usuario/5
        [HttpDelete]
        public ValidationResult Delete(int id)
        {
            Usuario obj = _usuarioAppService.Find(id);
            return _usuarioAppService.Remove(obj); 
        }
    }
}