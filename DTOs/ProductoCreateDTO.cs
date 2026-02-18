using System.ComponentModel.DataAnnotations;

namespace BellaVista.Web.DTOs
{
    public class ProductoCreateDTO
    {
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        public string? NombreProducto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo de café.")]
        public int CategoriaID { get; set; }

        [Required(ErrorMessage = "Seleccione una presentación.")]
        public string? Presentacion { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Ingrese un precio válido.")]
        public decimal PrecioUnitario { get; set; }

        public bool Activo { get; set; } = true;
    }
}
