using Factura.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Factura.Persistencia;

public class BaseDatosContexto : DbContext
{
    public BaseDatosContexto(DbContextOptions<BaseDatosContexto> opciones) : base(opciones)
    {
    }

    public DbSet<FacturaModelo> Factura => Set<FacturaModelo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacturaModelo>().ToTable("Facturas");
    }
}
