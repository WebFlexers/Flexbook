using System.Text;
using Flexbook.Data.DataAccess;
using Flexbook.Data.Models.Users;
using Flexbook.Data.Models.Products;
using Flexbook.Services;
using Flexbook.Services.Books;
using Flexbook.Services.Session;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Flexbook.Data.Models;
using Flexbook.Services.AuthorForum;
using Flexbook.Services.Users.User;
using Flexbook.Services.Order;
using Flexbook.Services.Statistics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<FlexbookDbContext>(opts =>
{
    opts.EnableDetailedErrors();
    opts.UseNpgsql(builder.Configuration.GetConnectionString("flexbook.dev"));
});

// Inject services
// Generic
// NonGeneric
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IBookReviewService, BookReviewService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IStatisticsService, StatisticsService>();
// Authentication
builder.Services.AddScoped<ILoginService, LoginService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(build => build
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
