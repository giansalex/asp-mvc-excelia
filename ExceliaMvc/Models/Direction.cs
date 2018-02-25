using System;
using System.ComponentModel.DataAnnotations;

namespace ExceliaMvc.Models
{
    public class Direction
    {
        [Key]
        public int DirectionId { get; set; }
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        [Required]
        [MaxLength(16)]
        [StringLength(16)]
        [Display(Name = "Usuario Creación")]
        public string UserCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        [MaxLength(16)]
        [StringLength(16)]
        [Display(Name = "Usuario Actualización")]
        public string UserUpdated { get; set; }
        public DateTime? Updated { get; set; }
    }
}