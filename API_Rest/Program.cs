using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API ������� ���������",
        Description = "������� ���������� ������� � ������������� �����������"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "API ������� ���������",
        Description = "������� ���������� ������� � ������������� �����������"
    });
    c.SwaggerDoc("v3", new OpenApiInfo
    {
        Version = "v3",
        Title = "API ������� ���������",
        Description = "������� ���������� ������� � ������������� �����������"
    });
    c.SwaggerDoc("v4", new OpenApiInfo
    {
        Version = "v4",
        Title = "API ������� ���������",
        Description = "������� ���������� ������� � ������������� �����������"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "������� GET");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "������� POST");
        c.SwaggerEndpoint("/swagger/v3/swagger.json", "������� PUT");
        c.SwaggerEndpoint("/swagger/v4/swagger.json", "������� DELETE");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.Run();