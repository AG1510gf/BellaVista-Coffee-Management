namespace BellaVista.Web.Models
{
public class Cliente
{
    public int ClienteID { get; set; }
    public string NombreCliente { get; set; }

    public ICollection<Orden> Ordenes { get; set; }
}
}
