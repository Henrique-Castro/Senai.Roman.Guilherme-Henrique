using System;
using System.Collections.Generic;

namespace Senai.Roman.Guilherme_Henrique.Domains
{
    public partial class Temas
    {
        public int IdTema { get; set; }
        public string Nome { get; set; }
        public int? IdProjeto { get; set; }

        public Projetos IdProjetoNavigation { get; set; }
    }
}
