using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdEspecialidade { get; set; }
        public string NomeEspeci { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
