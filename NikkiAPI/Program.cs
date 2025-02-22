using Microsoft.Extensions.Options;
using NikkiApi.Models;
using NikkiApi.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MaterialsDatabaseSettings>(
    builder.Configuration.GetSection(nameof(MaterialsDatabaseSettings)));

builder.Services.Configure<MaterialSourcesDatabaseSettings>(
    builder.Configuration.GetSection(nameof(MaterialSourcesDatabaseSettings)));

builder.Services.Configure<SketchesDatabaseSettings>(
    builder.Configuration.GetSection(nameof(SketchesDatabaseSettings)));

builder.Services.AddSingleton<IMaterialsDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MaterialsDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMaterialSourcesDatabaseSettings>(sp => sp.GetRequiredService<IOptions<MaterialSourcesDatabaseSettings>>().Value);
builder.Services.AddSingleton<ISketchesDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SketchesDatabaseSettings>>().Value);

builder.Services.AddSingleton<MaterialsService>();
builder.Services.AddSingleton<MaterialSourcesService>();
builder.Services.AddSingleton<SketchesService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
