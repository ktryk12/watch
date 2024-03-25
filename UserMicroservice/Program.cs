using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using UserMicroservice.Dal;
using UserMicroservice.ModelLayer;
using UserMicroservice.SecurityServices;
using UserMicroservice.ServiceLayer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;

IdentityModelEventSource.ShowPII = true;
var builder = WebApplication.CreateBuilder(args);

// Tilføj DbContext til containeren
builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registrer DAL og service lag interfaces med deres implementeringer
builder.Services.AddScoped<IUserData, UserDataManager>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthService>(); // Tilføj AuthService
builder.Services.AddScoped<PasswordService>(); // Tilføj PasswordService
builder.Services.AddScoped<TokenService>(); // Tilføj TokenService

// Konfigurer JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };


        // Logging the token validation process
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                // This is triggered once the token has been validated
                builder.Configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Microsoft").Value = "Debug";
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Token validated for user {User}", context.Principal.Identity.Name);
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                // This is triggered if authentication fails
                builder.Configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Microsoft").Value = "Debug";
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogError("Authentication failed: {Exception}", context.Exception.ToString());
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                // This is triggered if the user challenges the authentication, e.g., no token provided
                if (!context.Response.HasStarted)
                {
                    builder.Configuration.GetSection("Logging").GetSection("LogLevel").GetSection("Microsoft").Value = "Debug";
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Program>>();
                    logger.LogWarning("OnChallenge error: {Error}", context.Error, context.ErrorDescription);
                    context.Response.StatusCode = 401;
                    context.HandleResponse(); // Suppress the default behavior
                }

                return Task.CompletedTask;
            }
        };
    });
;
// Tilføj CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:49167", "http://localhost:57225") // Erstat med den korrekte origin for din Flutter-app
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Tilføj controllers
builder.Services.AddControllers();

// Tilføj Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "User Microservice API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


var app = builder.Build();

// Konfigurer HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsPolicy");

app.UseAuthentication(); // Sørg for dette kaldes før UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
