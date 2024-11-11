using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Segundo_parcial_2.Models
{
    public class ElectricityConsumption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Apartment")]
        public int ApartmentId { get; set; }  

        public Apartment Apartment { get; set; }

        [Required]
        public DateTime Fecha { get; set; }  

        [Required]
        [Range(0, double.MaxValue)]
        public double CantidadKw { get; set; }  
    }
}
