namespace Dominio;

public class Contenedor
{
    private static int _ultimoId = 1;
    public int Id { get; }
    public double Largo { get; }
    public double Ancho { get; }
    public string Color { get; }

    public Contenedor(double largo, double ancho, string color)
    {
        Id = _ultimoId++;
        Largo = largo;
        Ancho = ancho;
        Color = color;
    }

    public void Validar()
    {
        if (Largo <= 0 || Ancho <= 0)
        {
            throw new ArgumentException("El largo y el ancho deben ser valores positivos.");
        }
        if (string.IsNullOrEmpty(Color))
        {
            throw new ArgumentException("El color es un campo obligatorio.");
        }
    }

    // Para calcular el costo del alquiler del contenedor se toma en cuenta lo siguiente:
    // • El costo base de cada contenedor multiplicado por la cantidad de destino a los cuales puede viajar el
    // barco.
    // • Si el contenedor fue alquilado por un cliente particular y el largo del contenedor supera los 8 metros, al
    // costo anterior se agrega un recargo del 10%.
    // • Si el contenedor fue alquilado por un cliente de tipo empresa y la fecha de antigüedad de la empresa
    // en el sistema es mayor a 5 años, al costo calculado en el punto a se le resta un descuento el cual es el
    // mismo para todos los clientes de tipo empresa. 

    public double CostoAlquiler(Barco barco, Cliente cliente, DateTime fecha)
    {
        if (barco == null)
        {
            throw new ArgumentException("El barco es obligatorio para calcular el costo de alquiler.");
        }
        if (cliente == null)
        {
            throw new ArgumentException("El cliente es obligatorio para calcular el costo de alquiler.");
        }
        if (barco.Destinos == null)
        {
            throw new ArgumentException("El barco no tiene destinos definidos.");
        }

        double costo = Barco.CostoBase * barco.Destinos.Count;
        return cliente.AjustarCostoAlquiler(costo, this, fecha);
    }
}
