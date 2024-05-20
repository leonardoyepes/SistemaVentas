using SistemaVentas.IOC;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InyectarDependencias(builder.Configuration);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Politicas", app =>
    {
        app.AllowAnyMethod()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Politicas");
app.UseAuthorization();

app.MapControllers();

app.Run();
