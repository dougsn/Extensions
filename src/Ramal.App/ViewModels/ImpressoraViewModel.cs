using Ramal.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ramal.App.ViewModels
{
    public class ImpressoraViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Setor")]
        public Guid SetorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Modelo { get; set; }

        
        [DisplayName("IP")]
        public string Ip { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
        public string Tonner { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public IEnumerable<SetorViewModel> Setores { get; set; }
        public Setor Setor { get; set; }
    }
}
