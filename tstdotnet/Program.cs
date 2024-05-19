using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Swagger Documentation Section
var info = new OpenApiInfo()
{
    Title = "Your API Documentation",
    Version = "v1",
    Description = "Description of your API",
    //contact link on top
    TermsOfService = new Uri("http://tempuri.org/terms"),
    Contact = new OpenApiContact()
    {
        Name = "Your name",
        Email = "your@email.com",
    },
    License = new OpenApiLicense
    {
        Name = "Apache 2.0",
        Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
    }

};

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", info);

    // Set the comments path for the Swagger JSON and UI. 
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    // <response code="201">
    c.IncludeXmlComments(xmlPath);
    // [SwaggerResponse(401, "returns a new id of the bla bla")]
    c.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(u =>
        {
            u.RouteTemplate = "swagger/{documentName}/swagger.json";
        });

    app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = "swagger";
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Your API Title or Version");
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
