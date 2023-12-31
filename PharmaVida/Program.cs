﻿
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PharmaVida.Data;
using PharmaVida.Model;
using PharmaVida.Service;
using PharmaVida.Service.Implements;
using PharmaVida.Validator;

namespace PharmaVida;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        
        //Conexão com o banco de dados
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        //Registrar validação das entidades
        builder.Services.AddTransient<IValidator<Produto>, ProdutoValidator>();
        builder.Services.AddTransient<IValidator<Categoria>, CategoriaValidator>();
        
        //Registrar as classes de serviço
        builder.Services.AddScoped<IProdutoService, ProdutoService>();
        builder.Services.AddScoped<ICategoriaService, CategoriaService>();
        
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        //Configuração do CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "MyPolicy",
                policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
        });

        var app = builder.Build();
        
        //Criar o banco de dados e as tabelas
        using (var scope = app.Services.CreateAsyncScope())
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

        app.UseCors("MyPolicy");
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

