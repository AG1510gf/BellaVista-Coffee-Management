using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BellaVista.Web.DTOs;

namespace BellaVista.Web.Models.ViewModels
{
    public class ProductosIndexVM
    {
        public List<Producto> Productos { get; set; } = new();
        public ProductoCreateDTO Nuevo { get; set; } = new();

        public List<SelectListItem> TiposCafe { get; set; } = new();
        public List<SelectListItem> Presentaciones { get; set; } = new();
    }
}
