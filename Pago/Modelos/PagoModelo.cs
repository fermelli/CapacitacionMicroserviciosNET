using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pago.Modelos;

[Table("pagos")]
public class PagoModelo
{
    public PagoModelo(int idFactura, decimal monto)
    {
        IdFactura = idFactura;
        Monto = monto;
        Fecha = DateTime.Now;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id_pago")]
    public int IdPago { get; set; }

    [Column("id_factura")]
    public int IdFactura { get; set; }

    [Column("monto")]
    public decimal Monto { get; set; }

    [Column("fecha")]
    public DateTime? Fecha { get; set; }
}
