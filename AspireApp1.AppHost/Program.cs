using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var bookingServicePostgres = builder.AddPostgres("postgres")
    .WithPgAdmin()
    .WithDataVolume()
    .AddDatabase("BookingServicePostgres");

builder.AddProject<BookingService_DatabaseMigration>("database-migration")
    .WithReference(bookingServicePostgres);

var bookingApiService = builder.AddProject<BookingService_API>("bookingapiservice")
        .WithReference(cache)
        .WithReference(bookingServicePostgres);

builder.AddProject<AspireApp1_Web>("webfrontend")
    .WithReference(cache)
    .WithReference(bookingApiService)
    .WithExternalHttpEndpoints();

builder.Build().Run();

