using System.ComponentModel.DataAnnotations;

namespace PP_C.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string? Descripcion { get; set; }
        public double Precio { get; set; }

    }
}
