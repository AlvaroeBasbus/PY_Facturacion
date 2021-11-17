using FacturacionBackend.Servicios;
using FacturacionBackend.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoService servicio;

        public ProductoController()
        {
            servicio = new ServiceFactoryImp().CrearProductoService();
        }
        [HttpGet("consultar")]
        public IActionResult GetProductos()
        {
            return Ok(servicio.ConsultarProducto());
        }
    }
}
