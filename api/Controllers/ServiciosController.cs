using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly ServicioRepository servicioRepository;
        public ServiciosController()
        {
            servicioRepository = new ServicioRepository();

        }

        [HttpGet]
        // [EnableCors("AnotherPolicy")]
        public IEnumerable<Servicios> Obtener()
        {
            return servicioRepository.GetServicios();
        }
        [HttpGet("{id}")]
        public Servicios Obtener(int id)
        {
            return servicioRepository.GetporID(id);
        }
        [HttpPost]
        public void Enviar([FromBody]Servicios ser)
        {
            if(ModelState.IsValid)
            {
                servicioRepository.add(ser);
            }
        }
        [HttpPut]
        public void Modificar(int id , [FromBody]Servicios servicios )
        {
            servicios.ServicioID = id;
            if(ModelState.IsValid)
            {
                servicioRepository.Update(servicios);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            servicioRepository.Delete(id);
        }

    }
}