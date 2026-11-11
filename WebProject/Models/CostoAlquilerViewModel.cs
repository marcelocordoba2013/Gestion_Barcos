using System.ComponentModel.DataAnnotations;

namespace WebProject.Models;

public class CostoAlquilerViewModel
{
    [Display(Name = "Costo base")]
    [Range(0, double.MaxValue, ErrorMessage = "El costo base debe ser cero o mayor.")]
    public double CostoBase { get; set; } = 100;

    [Display(Name = "Destinos")]
    [Required(ErrorMessage = "Ingresá al menos un destino, separados por coma.")]
    public string Destinos { get; set; } = "Montevideo, Buenos Aires";

    [Display(Name = "Largo del contenedor (m)")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El largo debe ser mayor a cero.")]
    public double Largo { get; set; } = 9;

    [Display(Name = "Tipo de cliente")]
    [Required(ErrorMessage = "Elegí un tipo de cliente.")]
    public string TipoCliente { get; set; } = "Particular";

    [Display(Name = "Fecha de alta del cliente")]
    [DataType(DataType.Date)]
    public DateTime FechaAlta { get; set; } = DateTime.Today.AddYears(-6);

    [Display(Name = "Fecha del alquiler")]
    [DataType(DataType.Date)]
    public DateTime FechaAlquiler { get; set; } = DateTime.Today;

    [Display(Name = "Descuento de empresa")]
    [Range(0, double.MaxValue, ErrorMessage = "El descuento debe ser cero o mayor.")]
    public double DescuentoAntiguedad { get; set; } = 50;

    public double? Costo { get; set; }
    public double? CostoSinAjuste { get; set; }
    public int CantidadDestinos { get; set; }
}
