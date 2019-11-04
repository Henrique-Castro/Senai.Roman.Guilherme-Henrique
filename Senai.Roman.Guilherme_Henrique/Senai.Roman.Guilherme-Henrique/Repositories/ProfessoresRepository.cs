using Senai.Roman.Guilherme_Henrique.Domains;
using Senai.Roman.Guilherme_Henrique.Interfaces;
using Senai.Roman.Guilherme_Henrique.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.Guilherme_Henrique.Repositories
{
    public class ProfessoresRepository : IProfessoresRepository
{
    public Professores BuscarPorNomeESenha(LoginViewModel dadosLogin)
    {
        using(RomanContext ctx = new RomanContext())
        {
            return ctx.Professores.FirstOrDefault(x => x.Nome == dadosLogin.Nome && x.Senha == dadosLogin.Senha);
        }
    }
}
}
