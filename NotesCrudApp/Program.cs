using Microsoft.EntityFrameworkCore;
using NotesCrudApp.Data;
using NotesCrudApp.IRepository;
using NotesCrudApp.IService;
using NotesCrudApp.Repository;
using NotesCrudApp.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen(); // Swagger
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Repo and service register
builder.Services.AddScoped<NotesIRepository, NotesRepository>();
builder.Services.AddScoped<NotesIService, NotesService>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll",
    policy => policy
    //.WithOrigins("http://localhost:4200")
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
    });

var app = builder.Build();

// Optional: auto-apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
