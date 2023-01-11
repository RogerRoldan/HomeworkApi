
using HomeworkApi;
using HomeworkApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//soluciona el problema de la fecha al agregar datos
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

//permite crear una base de datos en memoria
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("CnTareasDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//comprueba la conexion a la base de datos
app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos creada en memoria: " + dbContext.Database.IsInMemory());
});

//obtiene todas las tareas con la  informacion de la categoria [GET]
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{

    //return Results.Ok(dbContext.Tareas.Where(p => p.Prioridad == HomeworkApi.Models.Prioridad.Baja));
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
});

//permite ingresar una tarea  [POST]
app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea ) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.UtcNow;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok(tarea);
});

//permite actualizar una tarea [PUT]
app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null)
    {
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.Descripcion = tarea.Descripcion;
        tareaActual.Prioridad = tarea.Prioridad;
        tareaActual.CategoriaId = tarea.CategoriaId;
        await dbContext.SaveChangesAsync();
        return Results.Ok(tareaActual);
    }

    return Results.NotFound();
});

//permite listar las categorias [GET]
app.MapGet("/api/categorias", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Categorias);
});

//permite actualizar una categoria [PUT]
app.MapPut("/api/categorias/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Categoria categoria, [FromRoute] Guid id) =>
{
    var categoriaActual = dbContext.Categorias.Find(id);
    if (categoriaActual != null)
    {
        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion = categoria.Descripcion;
        categoriaActual.peso = categoria.peso;
        
        await dbContext.SaveChangesAsync();
        return Results.Ok(categoriaActual);
    }

    return Results.NotFound();
});

//permite elimnar una tarea [DELETE]
app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);
    if (tareaActual != null)
    {
        dbContext.Tareas.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok(tareaActual);
    }

    return Results.NotFound();
});

app.Run();
