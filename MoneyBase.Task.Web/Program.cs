
using Mapster;
using MassTransit;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using MoneyBase.Domain.RepositoryInterfaces;
using MoneyBase.Persistence.Consumers;
using MoneyBase.Persistence.Database;
using MoneyBase.Persistence.Repositories;
using MoneyBase.Services;
using MoneyBase.Services.Abstractions;
using MoneyBase.Shared;
using System;
using System.Runtime;

namespace MoneyBase.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            TypeAdapterConfig.GlobalSettings.Compile();
            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Chat Queue System API",
                    Version = "v1",
                });
            });


            var cfg = builder.Configuration;
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<StartSessionConsumer>();
                x.AddRequestClient<StartSessionCommand>(); // important
                x.UsingRabbitMq((context, mq) =>
                {
                    mq.Host(cfg["Rabbit:Host"] ?? "localhost", "/", h =>
                    {
                        h.Username(cfg["Rabbit:User"] ?? "guest");
                        h.Password(cfg["Rabbit:Pass"] ?? "guest");
                    });


                    mq.Message<StartSessionCommand>(m => m.SetEntityName("chat-session-queue")); // queue name
                    mq.ReceiveEndpoint("chat-session-queue", e =>
                    {
                        e.PrefetchCount = 16;
                        e.ConfigureConsumer<StartSessionConsumer>(context);
                    });
                });
            });

            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            builder.Services.AddDbContext<RepositoryDbContext>(options =>
    options.UseSqlServer(cfg.GetConnectionString("Database")));


            var app = builder.Build();

            await ApplyMigrations(app.Services);


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDefaultFiles();   // serves index.html by default
            app.UseStaticFiles();    // allows serving static files from wwwroot
            app.MapControllers();

            app.Run();
        }

        private static async Task ApplyMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            await using RepositoryDbContext dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
