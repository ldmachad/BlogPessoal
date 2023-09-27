using blogpessoal.Data;
using blogpessoal.Validator;
using blogpessoal.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using blogpessoal.Service;
using blogpessoal.Service.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

//Conexão com o Banco de Dados

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext> (options =>
    options.UseSqlServer(connectionString)
);

// Registrar a Validação das Entidades
builder.Services.AddTransient<IValidator<Postagem>, PostagemValidator>();
builder.Services.AddTransient<IValidator<Tema>, TemaValidator>();

// Registrar as Classes de Serviço (Service)
builder.Services.AddScoped<IPostagemService, PostagemService>();
builder.Services.AddScoped<ITemaService, TemaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();

// Criar o Banco de Dados e as Tabelas

using(var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Inicializa o CORS
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
