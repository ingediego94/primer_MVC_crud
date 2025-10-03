using inicio_Mvc_Csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace inicio_Mvc_Csharp.Controllers;

public class ClienteController : Controller
{
    // Lista para almacenar a todos los clientes:
    private static List<Cliente> _clientes = new List<Cliente>
    {
        new Cliente{Id = 1, Nombre = "Karl", Cedula = "1085310888", Edad = 26, ProductoId = 1},
        new Cliente{Id = 2, Nombre = "Susana", Cedula = "663609213", Edad = 19, ProductoId = 3},
        new Cliente {Id = 3, Nombre = "María", Cedula = "1063352947", Edad = 30, ProductoId = 2}
    };
    
    // Para simular un ID auto_incrementable:
    private int contador = _clientes.Count();
    
    // Index con la lista de productos:

    
    
    // Traigo la lista:
    public IActionResult Index()
    {
        ViewBag.Productos = ProductoController._productos;
        return View(_clientes);
    }
    
    // Para mostrar los detalles de los productos:
    public IActionResult Detalles(int id)
    {
        var clientes_x = _clientes;

        var cli = clientes_x.FirstOrDefault(clientes_x => clientes_x.Id == id);
        if (cli == null)
            return NotFound();
        return View(cli);
    }
    
    
    
    // CREATE:
    public IActionResult Store(Cliente cliente)
    {
        contador++;
        cliente.Id = contador;
        
        cliente.Producto = ProductoController._productos.FirstOrDefault(p => p.ID == cliente.ProductoId);

        
        _clientes.Add(cliente);
        return RedirectToAction("Index");
    }


    // DELETE:
    public IActionResult DeleteCliente(int id_cliente)
    {
        var pro = _clientes.FirstOrDefault(produc => produc.Id == id_cliente);
        if (pro != null)
        {
            _clientes.Remove(pro);
        }
        
        return RedirectToAction("Index");
    }
    

    // EDITAR:  
    // GET: Cliente/Edit/1
    public IActionResult EditCliente(int id)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }

    [HttpPost]
    public IActionResult EditPost(Cliente cliente)
    {
        var existingCliente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
        if (existingCliente == null)
        {
            return NotFound();
        }

        // Actualizar propiedades
        existingCliente.Nombre = cliente.Nombre;
        existingCliente.Cedula = cliente.Cedula;
        existingCliente.Edad = cliente.Edad;

        return RedirectToAction("Index");
    }
    
    
    
}