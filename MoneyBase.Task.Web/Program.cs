
using MassTransit;
using MoneyBase.Shared;
using System.Runtime;

namespace MoneyBase.Task.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.Configure<MoneyBaseSettings>(builder.Configuration.GetSection("MoneyBaseSettings"));

            var cfg = builder.Configuration;
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<StartSessionConsumer>();
                x.UsingRabbitMq((context, mq) =>
                {
                    mq.Host(cfg["Rabbit:Host"] ?? "localhost", "/", h =>
                    {
                        h.Username(cfg["Rabbit:User"] ?? "guest");
                        h.Password(cfg["Rabbit:Pass"] ?? "guest");
                    });


                    mq.Message<StartSession>(m => m.SetEntityName("chat-session-queue")); // queue name
                    mq.ReceiveEndpoint("chat-session-queue", e =>
                    {
                        e.PrefetchCount = 16;
                        e.ConfigureConsumer<StartSessionConsumer>(context);
                    });


                    // enable delayed scheduling for requeue when no capacity
                    mq.UseMessageScheduler(new Uri("queue:quartz"));
                    mq.ReceiveEndpoint("quartz", e => { });
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
