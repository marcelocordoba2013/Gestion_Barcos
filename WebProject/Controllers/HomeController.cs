using System.Diagnostics;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models;

namespace WebProject.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new CostoAlquilerViewModel());
    }

    [HttpPost]
    public IActionResult Index(CostoAlquilerViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var destinos = (model.Destinos ?? string.Empty)
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        if (destinos.Length == 0)
        {
            ModelState.AddModelError(nameof(model.Destinos), "Ingresá al menos un destino, separados por coma.");
            return View(model);
        }

        try
        {
            var barco = new Barco("Prueba", 10, 30, 100);
            barco.Destinos.AddRange(destinos);

            var contenedor = new Contenedor(model.Largo, 2, "azul");
            contenedor.Validar();

            Cliente cliente = model.TipoCliente switch
            {
                "Particular" => new ClienteParticular("099000000", "Contacto", model.FechaAlta, "Nombre", "Apellido", "12345678"),
                "Empresa" => new ClienteEmpresa("099000000", "Contacto", model.FechaAlta, "210000000019", "Empresa prueba"),
                _ => throw new ArgumentException("Elegí un cliente particular o una empresa.")
            };

            Barco.CostoBase = model.CostoBase;
            ClienteEmpresa.DescuentoAntiguedad = model.DescuentoAntiguedad;

            model.CantidadDestinos = barco.Destinos.Count;
            model.CostoSinAjuste = Barco.CostoBase * model.CantidadDestinos;
            model.Costo = contenedor.CostoAlquiler(barco, cliente, model.FechaAlquiler);
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
        }

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
