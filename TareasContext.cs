using Microsoft.EntityFrameworkCore;
using HomeworkApi.Models;


namespace HomeworkApi;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){    }

    protected override void  OnModelCreating(ModelBuilder modelBuilder)
    {
        //configuracion para datos semilla
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("199bd2f7-4732-4493-a8eb-40bd19c303d3"), Nombre = "Actividades Pendientes", peso = 20 });
        categoriasInit.Add(new Categoria { CategoriaId = Guid.Parse("199bd2f7-4732-4493-a8eb-40bd19c30302"), Nombre = "Actividades Personales", peso = 50 });
        
        //Propiedades de la tabla categorias en la base de datos
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("199bd2f7-4732-4493-a8eb-40bd19c30304"), CategoriaId = Guid.Parse("199bd2f7-4732-4493-a8eb-40bd19c303d3"), Prioridad = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.UtcNow, Estado = "Pendiente" });
        tareasInit.Add(new Tarea { TareaId = Guid.Parse("199bd2f7-4732-4493-a8eb-40bd19c30305"), CategoriaId = Guid.Parse("199bd2f7-4732-4493-a8eb-40bd19c30302"), Prioridad = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion = DateTime.UtcNow, Estado = "Pendiente" });

        //Propiedades de la tabla tareas en la base de datos
        modelBuilder.Entity<Tarea>(tarea =>
        {
            //Nombre de la tabla
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);

            //Llave foranea
            tarea.HasOne(p => p.Categoria)
                .WithMany(p => p.Tareas)
                .HasForeignKey(p => p.CategoriaId);

            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.Prioridad);
            tarea.Property(p => p.FechaCreacion);
            tarea.Property(p => p.Estado);
            tarea.Ignore(p => p.Resumen);

            tarea.HasData(tareasInit);

        });
    }
}