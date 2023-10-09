using Microsoft.EntityFrameworkCore;
using Pago.Modelos;

namespace Pago.Persistencia;

public class BaseDatosContexto: DbContext
{
    public BaseDatosContexto(DbContextOptions<BaseDatosContexto> opciones) : base(opciones)
    {
    }
    public DbSet<PagoModelo> Pago => Set<PagoModelo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PagoModelo>().ToTable("Pagos");
    }
}
