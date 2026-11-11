using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers;

public class ContenedorController : Controller
{
    Sistema sistema = Sistema.GetInstancia;

    [HttpGet]
    public IActionResult Barcos(int? id)
    {
        ViewData["Title"] = "Barcos por contenedor";

        if (id == null)
        {
            return View();
        }

        ViewBag.Id = id.Value;
        ViewBag.Barcos = sistema.ObtenerBarcosPorContenedor(id.Value);
        return View();
    }

    [HttpGet]
    public IActionResult Alta()
    {
        ViewBag.Titulo = "Alta de contenedor";
        CargarListado();
        return View();
    }

    [HttpPost]
    public IActionResult Alta(Contenedor contenedor)
    {
        CargarListado();
        AjustarMensajesDeBinding();

        if (!ModelState.IsValid)
        {
            return View(contenedor);
        }

        try
        {
            sistema.AgregarContenedor(contenedor);
            ViewBag.MensajeAlta = $"Se agregó el contenedor {contenedor.Id}.";
            return RedirectToAction(nameof(Alta));
        }
        catch (ArgumentException ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(contenedor);
        }
    }

    private void CargarListado()
    {
        ViewBag.Contenedores = sistema.Contenedores;
    }

    private void AjustarMensajesDeBinding()
    {
        AjustarMensaje(nameof(Contenedor.Largo), "El largo debe ser un valor positivo.");
        AjustarMensaje(nameof(Contenedor.Ancho), "El ancho debe ser un valor positivo.");
        AjustarMensaje(nameof(Contenedor.Color), "El color es un campo obligatorio.");
    }

    private void AjustarMensaje(string clave, string mensaje)
    {
        if (!ModelState.TryGetValue(clave, out var entrada) || entrada.Errors.Count == 0)
        {
            return;
        }

        entrada.Errors.Clear();
        entrada.Errors.Add(mensaje);
    }
}
