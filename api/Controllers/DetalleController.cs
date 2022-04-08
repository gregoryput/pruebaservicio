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
    public class DetalleController : ControllerBase
    {
        private readonly DetalleRepository detalleRepository;

        public DetalleController()
        {
            detalleRepository = new DetalleRepository();
        }


        [HttpGet]
        public IEnumerable<FacturaDetalle> Obtener()
        {
            return detalleRepository.GetFacturas();
        }

        [HttpGet("{id}")]
        public FacturaDetalle Obtener(int id)
        {
            return detalleRepository.GetporID(id);
        }
        [HttpPost]
        public void Enviar([FromBody] FacturaDetalle fac)
        {
            if (ModelState.IsValid)
            {
                detalleRepository.add(fac);
            }
        }
        [HttpPut]
        public void Modificar(int id, [FromBody] FacturaDetalle fac)
        {
            fac.FacturaID = id;
            if (ModelState.IsValid)
            {
                detalleRepository.Update(fac);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            detalleRepository.Delete(id);
        }

    }
}