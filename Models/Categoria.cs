namespace BellaVista.Web.Models
{
public class Categoria
{
    public int CategoriaID { get; set; }
    public string NombreCategoria { get; set; }

    // Relación uno a muchos
    public ICollection<Producto> Productos { get; set; }
}
}
