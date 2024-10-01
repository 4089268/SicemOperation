using System.ComponentModel.DataAnnotations;

namespace SicemOperation.Models;

public class LoginRequest
{
    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.EmailAddress)]
    public string? User { get; set; }

    [Required(ErrorMessage = "El campo es requerido")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
