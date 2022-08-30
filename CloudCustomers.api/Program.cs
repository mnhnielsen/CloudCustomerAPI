using CloudCustomers.api.Config;
using CloudCustomers.api.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

ConfigureServices(builder.Services);



var app = builder.Build();
{
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
}



void ConfigureServices(IServiceCollection services)
{
    services.Configure<UsersApiOptions>(builder.Configuration.GetSection("UsersApiOptions"));
    services.AddTransient<IUserService, UserService>();
    services.AddHttpClient<IUserService, UserService>();
}
