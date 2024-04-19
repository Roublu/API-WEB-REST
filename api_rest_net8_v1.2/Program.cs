using Dws.Note_one.Api.Persistence.Contexts;
using Dws.Note_one.Api.Persistence.Repositories;
using Dws.Note_one.Api.Domain.Repositories;
using Dws.Note_one.Api.Domain.Repositories.IRepositories;
using Dws.Note_one.Api.Domain.Services;
using Dws.Note_one.Api.Domain.Services.IServices;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext> (options => {options.UseInMemoryDatabase("groceries-api-in-memory");});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository> ();
builder.Services.AddScoped<ICategoryService, CategoryService> ();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();




var app = builder.Build();

var scope = app.Services.CreateScope();
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();