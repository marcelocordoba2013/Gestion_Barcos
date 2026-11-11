namespace Dominio;

public class ClienteEmpresa : Cliente
{

    private string RUT { get; set; }
    private string RazonSocial { get; set;}
    public static double DescuentoAntiguedad { get; set; } = 50;

    public ClienteEmpresa(string telefono, string nombreContacto, DateTime fechaAltaRegistro, string rut, string razonSocial) : base(telefono, nombreContacto, fechaAltaRegistro)
    {
        RUT = rut;
        RazonSocial = razonSocial;
    }

    public override double AjustarCostoAlquiler(double costo, Contenedor contenedor, DateTime fecha)
    {
        if (fecha > FechaAltaRegistro.AddYears(5))
        {
            return costo - DescuentoAntiguedad;
        }

        return costo;
    }
}
