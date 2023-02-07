using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramal.Business.Models
{
    public class Setor : Entity
    {


        public string Nome { get; set; }

        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public IEnumerable<Email> Emails{ get; set; }

        public IEnumerable<Computador> Computadores{ get; set; }



    }
}
