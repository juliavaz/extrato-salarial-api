using ExtratoSalarial.Core.Domain.Interfaces.Repositories;
using ExtratoSalarial.Core.Domain.Interfaces.Requests;
using ExtratoSalarial.Core.Domain.UseCases;
using ExtratoSalarial.Core.Domain.UseCases.GetEmployee;
using ExtratoSalarial.Core.Domain.UseCases.GetEmployeeById;
using ExtratoSalarial.Core.Domain.UseCases.GetPaycheck;
using ExtratoSalarial.Core.Domain.UseCases.PostEmployee;
using ExtratoSalarial.Core.Infra;
using FluentValidation;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add mongoDb connection to dependency injection.
var connectionString = builder.Configuration.GetValue<string>("Databases:ConnectionString");
var databaseName = builder.Configuration.GetValue<string>("Databases:DatabaseName");
var mongoClient = new MongoClient(connectionString);
var mongoDatabase = mongoClient.GetDatabase(databaseName);
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(x => new EmployeeRepository(mongoDatabase));

// Add request handlers to dependency injection
builder.Services.AddScoped<IRequestHandler<PostEmployeeInput, ResponseUseCase>, PostEmployeeUseCase>();
builder.Services.AddScoped<IRequestHandler<GetEmployeeByIdInput, ResponseUseCase>, GetEmployeeByIdUseCase>();
builder.Services.AddScoped<IRequestHandler<GetEmployeeInput, ResponseUseCase>, GetEmployeeUseCase>();
builder.Services.AddScoped<IRequestHandler<GetPaycheckByIdInput, ResponseUseCase>, GetPaycheckByIdUseCase>();

// Add validators to dependency injection
builder.Services.AddScoped<IValidator<GetEmployeeByIdInput>, GetEmployeeByIdValidation>();
builder.Services.AddScoped<IValidator<GetPaycheckByIdInput>, GetPaycheckByIdValidation>();
builder.Services.AddScoped<IValidator<PostEmployeeInput>, PostEmployeeValidation>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Extrato Salarial API",
        Description = "An ASP.NET Core Web API for managing employee items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "by e-mail (juvaz.gomes@gmail.com)",
            Email = "juvaz.gomes@gmail.com"
        },
        License = new OpenApiLicense
        {
            //Name = "Example License",
            //Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
