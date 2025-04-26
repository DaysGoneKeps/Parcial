using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
    [Table("t_asociacion")]
    public class Asociacion
    {
        [Key]	
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      


        public int Id { get; set; }
        [ForeignKey("Equipo")]
        public int EquipoId { get; set; }
        public Equipo Equipo  { get; set; } = null!;

        [ForeignKey("Jugador")]
        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; } = null!;
    }
}