namespace Dominio;

public class Barco : IComparable<Barco>
{
    private static int _ultimoId = 1;

    public int Id { get; private set; }
    public string Nombre { get; set; }
    public double Ancho { get; set; }
    public double Largo { get; set; }
    public int CapacidadCarga { get; set; }
    public List<string> Destinos { get; set; }
    public static double CostoBase { get; set; } = 100;

    public Barco(string nombre, double ancho, double largo, int capacidadCarga)
    {
        Id = _ultimoId++;
        Nombre = nombre;
        Ancho = ancho;
        Largo = largo;
        CapacidadCarga = capacidadCarga;
        Destinos = new List<string>();
    }   

    public int CompareTo(Barco? other)
    {
        if (other == null) return 1;
        return Id.CompareTo(other.Id);
    }
}
