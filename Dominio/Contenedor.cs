namespace Dominio;

public class Contenedor
{
    private static int _ultimoId = 1;
    private string _color = string.Empty;

    public int Id { get; private set; }
    public double Largo { get; set; }
    public double Ancho { get; set; }
    public string Color
    {
        get { return _color; }
        set { _color = value?.Trim() ?? string.Empty; }
    }

    public Contenedor()
    {
    }

    public Contenedor(double largo, double ancho, string color)
    {
        Id = _ultimoId++;
        Largo = largo;
        Ancho = ancho;
        Color = color;
    }

    public void Validar()
    {
        ValidarMedidas();
        ValidarColor();
    }

    private void ValidarMedidas()
    {
        if (Largo <= 0)
        {
            throw new ArgumentException("El largo debe ser un valor positivo.");
        }
        if (Ancho <= 0)
        {
            throw new ArgumentException("El ancho debe ser un valor positivo.");
        }
    }

    private void ValidarColor()
    {
        if (string.IsNullOrWhiteSpace(Color))
        {
            throw new ArgumentException("El color es un campo obligatorio.");
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is Contenedor otro && Id == otro.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
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
