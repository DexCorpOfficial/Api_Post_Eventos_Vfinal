using System;
using System.ComponentModel.DataAnnotations;


namespace Api_Post_Eventos_Vfinal.Models
{
    public abstract class Post
    {
        [Key]
        public int ID { get; set; }
        public string media { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_pub { get; set; } = DateTime.Now;
        public bool activo { get; set; } = true;
    }
}
