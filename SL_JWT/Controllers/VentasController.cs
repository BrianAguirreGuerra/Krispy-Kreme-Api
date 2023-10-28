using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_JWT.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        [Authorize]
        [HttpPost("Add")]
        public IActionResult Add(decimal Total)
        {
            try
            {
                ML.Result result = BL.Venta.Add(Total);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ML.Result
                {
                    Correct = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                ML.Result result = BL.Venta.GetAll();
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ML.Result
                {
                    Correct = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int idVenta)
        {
            try
            {
                ML.Result result = BL.Venta.GetById(idVenta);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ML.Result
                {
                    Correct = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
