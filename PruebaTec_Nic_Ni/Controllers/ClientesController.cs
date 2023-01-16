using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTec_Nic_Ni.Models;

namespace PruebaTec_Nic_Ni.Controllers
{


    // [EnableCors("PoliticasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        public readonly LibroContext data;
        public ClientesController(LibroContext datacte)
        {
            data = datacte;
        }

        [HttpGet]
        [Route("data")]
        public IActionResult GetDat()
        {
            List<Cliente> datos = new List<Cliente>();
            try
            {
                datos = data.Clientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = datos });

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = datos });
            }
        }

        // GET api/<LibrosController>/5
        [HttpGet]
        [Route("Obtener/Id")]
        public IActionResult Obtener(int id)
        {

            Cliente datos = data.Clientes.Find(id);

            if (datos == null)
            {
                return BadRequest("Dato no encontrado");
            }


            try
            {
                datos = data.Clientes.Where(x => x.Id == id).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", response = datos });

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = datos });
            }

        }

        //// POST api/<LibrosController>
        [HttpPost]
        [Route("Insertar")]
        public IActionResult Post([FromBody] Cliente cte)
        {
            try
            {
                data.Clientes.Add(cte);
                data.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se Guardo con exito" });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });
            }
        }

        // PUT api/<LibrosController>/5
        [HttpPut]
        [Route("Actualizar")]
        public IActionResult Put(int id, [FromBody] Cliente obj)
        {
            Cliente cliente = data.Clientes.Find(obj.Id);

            if (cliente == null)

            {
                return BadRequest("No se encontro el dato especifico");
            }

            try
            {
                cliente.Nombre = obj.Nombre is null ? cliente.Nombre : obj.Nombre;
                cliente.Apellidos = obj.Apellidos is null ? cliente.Apellidos : obj.Apellidos;
                cliente.Correo = obj.Correo is null ? cliente.Correo : obj.Correo;
                cliente.Contacto = obj.Contacto is null ? cliente.Contacto : obj.Contacto;


                data.Clientes.Update(cliente);
                data.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se actualizo correctamente" });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok" });
            }
        }

        // DELETE api/<LibrosController>/5
        [HttpDelete]
        [Route("Eliminar/Id")]
        public IActionResult Delete(int id)
        {
            Cliente datos = data.Clientes.Find(id);

            if (datos == null)
            {
                return BadRequest("Dato no encontrado");
            }


            try
            {
                data.Clientes.Remove(datos);
                data.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Dato Eliminado", response = datos });

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = datos });
            }
        }



    }



}
