using System.ComponentModel.DataAnnotations;

namespace CineBucket.Core.Requests;

public class LoginRequest
{
    [Required(ErrorMessage = "Username é obrigatório")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Senha é obrigatória")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Display(Name = "Lembre-se de mim")]
    public bool RememberMe { get; set; } = false;
}