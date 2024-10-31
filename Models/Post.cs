using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Api_Post_Eventos_Vfinal.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string media { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha_pub { get; set; } = DateTime.Now;
        public bool activo { get; set; } = true;
        public virtual ICollection<Post_Feed> PostsDeFeed { get; set; } = new List<Post_Feed>();
        public virtual ICollection<Post_Banda> PostsDeBanda { get; set; } = new List<Post_Banda>();
        public virtual ICollection<Post_Evento> PostsDeEvento { get; set; } = new List<Post_Evento>();
        public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
