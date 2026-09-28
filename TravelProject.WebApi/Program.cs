using Microsoft.EntityFrameworkCore;
using TravelProject.Business.Abstract;
using TravelProject.Business.Concrete;
using TravelProject.DataAccess.Abstract;
using TravelProject.DataAccess.Concrete;
using TravelProject.DataAccess.Context;
using TravelProject.WebApi.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Controller servisleri
builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Dependency Injection
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IAboutUsService, AboutUsManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IHomePageService, HomePageManager>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(GeneralMapping));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Development ortamýnda Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();