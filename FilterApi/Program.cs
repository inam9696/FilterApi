using FilterApi.Filters;
using FilterApi.Filters.FilterTask.Service;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IActionResponseTimeStopwatch, ActionResponseTimeStopwatch>();
builder.Services.AddScoped<ControllerFilter>();
builder.Services.AddScoped<ActionFilter>();
builder.Services.AddScoped<MethodFilter>();
builder.Services.AddScoped<ResponseHeader>();

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new ResponseTimeFilter());
});
builder.Services.AddControllers();
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
app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { details = "An error occurred" };
    await context.Response.WriteAsJsonAsync(response);
}));

//app.Use(async (context, next) =>
//{

//    context.Response.OnStarting(() =>
//    {
//        context.Response.Headers.Add("X-Developed-By", "Your Name");
//        return Task.FromResult(0);
//    });

//    await next();
//}
// );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
