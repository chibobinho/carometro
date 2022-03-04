using System;
using System.Collections.Generic;

#nullable disable

namespace senai_spmedgroup_webAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public string Email { get; set; }
        public string NomePac { get; set; }
        public DateTime DataNascPac { get; set; }
        public string TelefonePac { get; set; }
        public string RgPac { get; set; }
        public string CpfPac { get; set; }
        public string EnderecoPac { get; set; }

        public virtual Usuario EmailNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
