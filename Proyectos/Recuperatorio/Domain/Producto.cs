using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

    }
}
