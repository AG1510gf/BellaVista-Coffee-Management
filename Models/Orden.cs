namespace BellaVista.Web.Models
{
public class Orden
{
    public int OrdenID { get; set; }
    public int ClienteID { get; set; }
    public DateTime FechaOrden { get; set; }
    public bool EsActiva { get; set; }

    // Propiedad de navegación
    public Cliente Cliente { get; set; }
}

}
