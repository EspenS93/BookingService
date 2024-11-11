using BookingService.DatabaseMigration;
using BookingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContext<BookingServiceDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("BookingServicePostgres"))
);

builder.Services.AddOpenTelemetry()
		.WithTracing(tracing => tracing.AddSource(Worker.ActivityName));


var host = builder.Build();
host.Run();
