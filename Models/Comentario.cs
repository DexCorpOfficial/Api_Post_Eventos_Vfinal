using System;


namespace Api_Post_Eventos_Vfinal.Models
{
    public class Comentario
    {
        public int ID { get; set; }
        public int IDdePost { get; set; }
        public string contenido { get; set; }
        public DateTime fecha { get; set; } = DateTime.Now;
        public bool activo { get; set; } = true;
        public Post post { get; set; }
    }
}
