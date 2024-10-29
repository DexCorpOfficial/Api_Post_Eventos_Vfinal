using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Post_Eventos_Vfinal.Models
{
    public class Post_Evento : Post
    {
        public int IDdeCuenta { get; set; }
        public int IDdeEvento { get; set; }
        public Evento Evento { get; set; }
        public Post post { get; set; }
    }
}
