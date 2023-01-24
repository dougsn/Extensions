using Ramal.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Ramal.App.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public Setor Setor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(4, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Ramal { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Email { get; set; }
        public List<Funcionario> Favoritos { get; set; }
    }
}
