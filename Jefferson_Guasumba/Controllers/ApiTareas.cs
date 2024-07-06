using Jefferson_Guasumba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Jefferson_Guasumba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTareas : ControllerBase
    {
      
      
            // GET: api/<ValuesController>
            [HttpGet]
            [Route("ListarTareas")]
            public async Task<IActionResult> Get()
            {


                var m = new Metodos();

                try
                {
                    var res = await m.ListarTareas();


                    return StatusCode(StatusCodes.Status200OK, new { datos = res });
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);

                    throw;
                }




            }



            [HttpPost]
            [Route("RegistrarTarea")]

            public async Task<IActionResult> Post2([FromForm] Tarea tarea)
            {


                var met = new Metodos();

                var res = await met.RegistrarTarea(tarea);


                if (res) { return StatusCode(StatusCodes.Status200OK); } else { return StatusCode(StatusCodes.Status400BadRequest); }



            }



            [HttpPost]
            [Route("ModificarTarea")]

            public async Task<IActionResult> Post3([FromForm] Tarea tarea)
            {


                var met = new Metodos();

                var res = await met.ModificarTarea(tarea);


                if (res) { return StatusCode(StatusCodes.Status200OK); } else { return StatusCode(StatusCodes.Status400BadRequest); }



            }



            [HttpGet]
            [Route("Eliminar/{idTarea}")]

            public async Task<IActionResult> Post3(int idTarea)
            {


                var met = new Metodos();

                var res = await met.EliminarTarea(idTarea);


                if (res) { return StatusCode(StatusCodes.Status200OK); } else { return StatusCode(StatusCodes.Status400BadRequest); }



            }


            [HttpGet]
            [Route("Login/{usuario}/{password}")]

            public async Task<IActionResult> Get2(string usuario, string password)
            {


                var met = new Metodos();

                try
                {

                    var res = await met.LoginUsuario(usuario, password);

                    return StatusCode(StatusCodes.Status200OK, new { valor = res });
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                    throw;
                }





            }





        }



    
}
