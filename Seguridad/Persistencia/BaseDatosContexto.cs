using Microsoft.EntityFrameworkCore;
using Seguridad.Modelos;

namespace Seguridad.Persistencia;

public class BaseDatosContexto : DbContext
{
    public BaseDatosContexto(DbContextOptions<BaseDatosContexto> opciones) : base(opciones)
    {

    }

    public DbSet<UsuarioModelo> Usuario => Set<UsuarioModelo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioModelo>().ToTable("Usuarios");
    }
}
