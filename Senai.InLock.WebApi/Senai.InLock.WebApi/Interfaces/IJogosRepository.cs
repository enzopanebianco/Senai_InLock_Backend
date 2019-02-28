using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interfaces
{
    public interface IJogosRepository
    {
        List<JogosDomain> Listar();
        void Cadastrar(JogosDomain jogos);
    }
}
