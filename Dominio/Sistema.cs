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
        Precargar();
    }

    private void Precargar()
    {
        Barco rio = new Barco("Río de la Plata", 20, 80, 200);
        rio.Destinos.Add("Montevideo");
        rio.Destinos.Add("Buenos Aires");

        Barco atlantico = new Barco("Atlántico", 30, 150, 500);
        atlantico.Destinos.Add("Montevideo");
        atlantico.Destinos.Add("Santos");
        atlantico.Destinos.Add("Rotterdam");

        Barco parana = new Barco("Paraná", 15, 60, 120);
        parana.Destinos.Add("Montevideo");

        _barcos.Add(rio);
        _barcos.Add(atlantico);
        _barcos.Add(parana);

        Contenedor azul = new Contenedor(9, 2.4, "azul");
        Contenedor rojo = new Contenedor(6, 2.4, "rojo");
        Contenedor verde = new Contenedor(12, 2.5, "verde");
        AgregarContenedor(azul);
        AgregarContenedor(rojo);
        AgregarContenedor(verde);

        ClienteParticular juan = new ClienteParticular("099111111", "Juan Pérez", DateTime.Today.AddYears(-1), "Juan", "Pérez", "12345678");
        ClienteEmpresa acme = new ClienteEmpresa("099222222", "Ana Gómez", DateTime.Today.AddYears(-6), "210000000019", "Acme S.A.");
        ClienteParticular maria = new ClienteParticular("099333333", "María López", DateTime.Today.AddMonths(-2), "María", "López", "87654321");

        _clientes.Add(juan);
        _clientes.Add(acme);
        _clientes.Add(maria);

        _transportes.Add(new Transporte(atlantico, azul, juan, DateTime.Today.AddDays(-10)));
        _transportes.Add(new Transporte(rio, azul, acme, DateTime.Today.AddDays(-3)));
        _transportes.Add(new Transporte(atlantico, azul, maria, DateTime.Today));
        _transportes.Add(new Transporte(parana, rojo, juan, DateTime.Today.AddDays(-1)));
        _transportes.Add(new Transporte(rio, verde, acme, DateTime.Today.AddMonths(-1)));
    }

    public List<Transporte> ObtenerTransportesContenedor(int id)
    {
        List<Transporte> resultado = new List<Transporte>();

        foreach (Transporte t in _transportes)
        {
            if (t.Contenedor.Id == id)
            {
                resultado.Add(t);
            }
        }

        return resultado;
    }

    public double ObtenerImporteTotalBarco(int id)
    {
        double total = 0;

        foreach (Transporte t in _transportes)
        {
            if (t.Barco.Id == id)
            {
                total += t.Costo;
            }
        }

        return total;
    }

    public List<Barco> ObtenerBarcosPorContenedor(int id)
    {
        List<Barco> resultado = new List<Barco>();

        foreach (Transporte t in _transportes)
        {
            if (t.Contenedor.Id == id && !ContieneBarco(resultado, t.Barco))
            {
                resultado.Add(t.Barco);
            }
        }

        resultado.Sort(OrdenarPorCapacidadDescendente);
        return resultado;
    }

    private bool ContieneBarco(List<Barco> barcos, Barco barco)
    {
        foreach (Barco actual in barcos)
        {
            if (actual.Id == barco.Id)
            {
                return true;
            }
        }

        return false;
    }

    private static int OrdenarPorCapacidadDescendente(Barco a, Barco b)
    {
        return b.CapacidadCarga.CompareTo(a.CapacidadCarga);
    }

    public void AgregarContenedor(Contenedor contenedor)
    {
        if (contenedor == null)
        {
            throw new ArgumentException("El contenedor es obligatorio.");
        }

        contenedor.Validar();

        if (_contenedores.Contains(contenedor))
        {
            throw new ArgumentException("El contenedor ya existe en el sistema.");
        }

        _contenedores.Add(contenedor);
    }

}
