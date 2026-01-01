using WIMS.Application.Transactions.Commands.CreateTransaction;
using WIMS.Application.Transactions.Commands.DeleteTransaction;
using WIMS.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);

// Handlers DI
builder.Services.AddScoped<CreateTransactionHandler>();
builder.Services.AddScoped<DeleteTransactionHandler>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.MapControllers();
app.Run();