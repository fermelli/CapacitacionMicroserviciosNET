using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Event.Src;
using Factura.Datos;
using Factura.Mensajes.Eventos;
using Factura.Persistencia;
using Factura.Servicios;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Factura.Mensajes.ManejadoresEventos;
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAppConfiguration((host, builder) =>
{
    IConfigurationRoot config = builder.Build();
    builder.AddNacosConfiguration(config.GetSection("nacosConfig"));
});
builder.Services.AddControllers();
builder.Services.AddDbContext<BaseDatosContexto>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration["cn:postgres"]);
    }
);
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<PagoCreadoEventHandler>();
builder.Services.AddTransient<IEventHandler<PagoCreadoEvent>, PagoCreadoEventHandler>();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.UseConsul();

BaseDatosInicializada.CrearBaseDatosSinoExiste(app);

ConfigurarEventBus(app);

app.Run();

void ConfigurarEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

    eventBus.Subscribe<PagoCreadoEvent, PagoCreadoEventHandler>();
}