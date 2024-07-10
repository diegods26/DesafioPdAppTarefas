using System.ComponentModel.DataAnnotations;

namespace DesafioPdAppTarefas.Api.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Senha diferente encontrada")]
        public string ConfirmPassword { get; set; }
    }
}
