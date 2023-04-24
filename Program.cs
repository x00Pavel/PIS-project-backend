using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using video_pujcovna_back.Configs;
using video_pujcovna_back.Facades;
using video_pujcovna_back.Factories;
using video_pujcovna_back.Models;
using video_pujcovna_back.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DbContextFactory>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ReservationRepository>();
builder.Services.AddScoped<VideotapeRepository>();
builder.Services.AddScoped<ActorRepository>();
builder.Services.AddScoped<GenreRepository>();
builder.Services.AddScoped<PaymentRepository>();
builder.Services.AddScoped<StockRepository>();
builder.Services.AddScoped<RoleRepository>();

builder.Services.AddScoped<UserFacade>();
builder.Services.AddScoped<ReservationFacade>();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddSingleton(new JwtConfig
{
    Secret = builder.Configuration.GetSection("JwtConfig:Secret").Value
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwt =>
{
    var key = Encoding.ASCII.GetBytes(
        builder.Configuration.GetSection("JwtConfig:Secret").Value);
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        ValidateLifetime = true
    };
});

builder.Services
    .AddDefaultIdentity<UserModel>(
        options => options.SignIn.RequireConfirmedAccount = false )
    .AddRoles<RoleModel>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();