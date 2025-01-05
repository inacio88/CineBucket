using System.ComponentModel.DataAnnotations;

namespace CineBucket.Core.Requests;

public class RegisterRequest
{
    [Display(Name = "Nome")]
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Email é obrigatório")]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required(ErrorMessage = "Senha é obrigatória")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    [Display(Name = "Confirmar Senha")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Senhas não estão iguais")]
    public string? ConfirmPassword { get; set; }
    [Display(Name = "Endereço")]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; }
}