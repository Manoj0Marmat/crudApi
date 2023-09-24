using API.Middleware;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProgramDetailRepository, ProgramDetailRepository>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
        .Where(e => e.Value!.Errors.Count > 0)
        .SelectMany(x => x.Value!.Errors)
        .Select(x => x.ErrorMessage).ToArray();

        var errorResponse = new ApiValidationErrorResponse
        {
            Errors = errors
        };
        return new BadRequestObjectResult(errorResponse);

    };
});
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
