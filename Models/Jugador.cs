using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial.Models
{
     [Table("t_jugador")]
    public class Jugador
    {
       [Key]	
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public long Id { get; set;} 
       public string? Nombre { get; set;} 
       public string? Edad { get; set;} 
       public string? Posicion { get; set;} 
      

       public ICollection<Asociacion> Asociaciones { get; set; } = new List<Asociacion>();
        
    }
}