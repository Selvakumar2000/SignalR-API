using SignalR_App_API.HubConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Added
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllHeaders", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

//Added
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;   
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

app.UseHttpsRedirection();

app.UseAuthorization();

//Added
app.UseCors("AllowAllHeaders");

app.MapControllers();

//Added
app.MapHub<MyHub>("/toastr");

app.Run();
