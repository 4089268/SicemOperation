using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SicemOperation.Entities
{
    
    [Table("Usuarios", Schema = "System")]
    public class Usuario
    {
     
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Nombre { get; set; }

        [DataType(DataType.EmailAddress)]
        public required string Correo { get; set; }

        public string Password { get; set; } = null!;
        public bool? Inactivo { get; set; }

    }
}