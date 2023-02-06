using Ramal.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ramal.App.ViewModels
{
    public class EmailViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Setor")]
        public Guid SetorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Conta { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Senha { get; set; }

        public Setor Setor { get; set; }

        public IEnumerable<SetorViewModel> Setores { get; set; }
    }
}
