using Microsoft.AspNetCore.Mvc;
using BellaVista.Web.Data;
using BellaVista.Web.Models;
using BellaVista.Web.DTOs;


namespace BellaVista.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosApiController : ControllerBase
    {
        private readonly ProductoDAL _productoDAL;

        public ProductosApiController(IConfiguration configuration)
        {
            _productoDAL = new ProductoDAL(configuration);
        }

        // GET: api/ProductosApi
        [HttpGet]
        public IActionResult Get()
        {
            var productos = _productoDAL.Listar();
            return Ok(productos);
        }

        // POST: api/ProductosApi

[HttpPost]
public IActionResult Post([FromBody] ProductoCreateDTO dto)
{
    if (!ModelState.IsValid)
        return ValidationProblem(ModelState);

    var producto = new Producto
    {
        NombreProducto = dto.NombreProducto,
        CategoriaID = dto.CategoriaID,
        Presentacion = dto.Presentacion,
        PrecioUnitario = dto.PrecioUnitario,
        Activo = dto.Activo
    };

    _productoDAL.Insertar(producto);
    return Ok(new { message = "Producto insertado correctamente" });
}


        // PUT: api/ProductosApi/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto producto)
        {
            if (producto == null || producto.ProductoID != id) return BadRequest();

            _productoDAL.Actualizar(producto);
            return Ok(new { message = "Producto actualizado correctamente" });
        }

        // DELETE: api/ProductosApi/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productoDAL.Eliminar(id);
            return Ok(new { message = "Producto eliminado correctamente" });
        }
    }
}