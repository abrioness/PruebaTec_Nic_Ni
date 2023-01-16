using Microsoft.AspNetCore.Mvc;
using PruebaTec_Nic_Ni.Models;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTec_Nic_Ni.Controllers
{


   // [EnableCors("PoliticasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        public readonly LibroContext libroContext;
        public LibrosController(LibroContext contexto)
        {
            libroContext= contexto;
        }

        // GET: api/<LibrosController>
        [HttpGet]
        [Route("Datos")]
        public IActionResult GetDat()
        {
            List<Libros> datos = new List<Libros>();
            try
            {
                datos = libroContext.Libros.ToList();
                return StatusCode(StatusCodes.Status200OK ,new { mensaje = "Ok", response = datos });

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

            Libros datos = libroContext.Libros.Find(id);

            if (datos == null)
            {
                return BadRequest("Dato no encontrado");
            }


            try
            {
                datos = libroContext.Libros.Where(x=>x.Id == id).FirstOrDefault();
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
        public IActionResult Post([FromBody] Libros lib)
        {
            try
            {
                libroContext.Libros.Add(lib);
                libroContext.SaveChanges();
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
        public IActionResult Put(int id, [FromBody] Libros obj)
        {
            Libros book = libroContext.Libros.Find(obj.Id);

            if(book == null)
            {
                return BadRequest("No se encontro el dato especifico");
            }

            try
            {
                book.NomLib=obj.NomLib is null ? book.NomLib : obj.NomLib;
                book.Cantidad=obj.Cantidad is 0 ? book.Cantidad : obj.Cantidad;
                book.Precio= obj.Precio is 0 ? book.Precio : obj.Precio;
                

                libroContext.Libros.Update(book);
                libroContext.SaveChanges();
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
            Libros datos = libroContext.Libros.Find(id);

            if (datos == null)
            {
                return BadRequest("Dato no encontrado");
            }


            try
            {
                libroContext.Libros.Remove(datos);
                libroContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Dato Eliminado", response = datos });

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = datos });
            }
        }
    }
}
