using System.ComponentModel.DataAnnotations;

namespace Segundo_parcial_2.Models
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }  

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }  

        [Required]
        [Phone]
        public string Telefono { get; set; }  
    }
}
