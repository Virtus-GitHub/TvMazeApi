using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using TvMazeApi.Interfaces;
using TvMazeApi.Repository;
using TvMazeApi.Services;
using TvMazeApi.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUpdateFilesService, UpdateFilesService>();
builder.Services.AddScoped<IGetShowService, GetShowService>();
builder.Services.AddScoped<IGetEpisodeService, GetEpisodeService>();
builder.Services.AddScoped<IGetSeasonService, GetSeasonService>();
builder.Services.AddScoped<IGetCastingService, GetCastingService>();
builder.Services.AddScoped<IGetCrewService, GetCrewService>();
builder.Services.AddScoped<IGetAkaService, GetAkaService>();
builder.Services.AddScoped<IGetImagesService, GetImagesService>();

builder.Services.AddScoped<IGetShowRepository, GetShowRepository>();
builder.Services.AddScoped<IGetSeasonRepository, GetSeasonRepository>();
builder.Services.AddScoped<IGetImageRepository, GetImageRepository>();
builder.Services.AddScoped<IGetEpisodesRepository, GetEpisodesRepository>();
builder.Services.AddScoped<IGetCrewRepository, GetCrewRepository>();
builder.Services.AddScoped<IGetCastingRepository, GetCastingRepository>();
builder.Services.AddScoped<IGetAkaRepository, GetAkaRepository>(); 

builder.Services.AddScoped<IApiKeyValidation, ApiKeyValidation>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiKeyPolicy", policy =>
    {
        policy.AddAuthenticationSchemes(new[] { JwtBearerDefaults.AuthenticationScheme });
        policy.Requirements.Add(new ApiKeyRequirement());
    });
});

builder.Services.AddScoped<IAuthorizationHandler, ApiKeyHandler>();

builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
