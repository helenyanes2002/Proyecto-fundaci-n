using Fundacion.API.Data;
using Fundacion.API.Helpers;
using Fundacion.Shared.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();





builder.Services.AddIdentity<User, IdentityRole>(x =>
{
    
    x.SignIn.RequireConfirmedEmail = true;
    x.User.RequireUniqueEmail = true;
    x.Password.RequireDigit = false;
    x.Password.RequiredUniqueChars = 0;
    x.Password.RequireLowercase = false;
    x.Password.RequireNonAlphanumeric = false;

})


.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<IUserHelper, UserHelper>();
builder.Services.AddTransient < SeedDb > ();

builder.Services.AddSwaggerGen();
 builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=DefaultConnection"));


var app = builder.Build();

SeedData(app);

static void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();

        var dbContext = scope.ServiceProvider.GetService<DataContext>();
        dbContext.Database.Migrate();
        service.SeedAsync().Wait();
    }


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.UseCors(x => x

    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)
    );
    app.Run();
}
