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
    public class SexoController : ApiController
    {
        private readonly ISexoAppService _sexoAppService;
        public SexoController(ISexoAppService appService)
        {
            _sexoAppService = appService; 
        }


        // GET api/<controller>
        public IEnumerable<Sexo> Get()
        {
            return _sexoAppService.GetAll(); 
        }

        // GET api/<controller>/5
        public Sexo Get(int id)
        {
            return _sexoAppService.Find(id);
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