using System.ComponentModel.DataAnnotations;

namespace Lanches.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name="Usuário")]
        public string UserName { get; set; }
        [Required]
        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}