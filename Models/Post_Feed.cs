using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Post_Eventos_Vfinal.Models
{
    public class Post_Feed
    {
        public int IDdePost { get; set; }
        public int IDdeCuenta { get; set; }
        public Post post { get; set; }

    }
}
