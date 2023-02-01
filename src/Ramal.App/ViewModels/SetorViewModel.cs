
using Ramal.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ramal.App.ViewModels
{
    public class SetorViewModel
    {
        [Key]
        public Guid Id { get; set; }

       
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Nome { get; set; }


        public IEnumerable<FuncionarioViewModel> Funcionarios { get; set; }
    }
}
