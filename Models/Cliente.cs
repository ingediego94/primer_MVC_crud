namespace inicio_Mvc_Csharp.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public int Edad { get; set; }
    
    
    //Relacion con el producto:
    public int ProductoId { get; set; }     // FK
    public Producto? Producto { get; set; }     // Prop. de nav. opcional
    
}