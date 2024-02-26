using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TimeRecordingMicroservice.Dal;
using TimeRecordingMicroservice.Modellayer;
using TimeRecordingMicroservice.Serviceslag;

var builder = WebApplication.CreateBuilder(args);

// Tilføj DbContext til containeren
builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TimeRegistrationServiceConnection")));

// Registrer DAL og service lag interfaces med deres implementeringer
builder.Services.AddScoped<ITimeRegistrationData, TimeRegistrationDataManager>();
builder.Services.AddScoped<ITimeService, TimeService>();

// Tilføj JWT Bearer Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero // Fjerner standard tidsforskydning for token udløb
        };
    });

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

// Tilføj Swagger/OpenAPI support med JWT Bearer Authorization
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeRecording Microservice API", Version = "v1" });

    // Tilføj en sikkerhedsdefinition og -krav for at understøtte Bearer-token i Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
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

app.UseAuthentication(); // Sørg for at tilføje denne linje for at aktivere JWT Bearer Authentication
app.UseAuthorization();

app.MapControllers();

app.Run();
