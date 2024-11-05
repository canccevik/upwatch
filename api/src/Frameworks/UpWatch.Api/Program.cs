using AutoWrapper;
using UpWatch.Api;
using UpWatch.Data.AutoWrapper;
using UpWatch.IoC;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.RegisterModule<ApiModule>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiResponseAndExceptionWrapper<WrapperMap>(new AutoWrapperOptions
{
    UseCustomSchema = true
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
