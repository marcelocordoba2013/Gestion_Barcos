namespace Dominio;

public class ClienteParticular : Cliente
{
    private string Nombre;
    private string Apellido;
    private string Documento;

    public ClienteParticular(string telefono, string nombreContacto, DateTime fechaAltaRegistro, string nombre, string apellido, string documento) : base(telefono, nombreContacto, fechaAltaRegistro)
    {
        Nombre = nombre;
        Apellido = apellido;
        Documento = documento;
    }

    public override double AjustarCostoAlquiler(double costo, Contenedor contenedor, DateTime fecha)
    {
        if (contenedor.Largo > 8)
        {
            return costo * 1.10;
        }

        return costo;
    }
}
