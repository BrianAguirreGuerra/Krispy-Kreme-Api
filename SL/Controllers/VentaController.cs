using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        
        public IActionResult Add()
        {
            BL.Venta.Add();
            if (true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult GetAll()
        {
            BL.Venta.GetAll();
            if (true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        public IActionResult GetById(int idVenta)
        {
            BL.Venta.GetById(idVenta);
            if (true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
