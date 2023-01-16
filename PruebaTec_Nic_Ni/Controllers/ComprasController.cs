using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTec_Nic_Ni.Models;

namespace PruebaTec_Nic_Ni.Controllers
{

    // [EnableCors("PoliticasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        public readonly LibroContext compras;
        public ComprasController(LibroContext bd)
        {
            compras = bd;
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult GetDat()
        {
            List<Compra> datos = new List<Compra>();
            try
            {
                datos = compras.Compras.ToList();
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

            Compra datos = compras.Compras.Find(id);

            if (datos == null)
            {
                return BadRequest("Dato no encontrado");
            }


            try
            {
                datos = compras.Compras.Where(x => x.Id == id).FirstOrDefault();
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
        public IActionResult Post([FromBody] Compra cpra)
        {
            try
            {
                compras.Compras.Add(cpra);
                compras.SaveChanges();
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
        public IActionResult Put(int id, [FromBody] Compra obj)
        {
            Compra c = compras.Compras.Find(obj.Id);

            if (c == null)

            {
                return BadRequest("No se encontro el dato especifico");
            }

            try
            {
                c.NomCte = obj.NomCte is null ? c.NomCte : obj.NomCte;
                c.NomLib = obj.NomLib is null ? c.NomLib : obj.NomLib;
                c.Cantidad = obj.Cantidad is 0 ? c.Cantidad : obj.Cantidad;
                c.Precio = obj.Precio is 0 ? c.Precio : obj.Precio;


                compras.Compras.Update(c);
                compras.SaveChanges();
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
            Compra datos = compras.Compras.Find(id);

            if (datos == null)
            {
                return BadRequest("Dato no encontrado");
            }


            try
            {
                compras.Compras.Remove(datos);
                compras.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Dato Eliminado", response = datos });

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = e.Message, response = datos });
            }
        }





    }
}
