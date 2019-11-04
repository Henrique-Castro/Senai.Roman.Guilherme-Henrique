using System;
using System.Collections.Generic;

namespace Senai.Roman.Guilherme_Henrique.Domains
{
    public partial class Projetos
    {
        public Projetos()
        {
            Temas = new HashSet<Temas>();
        }

        public int IdProjeto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Temas> Temas { get; set; }
    }
}
