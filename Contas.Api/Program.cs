using Contas.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddContasDb();
builder.Services.AddContasDbRepositories();
builder.Services.AddContasServices();

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("https://localhost:5173/", "http://localhost:5173/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(origin => true);
});

app.UseMigration();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();