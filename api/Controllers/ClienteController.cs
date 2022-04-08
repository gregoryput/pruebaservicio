using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
         private readonly ClienteRopository Repository;
       public ClienteController()
       {
           Repository = new ClienteRopository();
       }
        [HttpGet]
        // [EnableCors("AnotherPolicy")]
        public IEnumerable<Cliente> Obtener()
        {
            return Repository.Get();
        }
        [HttpGet("{id}")]
        public Cliente Obtener(int id)
        {
            return Repository.GetporID(id);
        }
        [HttpPost]
        public void Enviar([FromBody]Cliente ser)
        {
            if(ModelState.IsValid)
            {
                Repository.add(ser);
            }
        }
        [HttpPut]
        public void Modificar(int id , [FromBody]Cliente cl )
        {
            cl.ClienteID = id;
            if(ModelState.IsValid)
            {
                Repository.Update(cl);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            Repository.Delete(id);
        }

    }
}