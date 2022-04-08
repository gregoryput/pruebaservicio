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
    public class Facturacontroller : ControllerBase
    {
        private readonly FacturaRepository facturaDRepository;

        public Facturacontroller()
        {
            facturaDRepository = new FacturaRepository();
        }

        [HttpGet]
        // [EnableCors("AnotherPolicy")]
        public IEnumerable<Factura> Obtener()
        {
            return facturaDRepository.GetFacturas();
        }
        [HttpGet("{id}")]

        public Factura Obtener(int id)
        {
            return facturaDRepository.GetporID(id);
        }
        [HttpPost]
        public void Enviar([FromBody] Factura fac)
        {
            if (ModelState.IsValid)
            {
                facturaDRepository.add(fac);
            }
        }
        [HttpPut]
        public void Modificar(int id, [FromBody] Factura fac)
        {
            fac.FacturaID = id;
            if (ModelState.IsValid)
            {
                facturaDRepository.Update(fac);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            facturaDRepository.Delete(id);
        }

    }

}