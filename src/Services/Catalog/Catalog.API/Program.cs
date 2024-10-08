

var builder = WebApplication.CreateBuilder(args);

// add services to the container

// carter proporcionas una forma estructurada de definir nuestras rutas 
builder.Services.AddCarter();

// añadimos mediator y registra los servicios desde el metodo de ensdamblado
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddMarten(opts => 
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);    
}).UseLightweightSessions();

var app = builder.Build();

//configure the http request pipeline

app.MapCarter();

app.Run();
