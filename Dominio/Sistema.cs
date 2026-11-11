namespace Dominio;

public class Sistema
{
    private static Sistema? _instancia = null;

    private List<Barco> _barcos = new List<Barco>();
    private List<Contenedor> _contenedores = new List<Contenedor>();
    private List<Cliente> _clientes = new List<Cliente>();
    private List<Transporte> _transportes = new List<Transporte>();

    public static Sistema GetInstancia
    {
        get
        {
            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }
    }
    public List<Barco> Barcos
    {
        get { return _barcos; }
    }

    public List<Contenedor> Contenedores
    {
        get { return _contenedores; }
    }

    public List<Cliente> Clientes
    {
        get { return _clientes; }
    }

    public List<Transporte> Transportes
    {
        get { return _transportes; }
    }

    private Sistema()
    {

    }

}
