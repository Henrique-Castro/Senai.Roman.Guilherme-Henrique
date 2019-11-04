using Microsoft.EntityFrameworkCore;
using Senai.Roman.Guilherme_Henrique.Domains;
using Senai.Roman.Guilherme_Henrique.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Roman.Guilherme_Henrique.Repositories
{
    public class ProjetosRepository : IProjetosRepository
    {
        public void CadastrarProjeto(Projetos novoProjeto)
        {
            using(RomanContext ctx = new RomanContext())
            {
                ctx.Projetos.Add(novoProjeto);
                ctx.SaveChanges();
            }
        }

        public List<Projetos> ListarProjetos()
        {
            using (RomanContext ctx = new RomanContext())
            {
                return ctx.Projetos.Include(x => x.Temas).ToList();
            }
        }

        
    }
}
