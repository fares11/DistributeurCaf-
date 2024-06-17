using DistributeurCafé.Config;
using DistributeurCafé.Interface;
using DistributeurCafé.Services;

var builder = WebApplication.CreateBuilder(args);

// Déterminer le chemin absolu vers le fichier drinks.json
var drinksJsonPath = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "drinks.json");

// Charger les données des boissons depuis le fichier JSON
builder.Configuration.AddJsonFile(drinksJsonPath, optional: false, reloadOnChange: true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSingleton<IDistribService, DistribService>();
builder.Services.Configure<DataConfig>(builder.Configuration);


builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5232);
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
