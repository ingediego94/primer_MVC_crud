namespace inicio_Mvc_Csharp.Models;

public class Producto
{
    public int ID { get; set; }
    public string Nombre { get; set; } = string.Empty;  // si ni hay datos, estará vacio.
    public string Descripcion { get; set; } = string.Empty;
    public double Precio { get; set; } 
}