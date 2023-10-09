using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factura.Modelos;

[Table("facturas")]
public class FacturaModelo
{
    public FacturaModelo() { }

    public FacturaModelo(decimal? monto, int? estado)
    {
        Monto = monto;
        Estado = estado;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_factura")]
    public int IdFactura { get; set; }

    [Column("monto")]
    public decimal? Monto { get; set; }

    [Column("estado")]
    public int? Estado { get; set; }
}
