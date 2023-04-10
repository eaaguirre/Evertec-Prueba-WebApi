using Evertec.Prueba.WebApi.EventErrorLog;
using Evertec.Prueba.WebApi.Extensions.Authentication;
using Evertec.Prueba.WebApi.Extensions.Injection;
using Evertec.Prueba.WebApi.Extensions.Swagger;
using Evertec.Prueba.WebApi.Extensions.Versioning;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthenticationToken();
builder.Services.AddSwagger();
builder.Services.AddVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {

        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prueba Evertec  V1");
    });
}
app.UseAuthentication();
app.ConfigureExceptiionHandler();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
