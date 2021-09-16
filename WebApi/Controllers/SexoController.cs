using FluentValidation.Results;
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
        public ValidationResult Post([FromBody] Sexo obj)
        {
            return _sexoAppService.Add(obj);
        }

        // PUT api/<controller>/5
        public ValidationResult Put(int id, [FromBody] Sexo obj)
        {
            return _sexoAppService.Update(obj); 
        }

        // DELETE api/<controller>/5
        public ValidationResult Delete(int id)
        {
            Sexo obj = _sexoAppService.Find(id);
            return _sexoAppService.Remove(obj); 
        }
    }
}