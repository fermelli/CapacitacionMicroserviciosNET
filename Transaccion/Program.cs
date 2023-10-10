using Aforo255.Cross.Event.Src.Bus;
using Aforo255.Cross.Event.Src;
using Carter;
using MediatR;
using Transaccion.Persistencia;
using Transaccion.Persistencia.Configuraciones;
using Transaccion.Servicios;
using AFORO255.MS.TEST.Transactiones.EventHandlers;
using Factura.Mensajes.Eventos;

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

var app = builder.Build();

app.MapCarter();

ConfigureEventBus(app);

app.Run();

void ConfigureEventBus(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

    eventBus.Subscribe<PagoCreadoEvent, PagoCreadoEventHandler>();
}
