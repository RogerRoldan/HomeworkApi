using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkApi.Models
{
    public class Tarea
    {
        //[Key]
        public Guid TareaId { get; set; }

        //[ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }
        //[Required]
        //[MaxLength(200)]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        //espacio para la informacion de la categoria asignada solo es virtual mas no de base de datos
        public virtual Categoria Categoria { get; set; }

        //[NotMapped]
        public string Resumen { get; set; }
    }

    public enum Prioridad 
    {
        Baja = 1,
        Media = 2,
        Alta = 3
    }

}