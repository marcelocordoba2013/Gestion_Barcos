namespace Dominio;
public class Transporte
{
    public Barco Barco { get; set; }
    public Contenedor Contenedor { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime Fecha { get; set; }

    public double Costo { get; private set; }

    public Transporte(Barco barco,Contenedor contenedor,Cliente cliente,DateTime fecha)
    {
        Barco = barco;
        Contenedor = contenedor;
        Cliente = cliente;
        Fecha = fecha;

        Costo = CalcularCosto();
    }

    private double CalcularCosto()
    {
        return Contenedor.CostoAlquiler(Barco, Cliente, Fecha);
    }
}