using ItentikaTest.ProcessorApi;
using ItentikaTest.Context;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddAppDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

services.AddControllers();

services.AddEndpointsApiExplorer();

services.AddSwaggerGen();

services.RegisterServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
