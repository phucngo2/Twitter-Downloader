using X.API.Middlewares;
using X.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            var origins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
            policy.WithOrigins(origins!)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
