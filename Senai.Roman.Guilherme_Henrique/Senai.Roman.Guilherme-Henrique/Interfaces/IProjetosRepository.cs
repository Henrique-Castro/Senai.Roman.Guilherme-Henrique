using Senai.Roman.Guilherme_Henrique.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.Guilherme_Henrique.Repositories
{
   public  interface IProjetosRepository
    {
        List<Projetos> ListarProjetos();
        void CadastrarProjeto(Projetos novoProjeto);
    }
}
