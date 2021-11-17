using FacturacionBackend.Servicios;
using FacturacionBackend.Servicios.Servicios;
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
    public class LoginController : ControllerBase
    {
        private IService servicio;

        public LoginController()
        {
            servicio = new ServiceFactoryImp().CrearCarreraService();
        }
        //POST api/<CarreraController>
        [HttpPost("login")]
        public IActionResult Login(List<Parametro> lst)
        {
            if (Convert.ToString(lst[0].Valor) == "" || Convert.ToString(lst[1].Valor) == "")
                return Unauthorized("Se requiere permisos!");

            return Ok(servicio.Login(Convert.ToString(lst[0].Valor), Convert.ToString(lst[1].Valor)));
        }
    }
}
