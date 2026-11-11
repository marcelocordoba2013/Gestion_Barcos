namespace Dominio;

public abstract class Cliente
{
    // Atributos comunes: Id autogenerado, Telefono y NombreContacto.
    private static int _ultimoId = 1;
    public int Id { get; private set; }
    public string Telefono { get; set; }
    public string NombreContacto { get; set; }  

    public DateTime FechaAltaRegistro { get; private set; } = DateTime.Now;

    public Cliente(string telefono, string nombreContacto, DateTime fechaAltaRegistro)
    {
        Id = _ultimoId++;
        Telefono = telefono;
        NombreContacto = nombreContacto;
        FechaAltaRegistro = fechaAltaRegistro;
    }

    public abstract double AjustarCostoAlquiler(double costo, Contenedor contenedor, DateTime fecha);
}
