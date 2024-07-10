using System.ComponentModel.DataAnnotations;

namespace DesafioPdAppTarefas.Api.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; } = string.Empty;        

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [StringLength(20, ErrorMessage = "A {0} deve conter de {2} até no maximo " +
            "{1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = string.Empty;
    }
}
