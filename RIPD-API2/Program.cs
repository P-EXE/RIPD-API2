using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using RIPD_API2.Data;
using RIPD_API2.Models;
using RIPD_API2.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
  });
  options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<SQLDataBaseContext>(options =>
  options.UseSqlServer(
    builder.Configuration.GetConnectionString("RIPDDB2-SQLConnection")
  )
);

builder.Services.AddDbContext<MongoDataBaseContext>(options =>
  options.UseMongoDB(
    builder.Configuration.GetConnectionString("RIPDDB2-MongoConnection"), "RIPDB2"
  )
);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
  .AddEntityFrameworkStores<SQLDataBaseContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.MapGroup("/api/user").MapIdentityApi<User>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
