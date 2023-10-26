using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Event.Src;
using Carter;
using MediatR;
using Transaccion.Persistencia;
using Transaccion.Persistencia.Configuraciones;
using Transaccion.Servicios;
using AFORO255.MS.TEST.Transactiones.EventHandlers;
using Factura.Mensajes.Eventos;
using Aforo255.Cross.Discovery.Consul;
using Aforo255.Cross.Discovery.Fabio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.Configure<BaseDatosMongoConfiguraciones>(opt =>
{
    opt.Conexion = builder.Configuration.GetSection("mongo:cn").Value;
    opt.NombreBaseDatos = builder.Configuration.GetSection("mongo:database").Value;
});
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<IBaseDatosMongoContexto, BaseDatosMongoContexto>();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRabbitMQ();
builder.Services.AddTransient<PagoCreadoEventHandler>();
builder.Services.AddTransient<IEventHandler<PagoCreadoEvent>, PagoCreadoEventHandler>();
builder.Services.AddControllers();
builder.Services.AddConsul();
builder.Services.AddFabio();

var app = builder.Build();

app.MapCarter();
app.UseAuthorization();
app.MapControllers();
app.UseConsul();

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

    eventBus.Subscribe<PagoCreadoEvent, PagoCreadoEventHandler>();
}
