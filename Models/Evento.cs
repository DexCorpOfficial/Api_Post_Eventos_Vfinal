using System;

namespace Api_Post_Eventos_Vfinal.Models
{
    public class Evento
    {
        public int ID { get; set; }
        public DateTime fecha_ini { get; set; }
        public DateTime fecha_fin { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; } = true;

    }
}
