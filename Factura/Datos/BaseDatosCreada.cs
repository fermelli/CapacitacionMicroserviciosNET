using Factura.Modelos;
using Factura.Persistencia;

namespace Factura.Datos;

public class BaseDatosCreada
{
    public static void Inicializar(BaseDatosContexto contexto)
    {
        contexto.Database.EnsureCreated();

        if (contexto.Factura.Any()) return;

        var facturas = new FacturaModelo[]
{
        new FacturaModelo{Monto=200, Estado=0},
        new FacturaModelo{Monto=300, Estado=0},
        new FacturaModelo{Monto=40, Estado=0},
        new FacturaModelo{Monto=50, Estado=0},
        new FacturaModelo{Monto=100, Estado=0},
        new FacturaModelo{Monto=400, Estado=0},
        new FacturaModelo{Monto=200, Estado=0},
        new FacturaModelo{Monto=1000, Estado=0},
        new FacturaModelo{Monto=99, Estado=0},
        new FacturaModelo{Monto=999, Estado=0},
        new FacturaModelo{Monto=666, Estado=0},
        new FacturaModelo{Monto=123, Estado=0},
        new FacturaModelo{Monto=5000, Estado=0},
        new FacturaModelo{Monto=1111, Estado=0},
};

        foreach (FacturaModelo factura in facturas)
        {
            contexto.Factura.Add(factura);
        }

        contexto.SaveChanges();
    }
}
