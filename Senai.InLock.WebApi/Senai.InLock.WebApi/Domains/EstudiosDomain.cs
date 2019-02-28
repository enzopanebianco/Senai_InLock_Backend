using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    public class EstudiosDomain
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="O ESTÚDIO DEVERÁ CONTER NOME")]
        public string Nome { get; set; }
    }
}
