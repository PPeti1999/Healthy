using Healthy.Server.Data;
using Healthy.Server.Models;
using Healthy.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
// be able inject JWTSERVICES class inside COntroller
builder.Services.AddScoped<JWTservice>();

//defining our IdentityCore Service
builder.Services.AddIdentityCore<User>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.SignIn.RequireConfirmedEmail = true;
}).AddRoles<IdentityRole>()//abble to add roles
   .AddRoleManager<RoleManager<IdentityRole>>()//abel to make use RoleManager
   .AddEntityFrameworkStores<Context>()//providing  context
   .AddSignInManager<SignInManager<User>>()// make use of signin manager
   .AddUserManager<UserManager<User>>()// usermanager create users
   .AddDefaultTokenProviders();// able to create tokens for email confirm 

// able to auth users using JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // validate the token based on the key we have provided inside appsettings.development.json JWT:Key
            ValidateIssuerSigningKey = true,
            // the issuer singning key based on JWT:Key
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            // the issuer which in here is the api project url we are using
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            // validate the issuer (who ever is issuing the JWT)
            ValidateIssuer = true,
            // don't validate audience (angular side)
            ValidateAudience = false,
            // ValidateLifetime = true,
            // ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddCors();// ez j�                   EZT �TGONDOLNI
builder.Services.Configure<ApiBehaviorOptions>(options =>// error kuldes ui ra
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(x => x.Value.Errors.Count > 0)
        .SelectMany(x => x.Value.Errors)
        .Select(x => x.ErrorMessage).ToArray();

        var toReturn = new
        {
            Errors = errors
        };

        return new BadRequestObjectResult(toReturn);
    };
});
var app = builder.Build();

app.UseDefaultFiles();// ez j�                   EZT �TGONDOLNI
app.MapStaticAssets(); // ez j�                   EZT �TGONDOLNI

// Configure the HTTP request pipeline.
app.UseCors(opt => // ez j�                   EZT �TGONDOLNI
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(builder.Configuration["JWT:CLientUrl"]);
});

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Adding useAuthentication into our pipline and this should coe before UseAuthorization
//Authentication verifies the odentity of user or servicen and authorization determines their acces rights
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.MapFallbackToFile("/index.html");

app.Run();
