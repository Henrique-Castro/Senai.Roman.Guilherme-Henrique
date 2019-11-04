using Senai.Roman.Guilherme_Henrique.Domains;
using Senai.Roman.Guilherme_Henrique.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.Guilherme_Henrique.Interfaces
{
    public interface IProfessoresRepository
    {
        Professores BuscarPorNomeESenha(LoginViewModel dadosLogin);
    }
}
