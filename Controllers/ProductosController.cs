using Microsoft.AspNetCore.Mvc;
using BellaVista.Web.Data;
using BellaVista.Web.Models;
using System.Linq;
using BellaVista.Web.DTOs;
using BellaVista.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace BellaVista.Web.Controllers
{
public class ProductosController : Controller
{
    private readonly ProductoDAL _productoDAL;

    public ProductosController(IConfiguration configuration)
    {
        _productoDAL = new ProductoDAL(configuration);
    }

    public IActionResult Index()
    {
	        var vm = BuildIndexVM(new ProductoCreateDTO());
	        return View(vm);
    }

	    // GET: Productos/Create (opcional). El formulario está en Index.
	    public IActionResult Create() => RedirectToAction(nameof(Index));

    // POST: Productos/Create
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(ProductosIndexVM vm)
{
    if (!ModelState.IsValid)
        return View(nameof(Index), BuildIndexVM(vm.Nuevo));

    var dto = vm.Nuevo;

    var producto = new Producto
    {
        NombreProducto = dto.NombreProducto ?? string.Empty,
        CategoriaID = dto.CategoriaID,
        Presentacion = dto.Presentacion ?? string.Empty,
        PrecioUnitario = dto.PrecioUnitario,
        Activo = true
    };

    _productoDAL.Insertar(producto);

    return RedirectToAction(nameof(Index));
}


	private ProductosIndexVM BuildIndexVM(ProductoCreateDTO dto)
	{
	    // IDs asumidos: 1=Arábica, 2=Robusta, 3=Mezcla (ajústalo si tu tabla Categoria usa otros IDs)
	    var tiposCafe = new List<SelectListItem>
	    {
	        new("Seleccionar tipo de café", "0"),
	        new("Arábica", "1"),
	        new("Robusta", "2"),
	        new("Mezcla", "3"),
	    };

	    var presentaciones = new List<SelectListItem>
	    {
	        new("Seleccionar presentación", ""),
	        new("Bolsa 250g", "Bolsa 250g"),
	        new("Bolsa 500g", "Bolsa 500g"),
	        new("Bolsa 1kg", "Bolsa 1kg"),
	        new("Frasco 100g", "Frasco 100g"),
	    };

	    return new ProductosIndexVM
	    {
	        Productos = _productoDAL.Listar(),
	        Nuevo = dto,
	        TiposCafe = tiposCafe,
	        Presentaciones = presentaciones
	    };
	}

    // GET: Productos/Edit/5
    public IActionResult Edit(int id)
    {
        var producto = _productoDAL.Listar().FirstOrDefault(p => p.ProductoID == id);
        if (producto == null) return NotFound();
	        LoadSelectLists(producto.CategoriaID, producto.Presentacion);
        return View(producto);
    }

    // POST: Productos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Producto producto)
    {
        if (ModelState.IsValid)
        {
            _productoDAL.Actualizar(producto);
            return RedirectToAction(nameof(Index));
        }
	        LoadSelectLists(producto.CategoriaID, producto.Presentacion);
        return View(producto);
    }

	    private void LoadSelectLists(int categoriaIdSeleccionada, string? presentacionSeleccionada)
	    {
	        ViewBag.TiposCafe = new List<SelectListItem>
	        {
	            new("Arábica", "1", categoriaIdSeleccionada == 1),
	            new("Robusta", "2", categoriaIdSeleccionada == 2),
	            new("Mezcla", "3", categoriaIdSeleccionada == 3),
	        };

	        var pres = presentacionSeleccionada ?? string.Empty;
	        ViewBag.Presentaciones = new List<SelectListItem>
	        {
	            new("Bolsa 250g", "Bolsa 250g", pres == "Bolsa 250g"),
	            new("Bolsa 500g", "Bolsa 500g", pres == "Bolsa 500g"),
	            new("Bolsa 1kg", "Bolsa 1kg", pres == "Bolsa 1kg"),
	            new("Frasco 100g", "Frasco 100g", pres == "Frasco 100g"),
	        };
	    }

    // GET: Productos/Delete/5
    public IActionResult Delete(int id)
    {
        var producto = _productoDAL.Listar().FirstOrDefault(p => p.ProductoID == id);
        if (producto == null) return NotFound();
        return View(producto);
    }

    // POST: Productos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _productoDAL.Eliminar(id);
        return RedirectToAction(nameof(Index));
    }
}
}