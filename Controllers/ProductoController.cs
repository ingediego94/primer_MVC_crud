using inicio_Mvc_Csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace inicio_Mvc_Csharp.Controllers;

public class ProductoController : Controller
{

    // Creo una lista de productos (quemada):
    public static List<Producto> _productos = new List<Producto>
    {
        new Producto { ID = 1, Nombre = "Televisor", Precio = 5020232, Descripcion = "Es muy bueno" },
        new Producto { ID = 2, Nombre = "Pc gamer", Precio = 67564343, Descripcion = "Regular" },
        new Producto { ID = 3, Nombre = "Eq. sonido", Precio = 2000, Descripcion = "No tan cool" }
    };
    
    
    //Para simular un ID auto_incrementable:
    private int contador = _productos.Count();
    
    
    // Traigo la lista:
    public IActionResult Index()
    {
        return View(_productos);
    }


    // Para mostrar los detalles de los productos:
    public IActionResult Details(int id)
    {
        var produc = _productos;

        var pro = produc.FirstOrDefault(produc => produc.ID == id);
        if (pro == null) 
            return NotFound();
        return View(pro);
    }
    
    
    
    // CREATE:
    public IActionResult Store(Producto producto)
    {
        contador++;
        producto.ID = contador;
        _productos.Add(producto);
        return RedirectToAction("Index");
    }


    // DELETE:
    public IActionResult Deleting(int id_prod)
    {
        var pro = _productos.FirstOrDefault(produc => produc.ID == id_prod);
        if (pro != null)
        {
            _productos.Remove(pro);
        }
        
        return RedirectToAction("Index");
    }
    

    // EDITAR:  
    // GET: Producto/Edit/1
    public IActionResult Edit(int id)
    {
        var producto = _productos.FirstOrDefault(p => p.ID == id);
        if (producto == null)
        {
            return NotFound();
        }
        return View(producto);
    }

    [HttpPost]
    public IActionResult EditPost(Producto producto)
    {
        var existingProduct = _productos.FirstOrDefault(p => p.ID == producto.ID);
        if (existingProduct == null)
        {
            return NotFound();
        }

        // Actualizar propiedades
        existingProduct.Nombre = producto.Nombre;
        existingProduct.Descripcion = producto.Descripcion;
        existingProduct.Precio = producto.Precio;

        return RedirectToAction("Index");
    }

}

