
using Ramal.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ramal.App.ViewModels
{
    public class SetorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }


        public IEnumerable<FuncionarioViewModel> Funcionarios { get; set; }
    }
}
