namespace BellaVista.Web.Models
{
public class Producto
{
    public int ProductoID { get; set; }
    public string NombreProducto { get; set; }
    public int CategoriaID { get; set; }
    public string Presentacion { get; set; }
    public decimal PrecioUnitario { get; set; }
    public bool Activo { get; set; } = true;

    // Propiedad de navegación
   public Categoria? Categoria { get; set; }
}
}



